using catwiftools;
using Solnet.Wallet.Bip39;
using Solnet.Wallet;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using catwiftools.wallet;
using DotNetEnv;
using Microsoft.Data.Sqlite;
using Solnet.Rpc;

namespace WalletGenerator
{
    public class WalletCreator
    {
        private static readonly (string ConnectionString, string HeliusUrl, string ApiKey) envVariables = Functions.LoadEnvVariables();
        private static string connectionString = envVariables.ConnectionString;
        displayWallets displayWallets = new displayWallets();
        Functions functions = new Functions();

        public async Task getwalletqt(Button btnGenWallet, DataGridView dataGridViewWallets) // Ouvre le petit formulaire et en prends la quantité
        {
            using (var numberInputForm = new walletCreatorForm())
            {
                var result = numberInputForm.ShowDialog();
                if (result == DialogResult.OK && numberInputForm.InputNumber.HasValue)
                {

                    MessageBox.Show($"You entered: {numberInputForm.InputNumber.Value}");
                    await Task.Run(() => SaveWallets(GenWallet(numberInputForm.InputNumber.Value), btnGenWallet));
                }
                else
                {
                    MessageBox.Show("Input was canceled.");
                }
            }
            Console.WriteLine("Data saved successfully!");
            displayWallets.LoadWalletsToGrid(Convert.ToInt32(btnGenWallet.Tag), dataGridViewWallets);
        }

        public static List<String> GenWallet(int? qt) // Génère 1, ou la quantité mentionnée de wallet et en retourne une liste de mnemonic
        {
            if (qt == null)
            {
                qt = 1;
            }
            List<String> wallets = new List<String>();
            for (int i = 0; i < qt; i++)
            {
                var newMnemonic = new Mnemonic(WordList.English, WordCount.Twelve);
                string walletMnemonic = newMnemonic.ToString();
                wallets.Add(walletMnemonic);
            }
            return wallets;
        }

        public void SaveWallets(List<String> wallets, Button? button) // Savegarde la liste de wallet avec comme type, le tag du boutton
        {

            foreach (string walletMnemonic in wallets)
            {
                int walletType = 0;
                var rpcClient = ClientFactory.GetClient(Cluster.DevNet);
                if (button.Tag != null)
                {
                    walletType = Convert.ToInt32(button.Tag);
                } else
                {
                    walletType = 1;
                }
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

        public void DelWallet(string? walletAddress, int? walletId, int? walletType)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "";
                    if (walletAddress != null)
                    {
                        query = "DELETE FROM wallets WHERE walletAddress = @walletAddress";
                    } else if (walletId != null)
                    {
                        query = "DELETE FROM wallets WHERE walletId = @walletId";
                    }
                    else if (walletType != null)
                    {
                        query = "DELETE FROM wallets WHERE walletType = @walletType";
                    }


                    using (var command = new SqliteCommand(query, connection))
                    {
                        if (walletAddress != null)
                        {
                            command.Parameters.AddWithValue("@walletAddress", walletAddress);
                        } else if (walletId != null)
                        {
                            command.Parameters.AddWithValue("@idWallet", walletId);
                        } else if (walletType != null)
                        {
                            command.Parameters.AddWithValue("@walletType", walletType);
                        }
                        

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