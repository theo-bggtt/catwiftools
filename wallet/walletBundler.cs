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
            lblSolBalance.Text = "Total Balance: " + retrieveBalance.GetTotalBalance(1).ToString("N2") + " SOL";
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(3).Rows.Count;
        }

        private void walletBundler_Load(object sender, EventArgs e)
        {
            lblSolBalance.Text = "Total Balance: " + retrieveBalance.GetTotalBalance(1).ToString("N2") + " SOL";
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(3).Rows.Count;
        }

        private void btnGenWallet_Click(object sender, EventArgs e)
        {
            walletCreator.getwalletqt(btnGenWallet, dataGridViewWallets);
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(1).Rows.Count;
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
            await retrieveBalance.GetAllWalletBalances(1);
            displayWallets.LoadWalletsToGrid(1, dataGridViewWallets);
            lblSolBalance.Text = "Total Balance: " + retrieveBalance.GetTotalBalance(1).ToString("N2") + " SOL";
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(1).Rows.Count;
        }
    }
}
