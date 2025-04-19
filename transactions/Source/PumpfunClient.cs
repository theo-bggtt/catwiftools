using Solnet.Programs;
using Solnet.Programs.Models;
using Solnet.Programs.Utilities;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Models;
using Solnet.Rpc.Types;
using Solnet.Wallet;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using static catwiftools.transactions.Source.Accounts;

namespace catwiftools.transactions.Source
{
    public class PumpfunClient
    {
        public IRpcClient RpcClient { get; set; }

        public PumpfunClient(IRpcClient rpc)
        {
            RpcClient = rpc;
        }
        public async Task<AccountResultWrapper<BondingCurve>> GetBondingCurveAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<BondingCurve>(res);
            var resultingAccount = BondingCurve.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<BondingCurve>(res, resultingAccount);
        }

        public async Task<string> Buy(Account trader, string mint_address, decimal sol_amount,  decimal slippage_percentage, ulong computebudget = 100000, ulong computeprice = 1080000)
        {
            PublicKey mint = new PublicKey(mint_address);
            PublicKey associatedUser = AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(trader, mint);

            PublicKey bondingCurveAddress = PDALookup.FindBondingPDA(mint);
            PublicKey associatedCurveAddress = PDALookup.FindAssociatedBondingPDA(bondingCurveAddress, mint);
            BondingCurve? curve = (await GetBondingCurveAsync(bondingCurveAddress)).ParsedResult;
            if (curve != null)
            {
                OpenAccount(trader, trader, mint_address);
                decimal virtualSol = curve.virtualSolReserves / SolHelper.LAMPORTS_PER_SOL;
                
                decimal virtualToken = curve.virtualTokenReserves / 1000000;
              
                decimal tokenPrice = virtualSol / virtualToken;
           
                ulong amountOut = (ulong)(sol_amount / tokenPrice) * 1000000;
           
                decimal slippage = sol_amount / 100 * slippage_percentage;
                ulong max_sol = SolHelper.ConvertToLamports(sol_amount + slippage);
                TransactionInstruction computeBudget = PumpfunProgram.SetCUlimit(computebudget);
                TransactionInstruction computePrice = ComputeBudgetProgram.SetComputeUnitPrice(computeprice);
                TransactionInstruction buy_instruction = PumpfunProgram.CreateBuyInstruction(mint, bondingCurveAddress, associatedCurveAddress, associatedUser, trader, amountOut, max_sol);

                LatestBlockHash latestBlockHash = (await RpcClient.GetLatestBlockHashAsync()).Result.Value;
                TransactionBuilder tx = new TransactionBuilder();
                tx.SetFeePayer(trader);
                tx.SetRecentBlockHash(latestBlockHash.Blockhash);
                tx.AddInstruction(computeBudget);
                tx.AddInstruction(computePrice);
                //tx.AddInstruction(AssociatedTokenAccountProgram.CreateAssociatedTokenAccount(trader, trader, mint));
                tx.AddInstruction(buy_instruction);
                byte[] final_tx = tx.Build(trader);
                string response = (await RpcClient.SendTransactionAsync(final_tx)).RawRpcResponse;
                return response;
            }
            else
            {
                return "curve not found";
            }
        }
        public async Task<string> Sell(Account trader, string mint_address, decimal token_amount, decimal min_sol_out = 0, ulong computebudget = 100000, ulong computeprice = 1080000)
        {
            PublicKey mint = new PublicKey(mint_address);
            PublicKey associatedUser = AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(trader, mint);

            PublicKey bondingCurveAddress = PDALookup.FindBondingPDA(mint);
            PublicKey associatedCurveAddress = PDALookup.FindAssociatedBondingPDA(bondingCurveAddress, mint);
            BondingCurve? curve = (await GetBondingCurveAsync(mint_address)).ParsedResult;

            if (curve != null)
            {
                TransactionInstruction computeBudget = PumpfunProgram.SetCUlimit(computebudget);
                TransactionInstruction computePrice = ComputeBudgetProgram.SetComputeUnitPrice(computeprice);
                TransactionInstruction sell_instruction = PumpfunProgram.CreateSellInstruction(
                    mint, bondingCurveAddress, associatedCurveAddress,
                    associatedUser, trader, (ulong)(token_amount * 1000000), min_sol_out);
                LatestBlockHash latestBlockHash = (await RpcClient.GetLatestBlockHashAsync()).Result.Value;
                TransactionBuilder tx = new TransactionBuilder();
                tx.SetFeePayer(trader);
                tx.SetRecentBlockHash(latestBlockHash.Blockhash);
                tx.AddInstruction(computeBudget);
                tx.AddInstruction(computePrice);
                tx.AddInstruction(sell_instruction);

                byte[] final_tx = tx.Build(trader);
                var sendResult = await RpcClient.SendTransactionAsync(final_tx);

                // Parse the JSON response to extract just the transaction signature
                using JsonDocument doc = JsonDocument.Parse(sendResult.RawRpcResponse);
                if (doc.RootElement.TryGetProperty("result", out var result))
                {
                    CloseAccount(trader, trader, mint_address);
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

        public async Task<string> OpenAccount(Account trader, PublicKey owner, string mint_address)
        {
            PublicKey mint = new PublicKey(mint_address);
            bool exists = await AccountExists(owner, mint);
            if (exists)
            {
                return "Account already exists";
            }

            TransactionInstruction openInstruction = AssociatedTokenAccountProgram.CreateAssociatedTokenAccount(owner, owner, mint);

            LatestBlockHash latestBlockHash = (await RpcClient.GetLatestBlockHashAsync()).Result.Value;
            TransactionBuilder tx = new TransactionBuilder();
            tx.SetFeePayer(owner);
            tx.SetRecentBlockHash(latestBlockHash.Blockhash);
            tx.AddInstruction(openInstruction);

            byte[] final_tx = tx.Build(trader);
            string response = (await RpcClient.SendTransactionAsync(final_tx)).RawRpcResponse;
            return response;
        }

        public async Task<string> CloseAccount(Account trader, PublicKey owner, string mint_address)
        {
            PublicKey mint = new PublicKey(mint_address);
            bool exists = await AccountExists(owner, mint);
            if (!exists)
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
            TransactionBuilder tx = new TransactionBuilder();
            tx.SetFeePayer(owner);
            tx.SetRecentBlockHash(latestBlockHash.Blockhash);
            tx.AddInstruction(closeInstruction);

            byte[] final_tx = tx.Build(trader);
            string response = (await RpcClient.SendTransactionAsync(final_tx)).RawRpcResponse;
            return response;
        }

        public async Task<bool> IsTransactionFinalized(
        string transactionSignature,
        CancellationToken cancellationToken = default)
        {
            const string rpcUrl = "https://mainnet.helius-rpc.com/?api-key=6f275ff9-fc95-4664-84cb-3d6d4eade469";
            using var httpClient = new HttpClient();
            var startTime = DateTime.UtcNow;
            int attempt = 0;

            while (!cancellationToken.IsCancellationRequested)
            {
                attempt++;
                var elapsed = DateTime.UtcNow - startTime;

                if (attempt >= 100) 
                {
                    Console.WriteLine("Time out after 100 tries");
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
                    using var response = await httpClient.PostAsJsonAsync(rpcUrl, request, cancellationToken);
                    var json = await response.Content.ReadFromJsonAsync<JsonDocument>(cancellationToken);

                    // Check if transaction exists
                    if (json == null || !json.RootElement.TryGetProperty("result", out var result))
                    {
                        Console.WriteLine($"[Attempt {attempt}] Transaction not found yet");
                        await Task.Delay(1000, cancellationToken);
                        continue;
                    }

                    // Transaction found - check status
                    if (result.ValueKind == JsonValueKind.Null)
                    {
                        Console.WriteLine($"[Attempt {attempt}] Transaction not yet confirmed");
                    }
                    else
                    {
                        // Check for transaction failure
                        if (result.TryGetProperty("meta", out var meta) &&
                            meta.TryGetProperty("err", out var err) &&
                            err.ValueKind != JsonValueKind.Null)
                        {
                            Console.WriteLine($"[Attempt {attempt}] Transaction failed: {err}");
                            return false;
                        }

                        // Check for successful transaction
                        if (result.TryGetProperty("slot", out _))
                        {
                            Console.WriteLine($"[Attempt {attempt}] Transaction confirmed in slot {result.GetProperty("slot")}");
                            return true;
                        }
                    }
                }
                catch (Exception ex) when (ex is not OperationCanceledException)
                {
                    Console.WriteLine($"[Attempt {attempt}] Error: {ex.Message}");
                }

                // Wait before retry
                await Task.Delay(1000, cancellationToken);
            }

            Console.WriteLine("Monitoring cancelled");
            return false;
        }
    }
}
