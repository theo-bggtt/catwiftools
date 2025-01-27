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