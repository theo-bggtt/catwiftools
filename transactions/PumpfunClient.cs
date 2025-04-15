using Solnet.Programs.Models;
using Solnet.Programs.Utilities;
using Solnet.Programs;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Models;
using Solnet.Rpc.Types;
using Solnet.Rpc;
using Solnet.Wallet;
using System;
using Solnet.Wallet.Utilities;
using SimpleBase;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Solnet.Pumpfun.Accounts;
using Solnet.Pumpfun;
using Solnet.Wallet.Bip39;
using Solnet.Wallet.Utilities;

namespace catwiftools.transactions
{
    internal class PumpfunClient
    {
        public IRpcClient RpcClient { get; set; }

        public async Task<AccountResultWrapper<BondingCurve>> GetBondingCurveAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<BondingCurve>(res);
            var resultingAccount = BondingCurve.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<BondingCurve>(res, resultingAccount);
        }

        public async Task<string> Buy(string walletPrivateKey, string mintAddress, decimal solAmount, decimal slippagePercentage, ulong computeBudget = 100_000, ulong computePrice = 1_080_000)
        {
            try
            {
                // 1. Décoder la clé privée (Base58 -> byte[])
                string base58Key = walletPrivateKey; // ta clé base58 de 64 bytes
                Account trader = Account.FromSecretKey(base58Key);

                // 3. Adresses essentielles
                PublicKey mint = new PublicKey(mintAddress);
                PublicKey associatedUser = AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(trader.PublicKey, mint);
                PublicKey bondingCurveAddress = PDALookup.FindBondingPDA(mint);
                PublicKey associatedCurveAddress = PDALookup.FindAssociatedBondingPDA(bondingCurveAddress, mint);

                // 4. Récupérer la bonding curve
                var curveResult = await GetBondingCurveAsync(bondingCurveAddress);
                if (curveResult == null || !curveResult.WasSuccessful || curveResult.ParsedResult == null)
                    return "Bonding curve introuvable ou invalide";

                BondingCurve curve = curveResult.ParsedResult;

                // 5. Calcul du montant à acheter
                decimal virtualSol = curve.virtualSolReserves / SolHelper.LAMPORTS_PER_SOL;
                decimal virtualToken = curve.virtualTokenReserves / 1_000_000m;
                decimal tokenPrice = virtualSol / virtualToken;

                ulong amountOut = (ulong)(solAmount / tokenPrice) * 1_000_000;
                decimal slippage = (solAmount / 100) * slippagePercentage;
                ulong maxSol = SolHelper.ConvertToLamports(solAmount + slippage);

                // 6. Dernier blockhash
                var blockHashResult = await RpcClient.GetLatestBlockHashAsync();
                if (!blockHashResult.WasSuccessful || blockHashResult.Result == null)
                    return "Impossible de récupérer le blockhash";

                // 7. Construction des instructions
                var instructions = new List<TransactionInstruction>
        {
            ComputeBudgetProgram.SetComputeUnitLimit((uint)computeBudget),
            ComputeBudgetProgram.SetComputeUnitPrice(computePrice)
        };

                // 7bis. Création de l'ATA si nécessaire
                if (!await AccountExists(trader.PublicKey, mint))
                {
                    var createATA = AssociatedTokenAccountProgram.CreateAssociatedTokenAccount(trader.PublicKey, trader.PublicKey, mint);
                    instructions.Add(createATA);
                }

                // 8. Instruction d'achat
                var buyIx = PumpfunProgram.CreateBuyInstruction(
                    mint,
                    bondingCurveAddress,
                    associatedCurveAddress,
                    associatedUser,
                    trader.PublicKey,
                    amountOut,
                    maxSol
                );

                instructions.Add(buyIx);

                // 9. Construction de la transaction
                var txBuilder = new TransactionBuilder()
                    .SetFeePayer(trader)
                    .SetRecentBlockHash(blockHashResult.Result.Value.Blockhash);

                foreach (var ix in instructions)
                    txBuilder.AddInstruction(ix);

                byte[] finalTx = txBuilder.Build(trader);

                // 10. Envoi de la transaction
                var sendResult = await RpcClient.SendTransactionAsync(finalTx);
                if (!sendResult.WasSuccessful)
                    return $"Échec de la transaction : {sendResult.Reason}";

                return sendResult.Result ?? "Transaction envoyée, signature non reçue";
            }
            catch (Exception ex)
            {
                return $"Erreur dans Buy: {ex.Message}";
            }
        }


