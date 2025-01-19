using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catwiftools.wallet
{
    public partial class walletVolume : UserControl
    {
        private static string connectionString = "Server=localhost;Database=catwiftools;User ID=root;Password=Theosaussure1;";

        public walletVolume()
        {
            InitializeComponent();
        }

        private void LoadWallets()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT * FROM wallets";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Bind the DataTable to the DataGridView
                            walletDataGridView.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load wallets: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadWalletsButton_Click(object sender, EventArgs e)
        {
            LoadWallets();
        }
    }
}
