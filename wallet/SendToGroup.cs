using catwiftools.tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catwiftools.wallet
{
    public partial class SendToGroup : Form
    {
        private double maxAmount, selectedAmount;
        private List<string> walletAddresses = new List<string>();
        string fundWallet = balanceHelper.getFundAddress();
        private int groupId;
        public SendToGroup(int groupId)
        {
            InitializeComponent();
            DraggingHelper.EnableDragging(this);
            this.groupId = groupId;
        }

        private async void SendToGroup_Load(object sender, EventArgs e)
        {
            Console.WriteLine(groupId);
            walletAddresses = TaskHelper.GetWalletFromGroup(groupId).ToList();
            maxAmount = await balanceHelper.GetWalletBalance(fundWallet);
            maxAmount = Math.Round(maxAmount - (walletAddresses.Count * 0.01), 3);
            updateText();
        }

        private void tbxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (sender as TextBox).Text.IndexOfAny(new char[] { '.', ',' }) > -1)
            {
                e.Handled = true;
            }
        }

        private void tbxAmount_TextChanged(object sender, EventArgs e)
        {
            if (tbxAmount.Text == "")
            {
                selectedAmount = 0;
                hsbAmount.Value = 0;
            }
            else
            {
                // Parse tbxAmount to double

                if (double.TryParse(tbxAmount.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double parsedAmount) && parsedAmount > maxAmount)
                {
                    tbxAmount.Text = maxAmount.ToString(CultureInfo.InvariantCulture);
                    tbxAmount.SelectionStart = tbxAmount.Text.Length;
                    selectedAmount = Math.Round(maxAmount, 3);
                    hsbAmount.Value = 100;
                }
                else
                {
                    selectedAmount = Math.Round(parsedAmount, 3);
                    hsbAmount.Value = (int)(selectedAmount / maxAmount * 100);
                }
            }
            updateText();
        }

        private void hsbAmount_Scroll(object sender, ScrollEventArgs e)
        {
            if (hsbAmount.Value >= 100)
            {
                selectedAmount = maxAmount;
                hsbAmount.Value = 100;
            }
            else
            {
                selectedAmount = Math.Round(maxAmount * hsbAmount.Value / 100, 3);
            }
            updateText();
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void updateText()
        {
            if (selectedAmount == 0)
            {
                btnConfirm.Enabled = false;
            } else
            {
                btnConfirm.Enabled = true;
            }
                lblAmountToSend.Text = $"Amount to send: {Math.Round(selectedAmount, 3)} SOL";
            lblMax.Text = $"Max: {Math.Round(maxAmount, 3)} SOL";
            lblAmountPerWallet.Text = $"Amount per wallet: {Math.Round(selectedAmount / walletAddresses.Count, 3)} SOL";
        }

        private void hsbAmount_ValueChanged(object sender, EventArgs e)
        {
            if (hsbAmount.Value >= 100)
            {
                selectedAmount = maxAmount;
                hsbAmount.Value = 100;
            }
            else
            {
                selectedAmount = Math.Round(maxAmount * hsbAmount.Value / 100, 3);
            }
            tbxAmount.Text = selectedAmount.ToString();
            updateText();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
            DistributeWallets.Distribute(walletAddresses, selectedAmount);
        }
    }
}