        public async Task<string> Sell(Account wallet, string mint_address, decimal token_amount, decimal min_sol_out = 0, ulong computebudget = 100000, ulong computeprice = 2080000)
        {
            PublicKey mint = new PublicKey(mint_address);
            PublicKey associatedUser = AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(wallet, mint);

            PublicKey bondingCurveAddress = PDALookup.FindBondingPDA(mint);
            PublicKey associatedCurveAddress = PDALookup.FindAssociatedBondingPDA(bondingCurveAddress, mint);
            BondingCurve? curve = (await GetBondingCurveAsync(mint_address)).ParsedResult;

            if (curve != null)
            {
                TransactionInstruction computeBudget = PumpfunProgram.SetCUlimit(computebudget);
                TransactionInstruction computePrice = ComputeBudgetProgram.SetComputeUnitPrice(computeprice);
                TransactionInstruction sell_instruction = PumpfunProgram.CreateSellInstruction(
                    mint, bondingCurveAddress, associatedCurveAddress,
                    associatedUser, wallet, (ulong)(token_amount * 1000000), min_sol_out);

                TransactionBuilder tx = new TransactionBuilder();
                tx.SetFeePayer(wallet);
                tx.SetRecentBlockHash((await RpcClient.GetLatestBlockHashAsync()).ToString());
                tx.AddInstruction(computeBudget);
                tx.AddInstruction(computePrice);
                tx.AddInstruction(sell_instruction);

                byte[] final_tx = tx.Build(wallet);
                var sendResult = await RpcClient.SendTransactionAsync(final_tx);

                // Parse the JSON response to extract just the transaction signature
                using JsonDocument doc = JsonDocument.Parse(sendResult.RawRpcResponse);
                if (doc.RootElement.TryGetProperty("result", out var result))
                {
                    return result.GetString() ?? string.Empty;
                }

                return "Failed to parse transaction response";
            }
            else
            {
                return "curve not found";
            }
        }

        public decimal CalculateExpectedSolAmount(BondingCurve curve, decimal tokenAmount)
        {
            // Ensure the conversion factors are correct
            decimal virtualSol = curve.virtualSolReserves / SolHelper.LAMPORTS_PER_SOL;
            decimal virtualToken = curve.virtualTokenReserves / 1000000;

            // Calculate the token price based on the bonding curve
            decimal tokenPrice = virtualSol / virtualToken;

            // Calculate the expected SOL amount based on the token amount and token price
            decimal expectedSolAmount = tokenAmount * tokenPrice / 1000000;

            return expectedSolAmount;
        }


        public async Task<bool> AccountExists(PublicKey owner, PublicKey mint)
        {
            PublicKey associatedAccount = AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(owner, mint);
            var accountInfo = await RpcClient.GetAccountInfoAsync(associatedAccount);
            return accountInfo.Result.Value != null;
        }

        public async Task<string> OpenAccount(PublicKey owner, string mint_address)
        {
            PublicKey mint = new PublicKey(mint_address);
            if (await AccountExists(owner, mint))
            {
                return "Account already exists";
            }

            var openInstruction = AssociatedTokenAccountProgram.CreateAssociatedTokenAccount(owner, owner, mint);
            var latestBlockHash = (await RpcClient.GetLatestBlockHashAsync()).Result.Value;

            var tx = new TransactionBuilder()
                .SetFeePayer(owner)
                .SetRecentBlockHash(latestBlockHash.Blockhash)
                .AddInstruction(openInstruction);
            var final_tx = tx.Build((IList<Account>)owner); // Use owner to sign the transaction
            return (await RpcClient.SendTransactionAsync(final_tx)).RawRpcResponse;
        }


