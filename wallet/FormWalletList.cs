﻿using catwiftools.tasks;
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
    public partial class FormWalletList : Form
    {
        public FormWalletList()
        {
            InitializeComponent();
            DraggingHelper.EnableDragging(this);
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormWalletList_Load(object sender, EventArgs e)
        {
            flpWallets.Controls.Clear();

            int group_id = walletGroup.group_id;
            string[] walletsArray = TaskHelper.GetWalletFromGroup(group_id: group_id);
            List<string> wallets = new List<string>(walletsArray);
            foreach (string walletAddress in wallets)
            {
                createGroupBoxWallet(walletAddress);
                flpWallets.Controls.Add(gbxWallet);
            }
        }

        private async void createGroupBoxWallet(string walletAddress)
        {
            var balancea = await RetrieveBalance.GetWalletBalance(walletAddress);
            string balance = balancea.ToString();

            gbxWallet = new BorderlessGroupBox();
            lblWalletAddress = new Label();
            btnExport = new Button();
            lblBalance = new Label();
            // 
            // gbxWallet
            // 
            gbxWallet.BackColor = Color.FromArgb(40, 40, 40);
            gbxWallet.Controls.Add(lblBalance);
            gbxWallet.Controls.Add(btnExport);
            gbxWallet.Controls.Add(lblWalletAddress);
            gbxWallet.Location = new Point(0, 5);
            gbxWallet.Margin = new Padding(0, 5, 0, 5);
            gbxWallet.Name = "gbxWallet";
            gbxWallet.Size = new Size(700, 36);
            gbxWallet.TabIndex = 0;
            gbxWallet.TabStop = false;
            // 
            // lblWalletAddress
            // 
            lblWalletAddress.AutoSize = true;
            lblWalletAddress.ForeColor = Color.White;
            lblWalletAddress.Location = new Point(18, 10);
            lblWalletAddress.Name = "lblWalletAddress";
            lblWalletAddress.Size = new Size(36, 15);
            lblWalletAddress.TabIndex = 0;
            lblWalletAddress.Text = walletAddress;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(78, 93, 148);
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(587, 6);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(97, 23);
            btnExport.TabIndex = 5;
            btnExport.Text = "Export Key";
            btnExport.UseVisualStyleBackColor = false;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.ForeColor = Color.White;
            lblBalance.Location = new Point(472, 10);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(36, 15);
            lblBalance.TabIndex = 6;
            lblBalance.Text = balance;

            flpWallets.Controls.Add(gbxWallet);

        }
    }
}
