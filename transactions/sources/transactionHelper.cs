using Solnet.Pumpfun;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catwiftools.transactions.sources
{
    internal class transactionHelper
    {
        public static async Task CloseAccount(PumpfunClient pumpfunclient, Account trader, string mintAddress)
        {
            string response = await pumpfunclient.CloseAccount(trader, mintAddress);
            AppState.WriteConsole($"Account Closure: {response}");
        }

        public static async Task BuyTokens(PumpfunClient pumpfunClient, Account trader)
        {
            Console.Write("Enter the token mint address: ");
            string? mintAddress = Console.ReadLine();
            if (string.IsNullOrEmpty(mintAddress))
            {
                AppState.WriteConsole("Token mint address cannot be null or empty.");
                return;
            }
            Console.Write("Enter the amount of SOL to spend: ");
            string? solAmountInput = Console.ReadLine();
            if (string.IsNullOrEmpty(solAmountInput) || !decimal.TryParse(solAmountInput, out decimal solAmount))
            {
                AppState.WriteConsole("Invalid SOL amount.");
                return;
            }
            Console.Write("Enter the slippage percentage: ");
            string? slippagePercentageInput = Console.ReadLine();
            if (string.IsNullOrEmpty(slippagePercentageInput) || !decimal.TryParse(slippagePercentageInput, out decimal slippagePercentage))
            {
                AppState.WriteConsole("Invalid slippage percentage.");
                return;
            }

            // Check if account exists and create if needed
            string openAccountResponse = await pumpfunClient.OpenAccount(trader, mintAddress);
            AppState.WriteConsole($"Account Status: {openAccountResponse}");

            string response = await pumpfunClient.Buy(mintAddress, solAmount, slippagePercentage);
            AppState.WriteConsole($"Buy Response: {response}");
        }

        public static async Task SellTokens(PumpfunClient pumpfunClient, string wallet, string mintAddress, decimal tokenAmount, decimal slippagePercentage)
        {
            Account trader = Account.FromSecretKey(wallet);
            var bondingCurveResult = await pumpfunClient.GetBondingCurveAsync(mintAddress);
            if (bondingCurveResult.WasSuccessful && bondingCurveResult.ParsedResult != null)
            {
                decimal expectedSolAmount = pumpfunClient.CalculateExpectedSolAmount(bondingCurveResult.ParsedResult, tokenAmount);
                decimal minSolOut = expectedSolAmount * (1 - slippagePercentage / 100);

                AppState.WriteConsole($"Expected SOL Amount: {expectedSolAmount}");
                AppState.WriteConsole($"Minimum SOL Out (after slippage): {minSolOut}");

                var recentBlockhash = await pumpfunClient.RpcClient.GetLatestBlockHashAsync();
                if (recentBlockhash.WasSuccessful)
                {
                    string response = await pumpfunClient.Sell(mintAddress, tokenAmount, recentBlockhash.Result.Value.Blockhash, minSolOut);
                    AppState.WriteConsole($"Sell Response: {response}");
                    bool confirmed = await pumpfunClient.IsTransactionFinalized(response);
                    if (!confirmed)
                    {
                        AppState.WriteConsole("Transaction not confirmed. Exiting.");
                        return;
                    }
                    decimal balance = await pumpfunClient.GetAccountBalance(wallet, mintAddress);
                    if (balance == 0)
                    {
                        string closeAccountResponse = await pumpfunClient.CloseAccount(trader, mintAddress);
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
