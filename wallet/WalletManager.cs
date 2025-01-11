using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace catwiftools
{
    public partial class WalletManager : UserControl
    {
        // Connection string for the MySQL database
        private string connectionString = "Server=localhost;Database=catwiftools;User ID=root;Password=Theosaussure1;";

        public WalletManager()
        {
            InitializeComponent();
        }

        private void WalletManager_Load(object sender, EventArgs e)
        {
            LoadWallets(); // Automatically load wallets when the control is loaded
        }

        private void LoadWallets()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT idWallet, walletName FROM wallets";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Clear any existing items in the listBoxWallets
                            listBoxWallets.Items.Clear();

                            // Populate the ListBox with wallets from the database
                            while (reader.Read())
                            {
                                listBoxWallets.Items.Add($"{reader["idWallet"]}: {reader["walletName"]}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading wallets: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxWallets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxWallets.SelectedItem != null)
            {
                string selectedWallet = listBoxWallets.SelectedItem.ToString();
            }
        }

        private void btnReloadWallets_Click(object sender, EventArgs e)
        {
            LoadWallets(); // Reload wallets when the button is clicked
        }
    }
}
