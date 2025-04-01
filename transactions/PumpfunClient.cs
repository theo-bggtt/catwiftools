using Solnet.Programs.Models;
using Solnet.Programs.Utilities;
using Solnet.Programs;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Models;
using Solnet.Rpc.Types;
using Solnet.Rpc;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Solnet.Pumpfun.Accounts;
using Solnet.Pumpfun;

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

        public async Task<string> Buy(Account wallet, string mint_address, decimal sol_amount, decimal slippage_percentage, ulong computebudget = 100000, ulong computeprice = 1080000)
        {
            PublicKey mint = new PublicKey(mint_address);
            PublicKey associatedUser = AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(wallet, mint);

            PublicKey bondingCurveAddress = PDALookup.FindBondingPDA(mint);
            PublicKey associatedCurveAddress = PDALookup.FindAssociatedBondingPDA(bondingCurveAddress, mint);
            BondingCurve? curve = (await GetBondingCurveAsync(bondingCurveAddress)).ParsedResult;
            if (curve != null)
            {
                decimal virtualSol = curve.virtualSolReserves / SolHelper.LAMPORTS_PER_SOL;

                decimal virtualToken = curve.virtualTokenReserves / 1000000;

                decimal tokenPrice = virtualSol / virtualToken;

                ulong amountOut = (ulong)(sol_amount / tokenPrice) * 1000000;

                decimal slippage = sol_amount / 100 * slippage_percentage;
                ulong max_sol = SolHelper.ConvertToLamports(sol_amount + slippage);
                TransactionInstruction computeBudget = PumpfunProgram.SetCUlimit(computebudget);
                TransactionInstruction computePrice = ComputeBudgetProgram.SetComputeUnitPrice(computeprice);
                TransactionInstruction buy_instruction = PumpfunProgram.CreateBuyInstruction(mint, bondingCurveAddress, associatedCurveAddress, associatedUser, wallet, amountOut, max_sol);

                LatestBlockHash latestBlockHash = (await RpcClient.GetLatestBlockHashAsync()).Result.Value;
                TransactionBuilder tx = new TransactionBuilder();
                tx.SetFeePayer(wallet);
                tx.SetRecentBlockHash(latestBlockHash.Blockhash);
                tx.AddInstruction(computeBudget);
                tx.AddInstruction(computePrice);
                //tx.AddInstruction(AssociatedTokenAccountProgram.CreateAssociatedTokenAccount(wallet, wallet, mint));
                tx.AddInstruction(buy_instruction);
                byte[] final_tx = tx.Build(wallet);
                string response = (await RpcClient.SendTransactionAsync(final_tx)).RawRpcResponse;
                return response;
            }
            else
            {
                return "curve not found";
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
            string apiKey = Functions.LoadEnvVariables().ApiKey;
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

        public async Task<decimal> GetAccountBalance(string walletAddress, string contractAddress)
        {
            decimal balance = 0;
            var rpcClient = ClientFactory.GetClient(Cluster.MainNet);
            var mintKey = new PublicKey(contractAddress);
            var wallet = new PublicKey(walletAddress);

            var associatedTokenAccount = AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(wallet, mintKey);
            var tokenAccountTask = rpcClient.GetTokenAccountInfoAsync(associatedTokenAccount);
            var mintInfoTask = rpcClient.GetTokenMintInfoAsync(mintKey);

            await Task.WhenAll(tokenAccountTask, mintInfoTask);

            if (tokenAccountTask.Result.WasSuccessful &&
                tokenAccountTask.Result.Result != null &&
                mintInfoTask.Result.WasSuccessful &&
                mintInfoTask.Result.Result != null)
            {
                var amount = tokenAccountTask.Result.Result.Value.Data.Parsed.Info.TokenAmount.Amount;
                var decimals = mintInfoTask.Result.Result.Value.Data.Parsed.Info.Decimals;
                balance = decimal.Parse(amount) / (decimal)Math.Pow(10, decimals);
            }
            AppState.WriteConsole(balance.ToString());
            return balance;
        }
    }
}
