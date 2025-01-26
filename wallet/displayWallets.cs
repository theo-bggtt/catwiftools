using MySqlConnector;
using Newtonsoft.Json.Linq;
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

            string query = $"SELECT idWallet AS `ID`, walletAddress AS `Address`, balance AS `Balance` FROM wallets where walletType = {walletType}";
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

        // Rempli le DataGridView
        public void LoadWalletsToGrid(int walletType, DataGridView dataGridViewWallets)
        {
            DataTable wallets = GetWallets(walletType);
            dataGridViewWallets.DataSource = wallets;
            dataGridViewWallets.DataBindingComplete += DataGridViewWallets_DataBindingComplete;
            StyleDataGridView(dataGridViewWallets);
        }

        // Style le DataGridView
        public void StyleDataGridView(DataGridView dataGridViewWallets)
        {
            // Style du header
            dataGridViewWallets.EnableHeadersVisualStyles = false;
            dataGridViewWallets.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dataGridViewWallets.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dataGridViewWallets.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewWallets.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewWallets.ColumnHeadersDefaultCellStyle.Padding = new Padding(25);
            dataGridViewWallets.RowHeadersVisible = false;


            // Style les lignes de base
            dataGridViewWallets.DefaultCellStyle.BackColor = Color.FromArgb(25, 25, 25);
            dataGridViewWallets.DefaultCellStyle.ForeColor = Color.White;
            dataGridViewWallets.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 100, 100);
            dataGridViewWallets.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewWallets.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewWallets.RowTemplate.Height = 40;

            // Style les lignes secondaires
            dataGridViewWallets.AlternatingRowsDefaultCellStyle.ForeColor = Color.WhiteSmoke;

            // Réparti horizontalement la largeur des colonnes
            dataGridViewWallets.ScrollBars = ScrollBars.Horizontal;

            dataGridViewWallets.AllowUserToAddRows = false;

            // Permet d'avoir le bon formatage pour le balance (Reddit, stackoverflow, Chat GPT)
            dataGridViewWallets.CellFormatting += (s, e) =>
            {
                if (e.ColumnIndex == 2 && e.Value != null)
                {
                    dataGridViewWallets.CellFormatting += (s, e) =>
                    {
                        if (e.ColumnIndex == 2 && e.Value != null)
                        {
                            if (decimal.TryParse(e.Value.ToString(), out decimal balance))
                            {
                                e.Value = balance.ToString("F2") + " SOL";
                            }
                            e.FormattingApplied = true;
                        }
                    };
                }
            };

        }

        // Réparti verticalement la largeur des colonnes
        private void DataGridViewWallets_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dataGridViewWallets = sender as DataGridView;
            if (dataGridViewWallets != null && dataGridViewWallets.Columns.Count > 1)
            {
                dataGridViewWallets.Columns[1].Width = 200;
                dataGridViewWallets.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dataGridViewWallets.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}