using MySqlConnector;
using System;
using System.Data;
using WalletGenerator;

namespace catwiftools.wallet
{
    public partial class walletBundler : UserControl
    {
        displayWallets displayWallets = new displayWallets();
        public walletBundler()
        {
            InitializeComponent();
            displayWallets.LoadWalletsToGrid(1, dataGridViewWallets);
        }


        private void btnGenWallet_Click(object sender, EventArgs e)
        {
            displayWallets.getwalletqt(btnGenWallet, dataGridViewWallets);
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
    }
}
