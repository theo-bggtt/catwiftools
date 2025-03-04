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

        public List<string> selectedAddresses = new List<string>();

        public walletBumpIt()
        {
            InitializeComponent();
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

        private void walletBumpIt_Load(object sender, EventArgs e)
        {
            displayWallets.LoadWalletsToGrid(4, dataGridViewWallets);
            lblSolBalance.Text = "Total Balance: " + retrieveBalance.GetTotalBalance(4).ToString("N2") + " SOL";
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(4).Rows.Count;
        }

        private async void btnGenWallet_Click(object sender, EventArgs e)
        {
            await walletCreator.getwalletqt(btnGenWallet, dataGridViewWallets);
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(4).Rows.Count;
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
            await retrieveBalance.GetAllWalletBalances(4);
            displayWallets.LoadWalletsToGrid(4, dataGridViewWallets);
            lblSolBalance.Text = "Total Balance: " + retrieveBalance.GetTotalBalance(4).ToString("N2") + " SOL";
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(4).Rows.Count;
        }

        private async void btnSplyWall_Click(object sender, EventArgs e)
        {
            Console.WriteLine(selectedAddresses.Count);
            await DistributeWallets.Distribute(selectedAddresses);
            Console.WriteLine("Clicked");
        }

        private async void btnRecallWall_Click(object sender, EventArgs e)
        {
            await DistributeWallets.Recall(selectedAddresses);
        }
    }
}
