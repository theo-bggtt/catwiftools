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
    public partial class walletVolume : UserControl
    {
        displayWallets displayWallets = new displayWallets();
        WalletCreator walletCreator = new WalletCreator();
        RetrieveBalance retrieveBalance = new RetrieveBalance();

        public List<string> selectedAddresses = new List<string>();

        public walletVolume()
        {
            InitializeComponent();
            displayWallets.LoadWalletsToGrid(2, dataGridViewWallets);
            lblSolBalance.Text = "Total Balance: " + retrieveBalance.GetTotalBalance(2).ToString("N2") + " SOL";
            lblWalletQt.Text = "Wallet amount: " + displayWallets.GetWallets(2).Rows.Count;

            dataGridViewWallets.ReadOnly = false;

            foreach (DataGridViewColumn column in dataGridViewWallets.Columns)
            {
                if (!(column is DataGridViewCheckBoxColumn))
                {
                    column.ReadOnly = true;
                }
            }
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
