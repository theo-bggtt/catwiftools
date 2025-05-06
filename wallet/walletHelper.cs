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

        // ======================
        // Transaction Methods
        // ======================

        /// <summary>
        /// Envoie du solana à chaque wallet sélectionné
        /// </summary>
        /// <param name="selectedAddresses"></param>
        /// <param name="selectedAmount"></param>
        /// <returns></returns>
        public static async Task Distribute(List<string> selectedAddresses, double selectedAmount)
        {
            double amountPerWall = (selectedAmount / selectedAddresses.Count - (selectedAddresses.Count * 0.0001));
            AppState.WriteConsole($"Amount per wallet to send: {amountPerWall}");

            for (int i = 0; i < selectedAddresses.Count; i++)
            {
                await new walletHelper().SendSol(selectedAddresses[i], amountPerWall);
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Pour chaque wallet récupéré, on envoie le solana au wallet de fond
        /// </summary>
        /// <param name="selectedAddresses"></param>
        /// <returns></returns>
        public static async Task Recall(List<string> selectedAddresses)
        {
            foreach (string address in selectedAddresses)
            {
                await new walletHelper().RecallSol(address);
            }
        }

        /// <summary>
        /// Envoie du solana à une adresse
        /// </summary>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private async Task SendSol(string address, double amount)
        {
            try
            {
                var rpcClient = ConfigHelper.GetRpcClient();

                // 1. Get the private key as Base58 string
                string privateKeyBase58 = GetWalletPrivateKey(null, CheckForFundWallet());

                // 2. No decoding needed. Use FromSecretKey directly with the Base58 string
                Account fundAccount = Account.FromSecretKey(privateKeyBase58); // ✅ Correct!

                Solnet.Wallet.PublicKey fromAccount = fundAccount.PublicKey;
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
                    .Build(fundAccount); // ✅ Signed directly with Account!

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




        /// <summary>
        /// Reprends le solana d'un wallet jusqu'au wallet de fond
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private async Task RecallSol(string address)
        {
            try
            {
                var rpcClient = ConfigHelper.GetRpcClient();

                // 1. Load the Account from the Base58 private key string
                string privateKeyBase58 = GetWalletPrivateKey(null, address);
                Account walletAccount = Account.FromSecretKey(privateKeyBase58);

                // 2. Prepare sender and receiver public keys
                Solnet.Wallet.PublicKey fromAccount = walletAccount.PublicKey;
                Solnet.Wallet.PublicKey toAccount = new Solnet.Wallet.PublicKey(CheckForFundWallet());

                // 3. Get the maximum safe amount to send
                ulong amountLamports = await walletHelper.GetMaxSendableLamports(walletAccount);

                if (amountLamports == 0)
                {
                    AppState.WriteConsole("⚠️ Not enough SOL to send after reserving fees.");
                    return;
                }

                AppState.WriteConsole($"🔎 Sending amount: {amountLamports / 1_000_000_000.0} SOL");

                // 4. Fetch latest blockhash
                var blockHashResponse = await rpcClient.GetLatestBlockHashAsync();
                if (!blockHashResponse.WasSuccessful)
                {
                    AppState.WriteConsole("❌ Failed to fetch latest block hash.");
                    return;
                }

                string blockHash = blockHashResponse.Result.Value.Blockhash;
                AppState.WriteConsole($"🔎 Blockhash: {blockHash}");

                // 5. Build and send transaction
                var tx = new TransactionBuilder()
                    .SetRecentBlockHash(blockHash)
                    .SetFeePayer(fromAccount)
                    .AddInstruction(MemoProgram.NewMemo(fromAccount, "Hello from CatWifTools :)"))
                    .AddInstruction(SystemProgram.Transfer(fromAccount, toAccount, amountLamports))
                    .Build(walletAccount); // ✅ Signed with Account directly

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

        public static async Task<ulong> GetMaxSendableLamports(Account account)
        {
            const ulong feeBuffer = 5000;
            var rpcClient = ConfigHelper.GetRpcClient();

            var balanceResponse = await rpcClient.GetBalanceAsync(account.PublicKey);

            if (!balanceResponse.WasSuccessful)
                throw new Exception("Failed to fetch wallet balance.");

            ulong balanceLamports = balanceResponse.Result.Value;

            if (balanceLamports <= feeBuffer)
                return 0;

            return balanceLamports - feeBuffer;
        }

        /// <summary>
        /// Prends l'addresse d'un walletId ou d'une phrase de wallet
        /// </summary>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static string GetWalletAddress(string privateKey)
        {
            Account account = Account.FromSecretKey(privateKey);
            string publicKey = account.PublicKey.ToString();
            return publicKey;
        }

        /// <summary>
        /// Prends la clé privée d'un walletId ou d'une addresse, à travers la bdd
        /// </summary>
        /// <param name="idWallet"></param>
        /// <param name="walletAddress"></param>
        /// <returns></returns>
        public static string GetWalletPrivateKey(int? idWallet, string? walletAddress)
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