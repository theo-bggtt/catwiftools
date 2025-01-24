using MySqlConnector;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace catwiftools.wallet
{
    internal class RetrieveBalance
    {
        private const string HeliusApiKey = "300e94e7-9909-4a9d-9a4e-24088e7c065b";
        private static readonly string heliusUrl = $"https://devnet.helius-rpc.com/?api-key={HeliusApiKey}";
        static string connectionString = "Server=localhost;Database=catwiftools;User ID=root;Password=Theosaussure1;SslMode=none;";

        public static async Task<double> GetWalletBalance(string walletAddress, int walletType)
        {
            using (var httpClient = new HttpClient())
            {
                var requestPayload = new
                {
                    jsonrpc = "2.0",
                    id = 1,
                    method = "getBalance",
                    @params = new object[] { walletAddress }
                };

                var jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(requestPayload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                try
                {
                    var response = await httpClient.PostAsync(heliusUrl, content);
                    response.EnsureSuccessStatusCode();

                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var result = JObject.Parse(jsonResponse);

                    var balanceInLamports = result["result"]?["value"]?.Value<long>() ?? 0;

                    return balanceInLamports / 1_000_000_000.0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving wallet balance for {walletAddress}: {ex.Message}");
                    return 0;
                }
            }
        }

        public DataTable GetWallets(int walletType)
        {
            DataTable dataTable = new DataTable();

            string query = $"SELECT idWallet, walletAddress FROM wallets WHERE walletType = {walletType}";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
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
                string walletAddress = row["walletAddress"].ToString();
                double balance = await GetWalletBalance(walletAddress, walletType);
                await Task.Run(() => SaveBalanceToDatabase(walletAddress, balance));
            }
        }

        public async Task SaveBalanceToDatabase(string walletAddress, double balance)
        {
            string query = "UPDATE wallets SET balance = @balance WHERE walletAddress = @walletAddress";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@balance", balance);
                    command.Parameters.AddWithValue("@walletAddress", walletAddress);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
