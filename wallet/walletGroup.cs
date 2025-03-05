using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catwiftools.wallet
{
    public partial class walletGroup : UserControl
    {
        public walletGroup()
        {
            InitializeComponent();
        }

        private void walletGroup_Load(object sender, EventArgs e)
        {
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            // Create and show the WalletOptionsForm as a dialog
            using (WalletGroupForm optionsForm = new WalletGroupForm())
            {
                if (optionsForm.ShowDialog() == DialogResult.OK)
                {
                    // Retrieve the values entered in the pop-up form
                    string walletAmount = optionsForm.walletAmount;
                    string groupName = optionsForm.groupName;

                    // Create a new GroupbBox with 2 labels (one for walletAmount and one with groupName) and add that groupbox to flpWalletGroup
                    BorderlessGroupBox borderlessGroupBox = new BorderlessGroupBox();
                    borderlessGroupBox.Size = new Size(260, 160);
                    borderlessGroupBox.Text = "";
                    borderlessGroupBox.ForeColor = Color.White;
                    borderlessGroupBox.BackColor = Color.FromArgb(40, 40, 40);
                    borderlessGroupBox.Margin = new Padding(29);
                    borderlessGroupBox.FlatStyle = FlatStyle.Flat;

                    Label lbAmount = new Label();
                    lbAmount.Text = "Wallet Amount: " + walletAmount;
                    lbAmount.Location = new Point(10, 40);
                    lbAmount.AutoSize = true;

                    Label lbName = new Label();
                    lbName.Text = "Group Name: " + groupName;
                    lbName.Location = new Point(10, 20);
                    lbName.AutoSize = true;

                    borderlessGroupBox.Controls.Add(lbAmount);
                    borderlessGroupBox.Controls.Add(lbName);

                    flpWalletGroup.Controls.Add(borderlessGroupBox);
                }
            }
        }
    }
}
