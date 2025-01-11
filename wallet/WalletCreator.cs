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

namespace catwiftools
{
    public partial class WalletCreator : UserControl
    {
        public WalletCreator()
        {
            InitializeComponent();
        }

        private void btnbundlewalletcreation_Click(object sender, EventArgs e)
        {
            int walletType = 1;
            int walletqt = Convert.ToInt32(tbxbundlewalletcreation.Text);
            tbxlog.Text += "Creating wallet." + Environment.NewLine;
            string wallet = WalletCreatorScript.CreateWallets(walletqt, walletType);
            tbxlog.Text += wallet;
        }

        private void btndevwalletcreation_Click(object sender, EventArgs e)
        {
            int walletType = 2;
            tbxlog.Text += "Creating Dev wallet." + Environment.NewLine;
            string wallet = WalletCreatorScript.CreateWallets(1, walletType);
            tbxlog.Text += wallet;

        }
    }
}
