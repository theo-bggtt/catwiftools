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
    public partial class WalletGroupForm : Form
    {
        public string walletAmount { get; private set; }
        public string groupName { get; private set; }

        private bool _isAmountValid = false;
        private bool _isNameValid = false;

        public WalletGroupForm()
        {
            InitializeComponent();

        }

        private void tbxAmount_TextChanged(object sender, EventArgs e) // Check if the amount is valid
        {
            if (string.IsNullOrWhiteSpace(tbxAmount.Text))
            {
                _isAmountValid = false;
            }
            else if (int.TryParse(tbxAmount.Text, out _))
            {
                if (int.Parse(tbxAmount.Text) > 0)
                {
                    _isAmountValid = true;
                }
            }
            else
            {
                _isAmountValid = false;
            }

            btnCreate.Enabled = _isAmountValid && _isNameValid;
        }

        private void tbxAmount_KeyPress(object sender, KeyPressEventArgs e) // Only allow numbers
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxName_TextChanged(object sender, EventArgs e) // Check if the name is empty
        {
            if (string.IsNullOrWhiteSpace(tbxName.Text))
            {
                _isNameValid = false;
            }
            else
            {
                _isNameValid = true;
            }

            btnCreate.Enabled = _isAmountValid && _isNameValid;
        }

        private void btnCreate_Click(object sender, EventArgs e) // Confirm and close
        {
            walletAmount = tbxAmount.Text;
            groupName = tbxName.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) // Cancel and close
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }
    }
}