        public async Task<string> CloseAccount(PublicKey owner, string mint_address)
        {
            PublicKey mint = new PublicKey(mint_address);
            if (!await AccountExists(owner, mint))
            {
                return "Account does not exist";
            }

            PublicKey associatedAccount = AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(owner, mint);
            TransactionInstruction closeInstruction = TokenProgram.CloseAccount(
                associatedAccount,
                owner,
                owner,
                TokenProgram.ProgramIdKey
            );

            LatestBlockHash latestBlockHash = (await RpcClient.GetLatestBlockHashAsync()).Result.Value;
            var tx = new TransactionBuilder()
                .SetFeePayer(owner)
                .SetRecentBlockHash(latestBlockHash.Blockhash)
                .AddInstruction(closeInstruction);
            byte[] final_tx = tx.Build((IList<Account>)owner);
            return (await RpcClient.SendTransactionAsync(final_tx)).RawRpcResponse;
        }

        public async Task<bool> IsTransactionFinalized(string transactionSignature, CancellationToken cancellationToken = default)
        {
            string apiKey = ConfigHelper.LoadEnvVariables().ApiKey;
            using var httpClient = new HttpClient();
            var startTime = DateTime.UtcNow;
            int attempt = 0;

            while (!cancellationToken.IsCancellationRequested)
            {
                attempt++;
                var elapsed = DateTime.UtcNow - startTime;

                if (attempt >= 100)
                {
                    AppState.WriteConsole("Time out after 100 tries");
                    return false;
                }

                try
                {
                    // Build the RPC request
                    var request = new
                    {
                        jsonrpc = "2.0",
                        id = "1",
                        method = "getTransaction",
                        @params = new[] { transactionSignature }
                    };

                    // Send request with timeout
                    using var response = await httpClient.PostAsJsonAsync($"https://mainnet.helius-rpc.com/?api-key={apiKey}", request, cancellationToken);
                    var json = await response.Content.ReadFromJsonAsync<JsonDocument>(cancellationToken);

                    // Check if transaction exists
                    if (json == null || !json.RootElement.TryGetProperty("result", out var result))
                    {
                        AppState.WriteConsole($"[Attempt {attempt}] Transaction not found yet");
                        await Task.Delay(1000, cancellationToken);
                        continue;
                    }

                    // Transaction found - check status
                    if (result.ValueKind == JsonValueKind.Null)
                    {
                        AppState.WriteConsole($"[Attempt {attempt}] Transaction not yet confirmed");
                    }
                    else
                    {
                        // Check for transaction failure
                        if (result.TryGetProperty("meta", out var meta) &&
                            meta.TryGetProperty("err", out var err) &&
                            err.ValueKind != JsonValueKind.Null)
                        {
                            AppState.WriteConsole($"[Attempt {attempt}] Transaction failed: {err}");
                            return false;
                        }

                        // Check for successful transaction
                        if (result.TryGetProperty("slot", out _))
                        {
                            AppState.WriteConsole($"[Attempt {attempt}] Transaction confirmed in slot {result.GetProperty("slot")}");
                            AppState.RecentAction($"Transaction confirmed in slot {result.GetProperty("slot")}");
                            return true;
                        }
                    }
                }
                catch (Exception ex) when (ex is not OperationCanceledException)
                {
                    AppState.WriteConsole($"[Attempt {attempt}] Error: {ex.Message}");
                }

                // Wait before retry
                await Task.Delay(1000, cancellationToken);
            }

            AppState.WriteConsole("Monitoring cancelled");
            return false;
        }

        
    }
}
