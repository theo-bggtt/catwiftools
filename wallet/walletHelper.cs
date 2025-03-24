using DotNetEnv;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json.Linq;
using Solnet.Programs;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Wallet;
using System;
using System.Data;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace catwiftools.wallet
{
    internal class walletHelper
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

        public static async Task Distribute(List<String> selectedAddresses, double selectedAmount)
        {
            double amountPerWall = (selectedAmount / selectedAddresses.Count - (selectedAddresses.Count * 0.01));
            AppState.WriteConsole($"Amount per wallet to send: {amountPerWall}");
            for (int i = 0; i < selectedAddresses.Count; i++)
            {
                await new walletHelper().SendSol(selectedAddresses[i], amountPerWall);
            }
        }

        public static async Task Recall(List<String> selectedAddresses)
        {
            foreach (string address in selectedAddresses)
            {
                await new walletHelper().RecallSol(address);
            }
        }

        private async Task RecallSol(string address)
        {
            try
            {
                var rpcClient = ClientFactory.GetClient(Cluster.DevNet);

                // Get the wallet mnemonic or private key from the database
                string privateKeyString = Functions.GetWalletphrase(null, address);

                // Ensure correct wallet initialization
                Wallet wallet;
                if (privateKeyString.Contains(" ")) // Check if it's a mnemonic
                {
                    wallet = new Wallet(privateKeyString);
                }
                else
                {
                    byte[] privateKeyBytes = Convert.FromBase64String(privateKeyString); // Ensure correct format
                    wallet = new Wallet(privateKeyBytes);
                }

                Solnet.Wallet.PublicKey fromAccount = wallet.Account.PublicKey;
                Solnet.Wallet.PublicKey toAccount = new Solnet.Wallet.PublicKey(Functions.CheckForFundWallet());

                // Check balance
                var balanceResponse = await rpcClient.GetBalanceAsync(fromAccount);
                AppState.WriteConsole($"🔎 Sending amount: {balanceResponse.Result.Value / 1_000_000_000.0} SOL");

                // Fetch latest block hash
                var blockHashResponse = await rpcClient.GetLatestBlockHashAsync();
                if (!blockHashResponse.WasSuccessful)
                {
                    AppState.WriteConsole("❌ Failed to fetch latest block hash.");
                    return;
                }
                string blockHash = blockHashResponse.Result.Value.Blockhash;
                AppState.WriteConsole($"🔎 Blockhash: {blockHash}");

                ulong amountLamports = balanceResponse.Result.Value - 5000;

                // Build transaction
                var tx = new TransactionBuilder()
                    .SetRecentBlockHash(blockHash)
                    .SetFeePayer(fromAccount)
                    .AddInstruction(MemoProgram.NewMemo(fromAccount, "Hello from CatWifTools :)"))
                    .AddInstruction(SystemProgram.Transfer(fromAccount, toAccount, amountLamports))
                    .Build(wallet.Account); // Ensure proper signing

                // Send transaction
                var firstSig = await rpcClient.SendTransactionAsync(tx);
                AppState.WriteConsole($"✅ Transaction Sent! Signature: {firstSig.Result}");

                if (!firstSig.WasSuccessful)
                {
                    AppState.WriteConsole($"❌ Transaction Failed: {firstSig.Reason}");
                    AppState.WriteConsole($"❌ Full Response: {firstSig.RawRpcResponse}");
                }
            }
            catch (Exception ex)
            {
                AppState.WriteConsole($"❌ Error: {ex.Message}");
            }
        }


        private async Task SendSol(string address, double amount)
        {
            try
            {
                var rpcClient = ClientFactory.GetClient(Cluster.DevNet);
                string privateKey = Functions.GetWalletphrase(null, Functions.CheckForFundWallet());
                Wallet wallet = new Wallet(privateKey);
                Solnet.Wallet.PublicKey fromAccount = wallet.Account.PublicKey;
                Solnet.Wallet.PublicKey toAccount = new Solnet.Wallet.PublicKey(address);

                AppState.WriteConsole($"🔎 Amount Sending: {amount} SOL");

                ulong amountLamports = (ulong)((amount * 1_000_000_000.0) - 5000);


                var blockHashResponse = await rpcClient.GetLatestBlockHashAsync();
                if (!blockHashResponse.WasSuccessful)
                {
                    AppState.WriteConsole("❌ Failed to fetch latest block hash.");
                    return;
                }
                string blockHash = blockHashResponse.Result.Value.Blockhash;
                AppState.WriteConsole($"🔎 Blockhash: {blockHash}");

                var tx = new TransactionBuilder()
                    .SetRecentBlockHash(blockHash)
                    .SetFeePayer(fromAccount)
                    .AddInstruction(MemoProgram.NewMemo(fromAccount, "Hello from CatWifTools :)"))
                    .AddInstruction(SystemProgram.Transfer(fromAccount, toAccount, amountLamports))
                    .Build(wallet.Account);

                var firstSig = await rpcClient.SendTransactionAsync(tx);
                AppState.WriteConsole($"✅ Transaction Sent! Signature: {firstSig.Result}");

                if (!firstSig.WasSuccessful)
                {
                    AppState.WriteConsole($"❌ Transaction Failed: {firstSig.Reason}");
                    AppState.WriteConsole($"❌ Full Response: {firstSig.RawRpcResponse}");
                }
            }
            catch (Exception ex)
            {
                AppState.WriteConsole($"❌ Error: {ex.Message}");
            }
        }
    }
}