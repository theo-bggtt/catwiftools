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
            retrieveBalance.GetAllWalletBalances(3);
            displayWallets.LoadWalletsToGrid(3, dataGridViewWallets);
            lblSolBalance.Text = "Total Balance: " + retrieveBalance.GetTotalBalance(3).ToString("N2") + " SOL";
        }

        private void walletBumpIt_Load(object sender, EventArgs e)
        {
            lblSolBalance.Text = "Total Balance: " + retrieveBalance.GetTotalBalance(3).ToString("N2") + " SOL";
        }
    }
}
