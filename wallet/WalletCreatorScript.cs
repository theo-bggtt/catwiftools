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
using Solnet.Wallet.Utilities;

namespace WalletGenerator
{
    public class WalletCreator
    {
        UiHelper functions = new UiHelper();

        public static List<(string Mnemonic, string PrivateKey)> GenWallets(int? qt)
        {
            if (qt == null)
            {
                qt = 1;
            }

            List<(string Mnemonic, string PrivateKey)> wallets = new List<(string, string)>();

            for (int i = 0; i < qt; i++)
            {
                // Step 1: Generate a new mnemonic
                Mnemonic newMnemonic = new Mnemonic(WordList.English, WordCount.Twelve);
                string walletMnemonic = newMnemonic.ToString();

                // Step 2: Create a wallet from the mnemonic
                Wallet wallet = new Wallet(walletMnemonic, WordList.English);

                // Step 3: Derive the first account with Solana standard path
                Account account = wallet.GetAccount(0); // m/44'/501'/0'/0'

                // Step 4: Get private key bytes (64 bytes total)
                byte[] privateKeyBytes = account.PrivateKey;

                // Step 5: Base58 encode the 64-byte private key
                string privateKeyBase58 = Encoders.Base58.EncodeData(privateKeyBytes);

                wallets.Add((walletMnemonic, privateKeyBase58));
            }

            return wallets;
        }

        public void SaveWallets(List<(string Mnemonic, string PrivateKey)> wallets, int group_id, bool saveMnemonics = false)
        {
            using (var connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
            {
                try
                {
                    connection.Open();

                    foreach (var wallet in wallets)
                    {
                        string walletAddress = walletHelper.GetWalletAddress(wallet.PrivateKey);

                        string query;
                        if (saveMnemonics)
                        {
                            // Save Mnemonic too
                            query = "INSERT INTO wallets (walletAddress, privateKey, mnemonic, group_id) VALUES (@walletAddress, @privateKey, @mnemonic, @group_id)";
                        }
                        else
                        {
                            // Save only Private Key (like before)
                            query = "INSERT INTO wallets (walletAddress, privateKey, group_id) VALUES (@walletAddress, @privateKey, @group_id)";
                        }

                        using (var command = new SqliteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@walletAddress", walletAddress);
                            command.Parameters.AddWithValue("@privateKey", wallet.PrivateKey);
                            command.Parameters.AddWithValue("@group_id", group_id);

                            if (saveMnemonics)
                            {
                                command.Parameters.AddWithValue("@mnemonic", wallet.Mnemonic);
                            }

                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    AppState.WriteConsole("Error: " + ex.Message);
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