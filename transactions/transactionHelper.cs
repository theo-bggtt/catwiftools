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

        public async static void Buy(string privateKey, string mintAddress, string solAmountInput, string? slippagePercentageInput)
        {
            IRpcClient rpcClient = ClientFactory.GetClient(Cluster.MainNet);
            Account trader = Account.FromSecretKey(privateKey);
            PumpfunClient pumpfunClient = new PumpfunClient(rpcClient);

            decimal solAmount = decimal.Parse(solAmountInput);
            decimal slippagePercentage = string.IsNullOrEmpty(slippagePercentageInput)
                ? 25.0m
                : decimal.Parse(slippagePercentageInput);

            string response = await pumpfunClient.Buy(trader, mintAddress, solAmount, slippagePercentage);
            Console.WriteLine($"Buy Response: {response}");
        }

        public async static void Sell(string privateKey, string mintAddress, string tokenAmountInput)
        {
            IRpcClient rpcClient = ClientFactory.GetClient(Cluster.MainNet);
            Account trader = Account.FromSecretKey(privateKey);
            PumpfunClient pumpfunClient = new PumpfunClient(rpcClient);
            string walletAddress = walletHelper.GetWalletAddress(privateKey).ToString();
            decimal tokenAmount = await GetTokenBalanceAsync(walletAddress, mintAddress);


            string response = await pumpfunClient.Sell(trader, mintAddress, tokenAmount);
            Console.WriteLine($"Sell Response: {response}");
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
