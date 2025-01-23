using MySqlConnector;
using Solnet.Rpc;
using Solnet.Wallet;
using System;
using System.Data;
using WalletGenerator;
using Solnet.Rpc.Types;

namespace catwiftools.wallet
{
    public partial class walletBundler : UserControl
    {
        displayWallets displayWallets = new displayWallets();
        retreiveBalance retreiveBalance = new retreiveBalance();
        private List<Wallet> wallets;
        public walletBundler()
        {
            InitializeComponent();
            displayWallets.LoadWalletsToGrid(1, dataGridViewWallets);
            wallets = new List<Wallet>
            {
                new Wallet { PublicKey = "BUFknjgKBLHhbn3hWVY2f5qnxnxH5yREyfpVp5NNMUu2" },
                new Wallet { PublicKey = "Cpo3xPS58ZG5xvv8k45dXTAPY5Taa2T5eEDDfBUE4Chq" },
                // Add more wallets as needed
            };
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



        private async void btnCheckBalances_Click(object sender, EventArgs e)
        {
            retreiveBalance.checkBalance();
        }


    }

    public class Wallet
    {
        public string PublicKey { get; set; }
        public decimal Balance { get; set; }
    }
}