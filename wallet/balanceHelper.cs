using DotNetEnv;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json.Linq;
using Solnet.Rpc;
using Solnet.Wallet;
using System;
using System.Data;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace catwiftools.wallet
{
    internal class balanceHelper
    {
        
        private static readonly (string ConnectionString, string HeliusUrl, string ApiKey) envVariables = Functions.LoadEnvVariables();
        private static string connectionString = envVariables.ConnectionString;
        private static readonly string heliusUrl = envVariables.HeliusUrl;
        private static readonly string apiKey = envVariables.ApiKey;

        public static async Task<double> GetWalletBalance(string walletAddress)
        {
            var rpcClient = ClientFactory.GetClient(Cluster.DevNet);
            var balanceResponse = await rpcClient.GetBalanceAsync(walletAddress);
            double balanceSol = balanceResponse.Result.Value / 1_000_000_000.0;

            return balanceSol;
        }

        public static string getFundAddress()
        {
            string fundWallet = string.Empty;
            
            string query = "SELECT walletAddress FROM wallets WHERE group_id = 0";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        fundWallet = result.ToString();
                    }
                }
            }
            return fundWallet;
        }

        public static List<String> GetWallets(int group_id)
        {
            List<String> walletAddresses = new List<String>();

            string query = $"SELECT walletAddress FROM wallets WHERE group_id = {group_id}";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            walletAddresses.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return walletAddresses;
        }

        public async Task GetAllWalletBalances(int group_id)
        {
            List<String> wallet = GetWallets(group_id);
            foreach (String address in wallet)
            {
                double balance = await GetWalletBalance(address);
                await Task.Run(() => SaveBalanceToDatabase(address, balance));
            }
        }

        public double GetTotalBalance(int walletType)
        {
            double totalbalance = 0;
            string query = $"SELECT SUM(balance) FROM wallets WHERE walletType = {walletType}";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        totalbalance = Convert.ToDouble(result);
                    }
                }
            }
            return totalbalance;
        }

        public async Task SaveBalanceToDatabase(string walletAddress, double balance)
        {
            string query = "UPDATE wallets SET balance = @balance WHERE walletAddress = @walletAddress";

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@balance", balance);
                    command.Parameters.AddWithValue("@walletAddress", walletAddress);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}