using DotNetEnv;
using Microsoft.Data.Sqlite;
using Solnet.Programs;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace catwiftools.wallet
{
    internal class walletHelper
    {

        // ======================
        // Wallet Retrieval Methods
        // ======================
        public static List<string> GetWallets(int group_id)
        {
            List<string> walletAddresses = new List<string>();
            string query = $"SELECT walletAddress FROM wallets WHERE group_id = {group_id}";

            using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
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
            return walletAddresses;
        }

        public static string GetWalletPrivateKey(string walletAddress)
        {
            string privateKey;
            string query = "SELECT privateKey FROM wallets WHERE walletAddress = @walletAddress";

            using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
            using (SqliteCommand command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@walletAddress", walletAddress);
                connection.Open();
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        privateKey = reader.GetString(0);
                    }
                    else
                    {
                        throw new Exception("Wallet address not found.");
                    }
                }
            }
            return privateKey;
        }

        public static string getFundAddress()
        {
            string fundWallet = string.Empty;
            string query = "SELECT walletAddress FROM wallets WHERE group_id = 0";

            using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
            using (SqliteCommand command = new SqliteCommand(query, connection))
            {
                connection.Open();
                var result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    fundWallet = result.ToString();
                }
            }
            return fundWallet;
        }

        public static int GetGroupId(string groupName) // Gets wallet group Id from the group's name
        {
            int groupId = 0;
            string query = "SELECT group_id FROM wallet_groups WHERE group_name = @groupName";
            using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
            using (SqliteCommand command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@groupName", groupName);
                connection.Open();
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        groupId = reader.GetInt32(0);
                    }
                }
            }
            return groupId;
        }

        public static int GetGroupIdFromTaskGroup(int taskGroupId)
        {
            int groupId = 0;
            string query = "SELECT walletGroup FROM task_groups WHERE group_id = @taskGroupId";
            using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
            using (SqliteCommand command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@taskGroupId", taskGroupId);
                connection.Open();
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        groupId = reader.GetInt32(0);
                    }
                }
            }
            return groupId;
        }

        // ======================
        // Balance Methods
        // ======================
        public static async Task<double> GetWalletBalance(string walletAddress)
        {
            var rpcClient = ConfigHelper.GetRpcClient();
            var balanceResponse = await rpcClient.GetBalanceAsync(walletAddress);
            return balanceResponse.Result.Value / 1_000_000_000.0;
        }

        public async Task GetAllWalletBalances(int group_id)
        {
            List<string> wallet = GetWallets(group_id);
            foreach (string address in wallet)
            {
                double balance = await GetWalletBalance(address);
                await Task.Run(() => SaveBalance(address, balance));
            }
        }

        public async Task<Double> GetBalance(string walletAddress)
        {
            double balance = await GetWalletBalance(walletAddress);
            await SaveBalance(walletAddress, balance);
            return balance;
        }

        public async Task SaveBalance(string walletAddress, double balance)
        {
            string query = "UPDATE wallets SET balance = @balance WHERE walletAddress = @walletAddress";

            using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
            using (SqliteCommand command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@balance", balance);
                command.Parameters.AddWithValue("@walletAddress", walletAddress);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

        // ======================
        // Transaction Methods
        // ======================
        public static async Task Distribute(List<string> selectedAddresses, double selectedAmount)
        {
            double amountPerWall = (selectedAmount / selectedAddresses.Count - (selectedAddresses.Count * 0.01));
            AppState.WriteConsole($"Amount per wallet to send: {amountPerWall}");

            for (int i = 0; i < selectedAddresses.Count; i++)
            {
                await new walletHelper().SendSol(selectedAddresses[i], amountPerWall);
            }
        }

        public static async Task Recall(List<string> selectedAddresses)
        {
            foreach (string address in selectedAddresses)
            {
                await new walletHelper().RecallSol(address);
            }
        }

        private async Task SendSol(string address, double amount)
        {
            try
            {
                var rpcClient = ConfigHelper.GetRpcClient();
                string privateKey = GetWalletPrivateKey(null, CheckForFundWallet());
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

        private async Task RecallSol(string address)
        {
            try
            {
                var rpcClient = ConfigHelper.GetRpcClient();
                string privateKeyString = GetWalletPrivateKey(null, address);

                Wallet wallet;
                if (privateKeyString.Contains(" "))
                {
                    wallet = new Wallet(privateKeyString);
                }
                else
                {
                    byte[] privateKeyBytes = Convert.FromBase64String(privateKeyString);
                    wallet = new Wallet(privateKeyBytes);
                }

                Solnet.Wallet.PublicKey fromAccount = wallet.Account.PublicKey;
                Solnet.Wallet.PublicKey toAccount = new Solnet.Wallet.PublicKey(CheckForFundWallet());

                var balanceResponse = await rpcClient.GetBalanceAsync(fromAccount);
                AppState.WriteConsole($"🔎 Sending amount: {balanceResponse.Result.Value / 1_000_000_000.0} SOL");

                var blockHashResponse = await rpcClient.GetLatestBlockHashAsync();
                if (!blockHashResponse.WasSuccessful)
                {
                    AppState.WriteConsole("❌ Failed to fetch latest block hash.");
                    return;
                }

                string blockHash = blockHashResponse.Result.Value.Blockhash;
                AppState.WriteConsole($"🔎 Blockhash: {blockHash}");

                ulong amountLamports = balanceResponse.Result.Value - 5000;

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

        public static int GetWalletId(string? walletAddress, string? privateKey) // Prends l'Id d'un wallet à travers son addresse ou sa privateKey, à travers la bdd
        {
            int idWallet = 0;
            if (!string.IsNullOrEmpty(walletAddress))
            {
                string query = $"SELECT idWallet FROM wallets WHERE walletAddress = '{walletAddress}'";
                using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
                {
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        connection.Open();
                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idWallet = Convert.ToInt32(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            else if (!string.IsNullOrEmpty(privateKey))
            {
                string query = $"SELECT idWallet FROM wallets WHERE privateKey = '{privateKey}'";
                using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
                {
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        connection.Open();
                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idWallet = Convert.ToInt32(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            return idWallet;
        }
        public static string GetWalletAddress(string privateKey) // Prends l'addresse d'un walletId ou d'une phrase de wallet
        {
            Account account = Account.FromSecretKey(privateKey);

            // Fix: Replace the incorrect 'GetAccount' method call with the correct usage of the 'PublicKey' property.
            string publicKey = account.PublicKey.ToString();
            return publicKey;
        }

        public static string GetWalletPrivateKey(int? idWallet, string? walletAddress) // Prends la phrase mnemonic d'un walletId ou d'une addresse, à travers la bdd
        {
            string privateKey = "";
            if (idWallet.HasValue)
            {
                string query = $"SELECT privateKey FROM wallets WHERE idWallet = {idWallet.Value}";
                using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
                {
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        connection.Open();
                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                privateKey = reader.GetString(0);
                            }
                        }
                    }
                }
            }
            else if (!string.IsNullOrEmpty(walletAddress))
            {
                string query = $"SELECT privateKey FROM wallets WHERE walletAddress = '{walletAddress}'";
                using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
                {
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        connection.Open();
                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                privateKey = reader.GetString(0);
                            }
                        }
                    }
                }
            }
            // Write the 7 first characters of the private key to the console
            AppState.WriteConsole($"🔎 Private Key: {privateKey.Substring(0, 7)}...");
            return privateKey;
        }

        public static string CheckForFundWallet()
        {
            using (var connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT walletAddress FROM wallets WHERE group_id = 0";
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            return reader.GetString(0);

                        }
                        else
                        {
                            return "";
                        }
                    }
                }
            }
        }

        public static List<string> GetWalletsInGroup(int group_id)
        {
            List<string> wallets = new List<string>();
            string query = $"SELECT privateKey FROM 'wallets' WHERE group_id = {group_id}";
            using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            wallets.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return wallets;
        }
    }
}