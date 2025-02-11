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
            fundWallet = functions.CheckForFundWallet();
        }

        private void settingsGeneral_Load(object sender, EventArgs e)
        {
            fundWallet = functions.CheckForFundWallet();
            fundWalletSetup();
        }

        private void btnGenFundWall_Click(object sender, EventArgs e)
        {
            List<string> wallets = new List<string>();
            wallets = WalletCreator.GenWallet(null);
            fundWallet = wallets[0];
            walletCreator.SaveWallets(wallets, btnGenFundWall);
            string walletAddress = functions.CheckForFundWallet();
            lblFundWallAddr.Text = walletAddress;
            Console.WriteLine(walletAddress);
            lblFundWallAddr.Visible = true;
            tbxFundWallet.Visible = false;
        }


        private void btnDelFundWall_Click(object sender, EventArgs e)
        {
            walletCreator.DelWallet(null, null, 1);
            lblFundWallAddr.Visible = false;
            tbxFundWallet.Visible = true;
        }

        public void fundWalletSetup()
        {
            fundWallet = functions.CheckForFundWallet();
            Console.WriteLine(fundWallet);
        }
    }
}
