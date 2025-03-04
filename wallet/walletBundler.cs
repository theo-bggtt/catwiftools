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
        RetrieveBalance retrieveBalance = new RetrieveBalance();
        WalletCreator walletCreator = new WalletCreator();

        public List<string> selectedAddresses = new List<string>();

        public walletBundler()
        {
            InitializeComponent();            
        }

        private void walletBundler_Load(object sender, EventArgs e)
        {
            displayWallets.LoadWalletsToGrid(3, dataGridViewWallets);
            lblSolBalance.Text = "Total Balance: " + retrieveBalance.GetTotalBalance(3).ToString("N2") + " SOL";
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(3).Rows.Count;
        }

        private void dataGridViewWallets_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dataGridViewWallets.IsCurrentCellDirty)
            {
                dataGridViewWallets.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridViewWallets_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                var row = dataGridViewWallets.Rows[e.RowIndex];
                var address = row.Cells[2].Value.ToString();

                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    if (!selectedAddresses.Contains(address))
                    {
                        selectedAddresses.Add(address);
                    }
                }
                else
                {
                    selectedAddresses.Remove(address);
                }

                Console.WriteLine(address);
            }
        }

        private async void btnGenWallet_Click(object sender, EventArgs e)
        {
            await walletCreator.getwalletqt(btnGenWallet, dataGridViewWallets);
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(3).Rows.Count;
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
            await retrieveBalance.GetAllWalletBalances(3);
            lblSolBalance.Text = "Total Balance: " + retrieveBalance.GetTotalBalance(3).ToString("N2") + " SOL";
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(3).Rows.Count;
            displayWallets.LoadWalletsToGrid(3, dataGridViewWallets);
        }
    }
}
