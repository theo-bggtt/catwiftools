using catwiftools.wallet;
using Microsoft.VisualBasic.FileIO;
using Solnet.Programs;
using Solnet.Pumpfun;
using Solnet.Rpc;
using Solnet.Wallet;

namespace catwiftools.transactions
{
    internal class transactionHelper
    {
        private static PumpfunClient _pumpfunClient;
        public static async Task CloseAccount(Account trader, string mintAddress)
        {
            string response = await _pumpfunClient.CloseAccount(trader, mintAddress);
            AppState.WriteConsole($"Account Closure: {response}");
            AppState.RecentAction($"Account Closed for wallet: {trader}");
        }

        public static async Task BuyTokens(string wallet, string mintAddress, decimal solAmount, decimal slippagePercentage)
        {
            Account trader = Account.FromSecretKey(wallet);
            // Check if account exists and create if needed
            string openAccountResponse = await _pumpfunClient.OpenAccount(trader, mintAddress);

            string response = await _pumpfunClient.Buy(trader, mintAddress, solAmount, slippagePercentage);
            AppState.WriteConsole($"Buy Response: {response}");
        }

        public static async Task SellTokens(string wallet, string mintAddress, decimal tokenAmount, decimal slippagePercentage, int? cycleAmount)
        {
            Console.WriteLine($"Wallet: {wallet}");
            Console.WriteLine($"Mint Address: {mintAddress}");
            Console.WriteLine($"Token Amount: {tokenAmount}");
            Console.WriteLine($"Slippage Percentage: {slippagePercentage}");
            Console.WriteLine($"Cycle Amount: {cycleAmount}");
            Account trader = Account.FromSecretKey(wallet);
            if (tokenAmount == 0)
            {
                tokenAmount = await GetAccountBalance(wallet, mintAddress);
                if (cycleAmount != null)
                {
                    tokenAmount = (decimal)(tokenAmount / cycleAmount);
                }
                AppState.WriteConsole("Token amount to sell: " + tokenAmount);
            }
            //var bondingCurveResult = await _pumpfunClient.GetBondingCurveAsync(mintAddress);
            //if (bondingCurveResult.WasSuccessful && bondingCurveResult.ParsedResult != null)
            //{
            //    decimal expectedSolAmount = _pumpfunClient.CalculateExpectedSolAmount(bondingCurveResult.ParsedResult, tokenAmount);
            //    decimal minSolOut = expectedSolAmount * (1 - slippagePercentage / 100);

            //    var recentBlockhash = await _pumpfunClient.RpcClient.GetLatestBlockHashAsync();
            //    if (recentBlockhash.WasSuccessful)
            //    {
            //        string response = await _pumpfunClient.Sell(trader, mintAddress, tokenAmount);
            //        AppState.WriteConsole($"Sell Response: {response}");
            //        AppState.RecentAction($"Sold all from {walletHelper.GetWalletAddress(wallet)}");
            //        bool confirmed = await _pumpfunClient.IsTransactionFinalized(response);
            //        if (!confirmed)
            //        {
            //            AppState.WriteConsole("Transaction not confirmed. Exiting.");
            //            return;
            //        }
            //        decimal balance = await GetAccountBalance(wallet, mintAddress);
            //        if (balance == 0)
            //        {
            //            string closeAccountResponse = await _pumpfunClient.CloseAccount(trader, mintAddress);
            //            AppState.WriteConsole($"Account Closure: {closeAccountResponse}");
            //        }
            //        else
            //        {
            //            AppState.WriteConsole($"Balance remaining {balance}, not closing account!");
            //        }
            //    }
            //    else
            //    {
            //        AppState.WriteConsole("Failed to fetch recent blockhash.");
            //    }
            //}
            //else
            //{
            //    AppState.WriteConsole("Failed to fetch bonding curve.");
            //}
        }

        public static async Task<decimal> GetAccountBalance(string walletAddress, string contractAddress)
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
