using catwiftools.tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            //maxAmount = await balanceHelper.GetWalletBalance(fundWallet);
            maxAmount = Math.Round(5.2 - (walletAddresses.Count * 0.01),3);
            updateText();
        }

        private void tbxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
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
                if (double.Parse(tbxAmount.Text) > maxAmount)
                {
                    tbxAmount.Text = maxAmount.ToString();
                    tbxAmount.SelectionStart = tbxAmount.Text.Length;
                    selectedAmount = Math.Round(maxAmount, 3);
                    hsbAmount.Value = 100;
                }
                else
                {
                    selectedAmount = Math.Round(double.Parse(tbxAmount.Text), 3);
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
            AppState.WriteConsole(hsbAmount.Value.ToString());
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
            lblAmountToSend.Text = $"Amount to send: {Math.Round(selectedAmount,3)} SOL";
            lblMax.Text = $"Max: {Math.Round(maxAmount,3)} SOL";
            lblAmountPerWallet.Text = $"Amount per wallet: {Math.Round(selectedAmount / walletAddresses.Count, 3)} SOL";
        }
    }
}
