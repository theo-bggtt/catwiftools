using catwiftools.tasks;
using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using Solnet.Wallet.Bip39;
using Solnet.Wallet;

namespace catwiftools
{
    internal class Functions
    {
        private Button? selectedButton = null;
        private static readonly (string ConnectionString, string HeliusUrl, string ApiKey) envVariables = Functions.LoadEnvVariables();
        private static string connectionString = envVariables.ConnectionString;

        public void SelectButton(Button button)
        {
            if (selectedButton != null)
            {
                selectedButton.Paint -= DrawLeftBorder;
                selectedButton.Invalidate();
            }
            selectedButton = button;
            button.ForeColor = Color.FromArgb(0, 134, 179);
            string filename = $"{button.Tag}Selected";
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "icon");
            string imagePath = Path.Combine(basePath, $"{filename}.png");
            button.Image = Image.FromFile(imagePath);

            button.Paint += DrawLeftBorder;
            button.Invalidate();
        }

        public void DeselectButton(Button button)
        {
            button.ForeColor = Color.FromArgb(153, 153, 153);
            string filename = $"{button.Tag}";
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "icon");
            string imagePath = Path.Combine(basePath, $"{filename}.png");
            button.Image = Image.FromFile(imagePath);

            button.Paint -= DrawLeftBorder;
            button.Refresh();
        }

        public void DrawLeftBorder(object? sender, PaintEventArgs e)
        {
            if (sender is Button button)
            {
                using (Pen borderPen = new Pen(Color.FromArgb(0, 134, 179), 2)) //(0,134,179) = color, 2 = thickness
                {
                    e.Graphics.DrawLine(borderPen, 0, 0, 0, button.Height);
                }
            }
        }

        public static (string ConnectionString, string HeliusUrl, string ApiKey) LoadEnvVariables()
        {
            Env.Load();
            string heliusApiKey = Env.GetString("API_KEY");
            string connectionString = "Data Source=catwiftools.db;";
            string heliusUrl = $"https://devnet.helius-rpc.com/?api-key={heliusApiKey}";
            return (connectionString, heliusUrl, heliusApiKey);
        }

        
        public int GetWalletId(string? walletAddress, string? walletphrase) // Prends l'Id d'un wallet à travers son addresse ou sa phrase, à travers la bdd
        {
            int idWallet = 0;
            if (!string.IsNullOrEmpty(walletAddress))
            {
                string query = $"SELECT idWallet FROM wallets WHERE walletAddress = '{walletAddress}'";
                using (SqliteConnection connection = new SqliteConnection(connectionString))
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
            else if (!string.IsNullOrEmpty(walletphrase))
            {
                string query = $"SELECT idWallet FROM wallets WHERE walletphrase = '{walletphrase}'";
                using (SqliteConnection connection = new SqliteConnection(connectionString))
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
        public string GetWalletAddress(int? idWallet, string? walletphrase) // Prends l'addresse d'un walletId ou d'une phrase de wallet
        {
            string WalletAddress = "";
            if (idWallet.HasValue)
            {
                string query = $"SELECT walletAddress FROM wallets WHERE idWallet = {idWallet.Value}";
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        connection.Open();
                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                WalletAddress = reader.GetString(0);
                            }
                        }
                    }
                }
            }
            else if (!string.IsNullOrEmpty(walletphrase))
            {
                string mnemonicPhrase = walletphrase.ToString();

                Wallet wallet = new Wallet(walletphrase);

                var account = wallet.GetAccount(0);
                string publicKey = account.PublicKey;
                return publicKey;
            }
            return WalletAddress;
        }
        public string GetWalletphrase(int? idWallet, string? walletAddress) // Prends la phrase mnemonic d'un walletId ou d'une addresse, à travers la bdd
        {
            string Walletphrase = "";
            if (idWallet.HasValue)
            {
                string query = $"SELECT walletphrase FROM wallets WHERE idWallet = {idWallet.Value}";
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        connection.Open();
                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Walletphrase = reader.GetString(0);
                            }
                        }
                    }
                }
            }
            else if (!string.IsNullOrEmpty(walletAddress))
            {
                string query = $"SELECT walletphrase FROM wallets WHERE walletAddress = '{walletAddress}'";
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        connection.Open();
                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Walletphrase = reader.GetString(0);
                            }
                        }
                    }
                }
            }
            return Walletphrase;
        }

        public string CheckForFundWallet()
        {
            using (var connection = new SqliteConnection(Functions.LoadEnvVariables().ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT walletAddress FROM Wallets WHERE walletType = 1";
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            Console.WriteLine(reader.GetString(0));
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
    }
}