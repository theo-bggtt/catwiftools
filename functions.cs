﻿using catwiftools.tasks;
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
using Solnet.Rpc;

namespace catwiftools
{
    internal class Functions
    {
        private Button? selectedButton = null;

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

        public static (string ConnectionString, string HeliusUrl, string ApiKey, Cluster cluster) LoadEnvVariables()
        {
            Env.Load();
            string heliusApiKey = Env.GetString("API_KEY");
            string connectionString = "Data Source=catwiftools.db;";
            string clusterString = Env.GetString("CLUSTER");
            Cluster cluster = (Cluster)Enum.Parse(typeof(Cluster), clusterString, true);
            string heliusUrl = $"https://devnet.helius-rpc.com/?api-key={heliusApiKey}";
            return (connectionString, heliusUrl, heliusApiKey, cluster);
        }

        public static IRpcClient GetRpcClient()
        {
            Cluster cluster = LoadEnvVariables().cluster;
            return ClientFactory.GetClient(cluster);
        }


        public int GetWalletId(string? walletAddress, string? walletphrase) // Prends l'Id d'un wallet à travers son addresse ou sa phrase, à travers la bdd
        {
            int idWallet = 0;
            if (!string.IsNullOrEmpty(walletAddress))
            {
                string query = $"SELECT idWallet FROM wallets WHERE walletAddress = '{walletAddress}'";
                using (SqliteConnection connection = new SqliteConnection(LoadEnvVariables().ConnectionString))
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
                using (SqliteConnection connection = new SqliteConnection(LoadEnvVariables().ConnectionString))
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
                using (SqliteConnection connection = new SqliteConnection(LoadEnvVariables().ConnectionString))
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
        public static string GetWalletphrase(int? idWallet, string? walletAddress) // Prends la phrase mnemonic d'un walletId ou d'une addresse, à travers la bdd
        {
            string Walletphrase = "";
            if (idWallet.HasValue)
            {
                string query = $"SELECT walletphrase FROM wallets WHERE idWallet = {idWallet.Value}";
                using (SqliteConnection connection = new SqliteConnection(LoadEnvVariables().ConnectionString))
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
                using (SqliteConnection connection = new SqliteConnection(LoadEnvVariables().ConnectionString))
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
            string[] words = Walletphrase.Split(' ');
            AppState.WriteConsole(words[0] + " " + words[1] + " " + words[2] + " " + words[3] + " ...");
            return Walletphrase;
        }

        public static string CheckForFundWallet()
        {
            using (var connection = new SqliteConnection(Functions.LoadEnvVariables().ConnectionString))
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

        public List<string> GetWalletsInGroup(int group_id)
        {
            List<string> wallets = new List<string>();
            string query = $"SELECT walletAddress FROM 'wallets' WHERE group_id = {group_id}";
            using (SqliteConnection connection = new SqliteConnection(LoadEnvVariables().ConnectionString))
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