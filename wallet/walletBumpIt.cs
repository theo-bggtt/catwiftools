using MySqlConnector;
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
    public partial class walletBumpIt : UserControl
    {
        WalletCreator walletCreator = new WalletCreator();
        displayWallets displayWallets = new displayWallets();
        RetrieveBalance retrieveBalance = new RetrieveBalance();
        public walletBumpIt()
        {
            InitializeComponent();
            displayWallets.LoadWalletsToGrid(3, dataGridViewWallets);
            lblSolBalance.Text = "Total Balance: " + retrieveBalance.GetTotalBalance(3).ToString("N2") + " SOL";
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(3).Rows.Count;
        }

        private void walletBumpIt_Load(object sender, EventArgs e)
        {
            lblSolBalance.Text = "Total Balance: " + retrieveBalance.GetTotalBalance(3).ToString("N2") + " SOL";
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(3).Rows.Count;
        }


        private void btnGenWallet_Click(object sender, EventArgs e)
        {
            walletCreator.getwalletqt(btnGenWallet, dataGridViewWallets);
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(3).Rows.Count;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int scrollValue = e.Delta > 0 ? -1 : 1;
            var verticalScroll = dataGridViewWallets.FirstDisplayedScrollingRowIndex;

            if (verticalScroll + scrollValue >= 0 && verticalScroll + scrollValue < dataGridViewWallets.RowCount)
            {
                dataGridViewWallets.FirstDisplayedScrollingRowIndex += scrollValue;
            }

            base.OnMouseWheel(e);
        }

        private async void btnCheckBalances_Click(object sender, EventArgs e)
        {
            await retrieveBalance.GetAllWalletBalances(3);
            displayWallets.LoadWalletsToGrid(3, dataGridViewWallets);
            lblSolBalance.Text = "Total Balance: " + retrieveBalance.GetTotalBalance(3).ToString("N2") + " SOL";
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(3).Rows.Count;
        }
    }
}
