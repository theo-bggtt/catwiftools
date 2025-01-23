using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using WalletGenerator;

namespace catwiftools.wallet
{
    public partial class walletVolume : UserControl
    {
        displayWallets displayWallets = new displayWallets();

        public walletVolume()
        {
            InitializeComponent();
            displayWallets.LoadWalletsToGrid(2, dataGridViewWallets);
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
