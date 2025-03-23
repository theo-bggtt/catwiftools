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

        public DataTable GetWallets(int walletType)
        {
            DataTable dataTable = new DataTable();

            string query = $"SELECT idWallet, walletAddress FROM wallets WHERE walletType = {walletType}";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        // Create columns in the DataTable
                        dataTable.Columns.Add("idWallet", typeof(int));
                        dataTable.Columns.Add("walletAddress", typeof(string));

                        // Fill the DataTable with data from the reader
                        while (reader.Read())
                        {
                            DataRow row = dataTable.NewRow();
                            row["idWallet"] = reader.GetInt32(0);
                            row["walletAddress"] = reader.GetString(1);
                            dataTable.Rows.Add(row);
                        }
                    }
                }
            }
            return dataTable;
        }

        public async Task GetAllWalletBalances(int walletType)
        {
            DataTable wallets = GetWallets(walletType);
            foreach (DataRow row in wallets.Rows)
            {
                string walletAddress = row["walletAddress"]?.ToString() ?? string.Empty;
                double balance = await GetWalletBalance(walletAddress);
                await Task.Run(() => SaveBalanceToDatabase(walletAddress, balance));
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