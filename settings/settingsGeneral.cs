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

        private void settingsGeneral_Load(object sender, EventArgs e)
        {
            fundWallet = functions.CheckForFundWallet();
            Console.WriteLine(fundWallet);

            if (fundWallet != "")
            {
                lblFundWallAddr.Visible = true;
                tbxFundWallet.Visible = false;
            }
            else
            {
                tbxFundWallet.Visible = true;
                lblFundWallAddr.Visible = false;
            }
        }

        private void btnGenFundWall_Click(object sender, EventArgs e)
        {
            Console.WriteLine(fundWallet);
            WalletCreator.SaveWallet(1, btnGenFundWall);
            fundWallet = functions.CheckForFundWallet();
            Console.WriteLine(fundWallet);
            lblFundWallAddr.Visible = true;
            tbxFundWallet.Visible = false;
        }

        private void btnDelFundWall_Click(object sender, EventArgs e)
        {
            fundWallet = functions.CheckForFundWallet();
            walletCreator.DelWallet(fundWallet, null);
            fundWallet = functions.CheckForFundWallet();
            Console.WriteLine(fundWallet);
            tbxFundWallet.Visible = true;
            lblFundWallAddr.Visible = false;

        }

        
    }
}
