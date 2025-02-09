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
using Microsoft.Data.Sqlite;

namespace WalletGenerator
{
    public class WalletCreator
    {
        private static readonly (string ConnectionString, string HeliusUrl, string ApiKey) envVariables = Functions.LoadEnvVariables();
        private static string connectionString = envVariables.ConnectionString;
        displayWallets displayWallets = new displayWallets();

        public async Task getwalletqt(Button btnGenWallet, DataGridView dataGridViewWallets)
        {
            using (var numberInputForm = new walletCreatorForm())
            {
                var result = numberInputForm.ShowDialog();
                if (result == DialogResult.OK && numberInputForm.InputNumber.HasValue)
                {
                    MessageBox.Show($"You entered: {numberInputForm.InputNumber.Value}");
                    await Task.Run(() => SaveWallet(numberInputForm.InputNumber.Value, btnGenWallet));
                }
                else
                {
                    MessageBox.Show("Input was canceled.");
                }
            }
            Console.WriteLine("Data saved successfully!");
            displayWallets.LoadWalletsToGrid(Convert.ToInt32(btnGenWallet.Tag), dataGridViewWallets);
        }

        public static void SaveWallet(int amount, Button button)
        {
            for (int i = 0; i < amount; i++)
            {
                int walletType = Convert.ToInt32(button.Tag);
                var newMnemonic = new Mnemonic(WordList.English, WordCount.Twelve);
                string walletMnemonic = newMnemonic.ToString();
                Functions functions = new Functions();
                string walletAddress = functions.GetWalletAddress(null, walletMnemonic);

                using (var connection = new SqliteConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "INSERT INTO wallets (walletAddress, walletphrase, walletType) VALUES (@walletAddress, @walletMnemonic, @walletType)";

                        using (var command = new SqliteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@walletAddress", walletAddress);
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

        public void DelWallet(string? walletAddress, int? walletId)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    if (walletAddress == null)
                    {
                        Functions functions = new Functions();
                        walletAddress = functions.GetWalletAddress(walletId, null);
                    }
                    string query = "DELETE FROM wallets WHERE walletAddress = @walletAddress";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@walletAddress", walletAddress);

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
}