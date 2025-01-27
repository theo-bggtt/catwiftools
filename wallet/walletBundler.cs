using MySqlConnector;
using Solnet.Rpc;
using Solnet.Wallet;
using System;
using System.Data;
using WalletGenerator;
using Solnet.Rpc.Types;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Text;

namespace catwiftools.wallet
{
    public partial class walletBundler : UserControl
    {
        displayWallets displayWallets = new displayWallets();
        private List<Wallet> wallets;
        RetrieveBalance retrieveBalance = new RetrieveBalance();
        WalletCreator walletCreator = new WalletCreator();

        public walletBundler()
        {
            InitializeComponent();
            displayWallets.LoadWalletsToGrid(1, dataGridViewWallets);
        }

        private void walletBundler_Load(object sender, EventArgs e)
        {
            UpdateSolBalanceLabel();
        }

        private void btnGenWallet_Click(object sender, EventArgs e)
        {
            walletCreator.getwalletqt(btnGenWallet, dataGridViewWallets);
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

        private void btnCheckBalances_Click(object sender, EventArgs e)
        {
            retrieveBalance.GetAllWalletBalances(1);
            displayWallets.LoadWalletsToGrid(1, dataGridViewWallets);
            //UpdateSolBalanceLabel();
        }

        //private async void btnCheckBalances_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Show loading message (optional)
        //        lblSolBalance.Text = "Loading...";

        //        // Asynchronously retrieve wallet balances
        //        await retrieveBalance.GetAllWalletBalancesAsync(1);

        //        // Load wallets into the DataGridView (if it's not asynchronous, leave as-is)
        //        displayWallets.LoadWalletsToGrid(1, dataGridViewWallets);

        //        // Update the balance label asynchronously
        //        await UpdateSolBalanceLabelAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Display error message
        //        lblSolBalance.Text = "Error retrieving balances";
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }
        //}

        private async void UpdateSolBalanceLabel()
        {
            double totalBalance = await retrieveBalance.GetTotalBalance(1);
            lblSolBalance.Text = totalBalance.ToString("N2"); // Format as needed
        }


    }
}
