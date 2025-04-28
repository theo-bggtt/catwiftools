using catwiftools.wallet;
using Solnet.Pumpfun;
using Solnet.Rpc;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using PumpfunClient = catwiftools.transactions.Source.PumpfunClient;

namespace catwiftools.transactions
{
    internal class TransactionHelper
    {
        private static readonly HttpClient client = new HttpClient();

        public async static Task<string> Buy(string privateKeyBase58, string mintAddress, string solAmountInput, string? slippagePercentageInput)
        {
            try
            {
                // 1. Connect to Solana RPC
                IRpcClient rpcClient = ClientFactory.GetClient(Cluster.MainNet);

                // 2. Load Account from Base58 Private Key
                Account trader = Account.FromSecretKey(privateKeyBase58); // ✅ Correct now!

                // 3. Initialize Pumpfun Client
                PumpfunClient pumpfunClient = new PumpfunClient(rpcClient);

                // 4. Parse input values safely
                if (!decimal.TryParse(solAmountInput, out decimal solAmount))
                {
                    throw new Exception($"Invalid SOL amount input: {solAmountInput}");
                }

                decimal slippagePercentage = 25.0m; // Default 25%
                if (!string.IsNullOrEmpty(slippagePercentageInput))
                {
                    if (!decimal.TryParse(slippagePercentageInput, out slippagePercentage))
                    {
                        throw new Exception($"Invalid slippage input: {slippagePercentageInput}");
                    }
                }

                // 5. Execute Buy
                string response = await pumpfunClient.Buy(trader, mintAddress, solAmount, slippagePercentage);

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error during Buy: {ex.Message}");
                return $"Error: {ex.Message}";
            }
        }


        public async static void Sell(string privateKeyBase58, string mintAddress, string tokenAmountInput)
        {
            try
            {
                // 1. Load RPC client
                IRpcClient rpcClient = ClientFactory.GetClient(Cluster.MainNet);

                // 2. Load Account from Base58 private key
                Account trader = Account.FromSecretKey(privateKeyBase58); // ✅ Correct now!

                // 3. Initialize Pumpfun Client
                PumpfunClient pumpfunClient = new PumpfunClient(rpcClient);

                // 4. Get the wallet public address
                string walletAddress = trader.PublicKey.Key; // ✅ Cleaner! No need to call walletHelper.

                // 5. Get token balance
                decimal tokenAmount = await GetTokenBalanceAsync(walletAddress, mintAddress);

                // 6. Call Pumpfun Sell
                string response = await pumpfunClient.Sell(trader, mintAddress, tokenAmount);

                Console.WriteLine($"Sell Response: {response}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error during Sell: {ex.Message}");
            }
        }


        public static async Task<decimal> GetTokenBalanceAsync(string walletAddress, string tokenMintAddress)
        {
            string url = $"https://solana-gateway.moralis.io/account/mainnet/{walletAddress}/tokens";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("X-API-Key", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJub25jZSI6IjNkODU4Nzk5LWRkZjMtNGRhNC1hMTkwLTM0M2VjNTAwNWQwZiIsIm9yZ0lkIjoiNDQyMzIzIiwidXNlcklkIjoiNDU1MDg0IiwidHlwZUlkIjoiYzg0MTE3NWUtY2ZkZS00N2U5LWJiOWUtNGRhNGM1MGZlY2RmIiwidHlwZSI6IlBST0pFQ1QiLCJpYXQiOjE3NDQ4NzgyOTMsImV4cCI6NDkwMDYzODI5M30.zUFPUjDhBHGoFuerzyhiDbJr71bq9ryx9F4oq4M140k");

            HttpResponseMessage response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return 0;
            }

            var json = await response.Content.ReadAsStringAsync();
            JsonArray? tokens = JsonNode.Parse(json)?.AsArray();

            if (tokens == null)
            {
                Console.WriteLine("Failed to parse token list.");
                return 0;
            }

            foreach (var token in tokens)
            {
                if (token?["mint"]?.ToString() == tokenMintAddress)
                {
                    if (decimal.TryParse(token["amount"]?.ToString(), out decimal balance))
                    {
                        return balance;
                    }
                }
            }

            // Token not found
            return 0;
        }
    }
}
