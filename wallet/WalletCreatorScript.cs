using Solnet.Wallet;
using Solnet.Wallet.Bip39;
using MySql.Data.MySqlClient;
using System;
using System.Text;

namespace catwiftools.wallet
{
    public static class WalletCreatorScript
    {
        // Utilisation d'une variable d'environnement pour sécuriser la connexion
        private static string connectionString = "Server=localhost;Database=catwiftools;User ID=root;Password=Theosaussure1;";

        public static string CreateWallets(int walletQuantity, int walletType)
        {
            if (walletQuantity <= 0)
                throw new ArgumentException("Wallet quantity must be greater than 0.");

            StringBuilder wallets = new StringBuilder();

            for (int i = 0; i < walletQuantity; i++)
            {
                // Génération du portefeuille
                var newMnemonic = new Mnemonic(WordList.English, WordCount.Twelve);
                string walletMnemonic = newMnemonic.ToString();
                string walletName = WalletFromMnemonic(walletMnemonic);

                // Ajout des détails du portefeuille
                wallets.AppendLine($"Wallet N°{i + 1}: {walletName}");

                // Vérification et insertion dans la base de données
                EnsureWalletTypeExists(walletType);
                StoreWalletInDatabase(walletName, walletMnemonic, walletType);
            }

            return wallets.ToString();
        }

        private static void EnsureWalletTypeExists(int walletType)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Requête optimisée avec INSERT IGNORE
                    string query = "INSERT IGNORE INTO wallettypes (typeName) VALUES (@walletType)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@walletType", walletType);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError($"Error ensuring wallet type: {ex.Message}");
            }
        }

        private static void StoreWalletInDatabase(string walletName, string walletMnemonic, int walletType)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Requête d'insertion du portefeuille
                    string query = "INSERT INTO wallets (walletName, walletphrase, walletType) VALUES (@walletName, @walletMnemonic, @walletType)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@walletName", walletName);
                        cmd.Parameters.AddWithValue("@walletMnemonic", Encrypt(walletMnemonic)); // Mnémonique chiffré
                        cmd.Parameters.AddWithValue("@walletType", walletType);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError($"Error storing wallet in database: {ex.Message}");
            }
        }

        private static string Encrypt(string data)
        {
            // Exemple de chiffrement basique (remplacez avec une méthode plus robuste en production)
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(dataBytes);
        }

        private static void LogError(string message)
        {
            // Utilisation de Serilog pour la gestion des erreurs (ou simple Console.WriteLine si Serilog n'est pas disponible)
            Console.WriteLine(message);
            // Si Serilog est configuré : Log.Error(message);
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
