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
        UiHelper functions = new UiHelper();

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

                var wallet = new Wallet(WordCount.Twelve, WordList.English, walletMnemonic);
                Account account = wallet.Account;
                string privateKey = account.PrivateKey.ToString();

                wallets.Add(privateKey);
            }
            return wallets;
        }

        public void SaveWallets(List<String> wallets, int group_id) // Savegarde la liste de wallet avec comme type, le tag du boutton
        {
            foreach (string privateKey in wallets)
            {
                string walletAddress = walletHelper.GetWalletAddress(privateKey);
                using (var connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "INSERT INTO wallets (walletAddress, privateKey, group_id) VALUES (@walletAddress, @privateKey, @group_id)";

                        using (var command = new SqliteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@walletAddress", walletAddress);
                            command.Parameters.AddWithValue("@privateKey", privateKey);
                            command.Parameters.AddWithValue("@group_id", group_id);

                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        AppState.WriteConsole("Error: " + ex.Message);
                    }
                }
            }
        }

        public void DelWallet(string? walletAddress, int? walletId, int? group_id)
        {
            using (var connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
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
                    else if (group_id != null)
                    {
                        query = "DELETE FROM wallets WHERE group_id = @group_id";
                    }


                    using (var command = new SqliteCommand(query, connection))
                    {
                        if (walletAddress != null)
                        {
                            command.Parameters.AddWithValue("@walletAddress", walletAddress);
                        } else if (walletId != null)
                        {
                            command.Parameters.AddWithValue("@idWallet", walletId);
                        } else if (group_id != null)
                        {
                            command.Parameters.AddWithValue("@group_id", group_id);
                        }
                        

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    AppState.WriteConsole("Error: " + ex.Message);
                }
            }
        }
    }
}