﻿using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace catwiftools.wallet
{
    internal class displayWallets
    {
        
        private static readonly (string ConnectionString, string HeliusUrl, string ApiKey) envVariables = Functions.LoadEnvVariables();
        private static string connectionString = envVariables.ConnectionString;

        public DataTable GetWallets(int walletType)
        {
            DataTable dataTable = new DataTable();

            string query = $"SELECT idWallet AS `ID`, walletAddress AS `Address`, balance AS `Balance` FROM wallets WHERE walletType = {walletType}";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        // Create columns in the DataTable
                        dataTable.Columns.Add("ID", typeof(int));
                        dataTable.Columns.Add("Address", typeof(string));
                        dataTable.Columns.Add("Balance", typeof(decimal));

                        // Fill the DataTable with data from the reader
                        while (reader.Read())
                        {
                            DataRow row = dataTable.NewRow();
                            row["ID"] = reader.GetInt32(0);
                            row["Address"] = reader.GetString(1);
                            row["Balance"] = reader.GetDecimal(2);
                            dataTable.Rows.Add(row);
                        }
                    }
                }
            }
            return dataTable;
        }

        public void LoadWalletsToGrid(int walletType, DataGridView dataGridViewWallets)
        {
            DataTable wallets = GetWallets(walletType);
            dataGridViewWallets.DataSource = wallets;
            dataGridViewWallets.DataBindingComplete += DataGridViewWallets_DataBindingComplete;
            StyleDataGridView(dataGridViewWallets);
        }

        public void StyleDataGridView(DataGridView dataGridViewWallets)
        {
            // Permet d'avoir le bon formatage pour le balance (Reddit, stackoverflow, Chat GPT)
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

        // Réparti verticalement la largeur des colonnes
        private void DataGridViewWallets_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView? dataGridViewWallets = sender as DataGridView;
            if (dataGridViewWallets != null && dataGridViewWallets.Columns.Count > 1)
            {
                dataGridViewWallets.Columns[1].Width = 200;
                dataGridViewWallets.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dataGridViewWallets.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}