using catwiftools;
using MySqlConnector;
using Solnet.Wallet.Bip39;
using Solnet.Wallet;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using catwiftools.wallet;
using DotNetEnv;

namespace WalletGenerator
{
    public class WalletCreator
    {
        private static readonly (string ConnectionString, string HeliusUrl) envVariables = Functions.LoadEnvVariables();
        private static readonly string connectionString = envVariables.ConnectionString;

        displayWallets displayWallets = new displayWallets();

        public async void getwalletqt(Button btnGenWallet, DataGridView dataGridViewWallets)
        {
            using (var numberInputForm = new walletCreatorForm())
            {
                var result = numberInputForm.ShowDialog();
                if (result == DialogResult.OK && numberInputForm.InputNumber.HasValue)
                {
                    MessageBox.Show($"You entered: {numberInputForm.InputNumber.Value}");
                    SaveData(numberInputForm.InputNumber.Value, btnGenWallet);
                }
                else
                {
                    MessageBox.Show("Input was canceled.");
                }
            }
            Console.WriteLine("Data saved successfully!");
            displayWallets.LoadWalletsToGrid(1, dataGridViewWallets);
        }

        public static void SaveData(int amount, Button button)
        {
            for (int i = 0; i < amount; i++)
            {
                int walletType = Convert.ToInt32(button.Tag);
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
            string mnemonicPhrase = mnemonic.ToString();

            Wallet wallet = new Wallet(mnemonic);

            var account = wallet.GetAccount(0);
            string publicKey = account.PublicKey;

            Console.WriteLine("Wallet Address (Public Key): " + publicKey);
            return publicKey;
        }
    }
}