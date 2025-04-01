using Solnet.Pumpfun;
using Solnet.Wallet;

namespace catwiftools.transactions
{
    internal class transactionHelper
    {
        private static PumpfunClient _pumpfunClient;
        public static async Task CloseAccount(PumpfunClient pumpfunclient, Account trader, string mintAddress)
        {
            string response = await _pumpfunClient.CloseAccount(trader, mintAddress);
            AppState.WriteConsole($"Account Closure: {response}");
        }

        public static async Task BuyTokens(string wallet, string mintAddress, decimal solAmount, decimal slippagePercentage)
        {
            Account trader = Account.FromSecretKey(wallet);
            // Check if account exists and create if needed
            string openAccountResponse = await _pumpfunClient.OpenAccount(trader, mintAddress);
            AppState.WriteConsole($"Account Status: {openAccountResponse}");

            string response = await _pumpfunClient.Buy(trader, mintAddress, solAmount, slippagePercentage);
            AppState.WriteConsole($"Buy Response: {response}");
        }

        public static async Task SellTokens(string wallet, string mintAddress, decimal tokenAmount, decimal slippagePercentage)
        {
            Account trader = Account.FromSecretKey(wallet);
            var bondingCurveResult = await _pumpfunClient.GetBondingCurveAsync(mintAddress);
            if (bondingCurveResult.WasSuccessful && bondingCurveResult.ParsedResult != null)
            {
                decimal expectedSolAmount = _pumpfunClient.CalculateExpectedSolAmount(bondingCurveResult.ParsedResult, tokenAmount);
                decimal minSolOut = expectedSolAmount * (1 - slippagePercentage / 100);

                AppState.WriteConsole($"Expected SOL Amount: {expectedSolAmount}");
                AppState.WriteConsole($"Minimum SOL Out (after slippage): {minSolOut}");

                var recentBlockhash = await _pumpfunClient.RpcClient.GetLatestBlockHashAsync();
                if (recentBlockhash.WasSuccessful)
                {
                    string response = await _pumpfunClient.Sell(trader, mintAddress, tokenAmount);
                    AppState.WriteConsole($"Sell Response: {response}");
                    bool confirmed = await _pumpfunClient.IsTransactionFinalized(response);
                    if (!confirmed)
                    {
                        AppState.WriteConsole("Transaction not confirmed. Exiting.");
                        return;
                    }
                    decimal balance = await _pumpfunClient.GetAccountBalance(wallet, mintAddress);
                    if (balance == 0)
                    {
                        string closeAccountResponse = await _pumpfunClient.CloseAccount(trader, mintAddress);
                        AppState.WriteConsole($"Account Closure: {closeAccountResponse}");
                    }
                    else
                    {
                        AppState.WriteConsole($"Balance remaining {balance}, not closing account!");
                    }
                }
                else
                {
                    AppState.WriteConsole("Failed to fetch recent blockhash.");
                }
            }
            else
            {
                AppState.WriteConsole("Failed to fetch bonding curve.");
            }
        }
    }
}
