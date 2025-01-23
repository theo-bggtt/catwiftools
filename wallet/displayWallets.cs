using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletGenerator;

namespace catwiftools.wallet
{
    internal class displayWallets
    {
        static string connectionString = "Server=localhost;Database=catwiftools;User ID=root;Password=Theosaussure1;SslMode=none;";

        public DataTable GetWallets(int walletType)
        {
            DataTable dataTable = new DataTable();

            string query = $"SELECT idWallet, walletAddress, walletphrase FROM wallets where walletType = {walletType}";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        public void StyleDataGridView(DataGridView dataGridViewWallets)
        {
            // Set background and grid color
            dataGridViewWallets.BackgroundColor = Color.FromArgb(45, 45, 48);
            dataGridViewWallets.GridColor = Color.FromArgb(60, 60, 60);

            // Row style
            dataGridViewWallets.DefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);
            dataGridViewWallets.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dataGridViewWallets.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 100, 100);
            dataGridViewWallets.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewWallets.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewWallets.DefaultCellStyle.Padding = new Padding(5);

            // Alternating rows
            dataGridViewWallets.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewWallets.AlternatingRowsDefaultCellStyle.ForeColor = Color.WhiteSmoke;

            // Column headers
            dataGridViewWallets.EnableHeadersVisualStyles = false;
            dataGridViewWallets.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dataGridViewWallets.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dataGridViewWallets.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewWallets.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewWallets.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // Grid border and row headers
            dataGridViewWallets.BorderStyle = BorderStyle.None;
            dataGridViewWallets.RowHeadersVisible = false;

            // Auto-size columns
            dataGridViewWallets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Add padding for the header cells
            dataGridViewWallets.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);

            dataGridViewWallets.ScrollBars = ScrollBars.Horizontal;
        }

        public void getwalletqt(Button btnGenWallet, DataGridView dataGridViewWallets)
        {
            using (var numberInputForm = new walletCreatorForm())
            {
                var result = numberInputForm.ShowDialog();
                if (result == DialogResult.OK && numberInputForm.InputNumber.HasValue)
                {
                    MessageBox.Show($"You entered: {numberInputForm.InputNumber.Value}");
                    WalletCreator.SaveData(numberInputForm.InputNumber.Value, btnGenWallet);

                }
                else
                {
                    MessageBox.Show("Input was canceled.");
                }
            }
            Console.WriteLine("Data saved successfully!");
            LoadWalletsToGrid(1, dataGridViewWallets);
        }

        public void LoadWalletsToGrid(int walletType, DataGridView dataGridViewWallets)
        {
            DataTable wallets = GetWallets(walletType);
            dataGridViewWallets.DataSource = wallets;
            StyleDataGridView(dataGridViewWallets);
        }
    }
}