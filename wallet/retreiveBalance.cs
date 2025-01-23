using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catwiftools.wallet
{
    internal class retreiveBalance
    {
        static string connectionString = "Server=localhost;Database=catwiftools;User ID=root;Password=Theosaussure1;SslMode=none;";

        public void checkBalance()
        {
            string walletAddress = Console.ReadLine(); // Assume you have a TextBox for wallet address.

            SaveWalletBalance(walletAddress);
        }

        private decimal GetWalletBalance(string walletAddress)
        {
            try
            {
                // Use 'wsl' to execute the Solana CLI command from your WSL environment
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = "wsl",
                    Arguments = $"solana balance {walletAddress} --url https://api.devnet.solana.com",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(processStartInfo))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    if (decimal.TryParse(output.Trim().Replace(" SOL", ""), out decimal balance))
                    {
                        return balance;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching wallet balance: " + ex.Message);
            }

            return -1; // Return -1 if balance couldn't be fetched.
        }

        public void SaveWalletBalance(string walletAddress)
        {
            decimal balance = GetWalletBalance(walletAddress);
            if (balance >= 0)
            {
                SaveBalanceToDatabase(walletAddress, balance);
                Console.WriteLine($"Balance for wallet {walletAddress}: {balance} SOL");
            }
            else
            {
                Console.WriteLine("Error fetching wallet balance.");
            }
        }

        private void SaveBalanceToDatabase(string walletAddress, decimal balance)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Wallets (address, balance) VALUES (@address, @balance)";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@address", walletAddress);
                        cmd.Parameters.AddWithValue("@balance", balance);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving to database: " + ex.Message);
            }
        }

    }
}
