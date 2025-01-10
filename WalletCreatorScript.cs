using Solnet.Programs;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Core.Http;
using Solnet.Rpc.Messages;
using Solnet.Rpc.Models;
using Solnet.Rpc.Types;
using Solnet.Wallet;
using Solnet.Wallet.Bip39;
using MySql.Data.MySqlClient;
using System;
using System.Text;

namespace catwiftools
{
    public static class WalletCreatorScript
    {
        private static string connectionString = "Server=localhost;Database=catwiftools;User ID=root;Password=Theosaussure1;";

        public static string CreateWallets(int walletQuantity)
        {
            StringBuilder wallets = new StringBuilder();
            for (int i = 0; i < walletQuantity; i++)
            {
                // Generate a new mnemonic phrase for the wallet
                var newMnemonic = new Mnemonic(WordList.English, WordCount.Twelve);
                string walletMnemonic = newMnemonic.ToString();
                string walletName = "Wallet-" + (i + 1);

                // Define wallet type (example: "Solana")
                string walletType = "bundle"; // You can make this dynamic if needed

                // Add wallet details to the result string
                wallets.AppendLine($"Wallet N°{(i + 1)}: {walletMnemonic}");

                // Ensure the wallet type exists in the 'wallettypes' table, and insert if necessary
                EnsureWalletTypeExists(walletType);

                // Insert the wallet into the database
                StoreWalletInDatabase(walletName, walletMnemonic, walletType);
            }
            return wallets.ToString();
        }

        private static void EnsureWalletTypeExists(string walletType)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM wallettypes WHERE typeName = @walletType";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@walletType", walletType);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 0)
                        {
                            // If wallet type doesn't exist, insert it
                            string insertQuery = "INSERT INTO wallettypes (typeName) VALUES (@walletType)";
                            using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@walletType", walletType);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking wallet type in database: {ex.Message}");
            }
        }

        private static void StoreWalletInDatabase(string walletName, string walletMnemonic, string walletType)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO wallets (walletName, walletphrase, walletType) VALUES (@walletName, @walletMnemonic, @walletType)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@walletName", walletName);
                        cmd.Parameters.AddWithValue("@walletMnemonic", walletMnemonic);
                        cmd.Parameters.AddWithValue("@walletType", walletType);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error storing wallet in database: {ex.Message}");
            }
        }
    }
}
