using catwiftools.wallet;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace catwiftools.settings
{
    public partial class settingsGeneral : UserControl
    {
        WalletCreator walletCreator = new WalletCreator();
        Functions functions = new Functions();
        public string fundWallet = "";

        public settingsGeneral()
        {
            InitializeComponent();
        }

        private async void settingsGeneral_Load(object sender, EventArgs e)
        {
            fundWalletSetup();
            double balance = await walletHelper.GetWalletBalance(fundWallet);
            lblFundBalance.Text = Math.Round(balance,3).ToString();
            Console.WriteLine(lblFundBalance.Text);
        }


        private void btnGenFundWall_Click(object sender, EventArgs e)
        {
            List<string> wallets = new List<string>();
            wallets = WalletCreator.GenWallet(null);
            fundWallet = wallets[0];
            walletCreator.SaveWallets(wallets, 0);
            fundWalletSetup();
        }


        private void btnDelFundWall_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the fund wallet?", "Delete Fund Wallet", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                walletCreator.DelWallet(null, null, 0);
                fundWalletSetup();
            }

        }

        public void fundWalletSetup()
        {
            fundWallet = Functions.CheckForFundWallet();
            if (fundWallet != "")
            {
                lblFundWallAddr.Text = fundWallet;
                lblFundWallAddr.Visible = true;
                tbxFundWallet.Visible = false;
                btnDelFundWall.Visible = true;
                btnGenFundWall.Visible = false;
            }
            else
            {
                lblFundWallAddr.Visible = false;
                tbxFundWallet.Visible = true;
                btnDelFundWall.Visible = false;
                btnGenFundWall.Visible = true;
            }
        }
    }
}
