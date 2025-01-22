using catwiftools;
using MySqlConnector;
using Solnet.Wallet.Bip39;
using Solnet.Wallet;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace WalletGenerator
{
    public static class WalletCreator
    {
        static string connectionString = "Server=localhost;Database=catwiftools;User ID=root;Password=Theosaussure1;SslMode=none;";
        public static void SaveData(int amount, Button button)
        {
            for (int i = 0; i < amount; i++)
            {
                int walletType = Convert.ToInt32(button.Tag);
                // Generate a new mnemonic
                var newMnemonic = new Mnemonic(WordList.English, WordCount.Twelve);
                string walletMnemonic = newMnemonic.ToString();
                string walletAddress = WalletFromMnemonic(walletMnemonic);

                using (var connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "INSERT INTO wallets (idWallet,walletAddress,walletphrase,walletType) VALUES (null,@walletName, @walletMnemonic, @walletType)";

                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@walletName", walletAddress);
                            command.Parameters.AddWithValue("@walletMnemonic", walletMnemonic);
                            command.Parameters.AddWithValue("@walletType", walletType);

                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            
        }

        private static string WalletFromMnemonic(string mnemonic)
        {
            // Step 1: Generate or load a mnemonic
            string mnemonicPhrase = mnemonic.ToString();

            // Step 2: Create a wallet using the mnemonic
            Wallet wallet = new Wallet(mnemonic);

            // Step 3: Get the default account (derivation path m/44'/501'/0'/0')
            var account = wallet.GetAccount(0); // Account index 0
            string publicKey = account.PublicKey;

            // Step 4: Print the wallet address (public key)
            Console.WriteLine("Wallet Address (Public Key): " + publicKey);
            return publicKey;
        }

        private static string PrivateFromMnemonic(string mnemonic)
        {
            // Step 1: Generate or load a mnemonic
            string mnemonicPhrase = mnemonic.ToString();

            // Step 2: Create a wallet using the mnemonic
            Wallet wallet = new Wallet(mnemonic);

            // Step 3: Get the default account (derivation path m/44'/501'/0'/0')
            var account = wallet.GetAccount(0); // Account index 0
            string privateKey = BitConverter.ToString(account.PrivateKey).Replace("-", "");

            // Step 4: Print the wallet address (public key)
            Console.WriteLine("Private Key: " + privateKey);
            return privateKey;
        }
    }
}
