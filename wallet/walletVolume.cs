﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WalletGenerator;

namespace catwiftools.wallet
{
    public partial class walletVolume : UserControl
    {
        displayWallets displayWallets = new displayWallets();
        WalletCreator walletCreator = new WalletCreator();
        RetrieveBalance retrieveBalance = new RetrieveBalance();

        public walletVolume()
        {
            InitializeComponent();
            displayWallets.LoadWalletsToGrid(2, dataGridViewWallets);
            lblSolBalance.Text = "Total Balance: " + retrieveBalance.GetTotalBalance(2).ToString("N2") + " SOL";
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(2).Rows.Count;
        }

        private void walletVolume_Load(object sender, EventArgs e)
        {
            lblSolBalance.Text = "Total Balance: " + retrieveBalance.GetTotalBalance(2).ToString("N2") + " SOL";
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(2).Rows.Count;
        }


        private async void btnGenWallet_Click(object sender, EventArgs e)
        {
            await walletCreator.getwalletqt(btnGenWallet, dataGridViewWallets);
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(2).Rows.Count;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            // Adjust scrolling based on mouse wheel delta
            int scrollValue = e.Delta > 0 ? -1 : 1; // -1 for up, 1 for down
            var verticalScroll = dataGridViewWallets.FirstDisplayedScrollingRowIndex;

            // Update scrolling, ensuring it stays within bounds
            if (verticalScroll + scrollValue >= 0 && verticalScroll + scrollValue < dataGridViewWallets.RowCount)
            {
                dataGridViewWallets.FirstDisplayedScrollingRowIndex += scrollValue;
            }

            base.OnMouseWheel(e);
        }

        private async void btnCheckBalances_Click(object sender, EventArgs e)
        {
            await retrieveBalance.GetAllWalletBalances(2);
            displayWallets.LoadWalletsToGrid(2, dataGridViewWallets);
            lblSolBalance.Text = "Total Balance: " + retrieveBalance.GetTotalBalance(2).ToString("N2") + " SOL";
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(2).Rows.Count;
        }
    }
}
