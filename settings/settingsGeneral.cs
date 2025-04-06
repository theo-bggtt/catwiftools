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
        UiHelper functions = new UiHelper();
        public string fundWallet = "";

        public settingsGeneral()
        {
            InitializeComponent();
        }

        private async void settingsGeneral_Load(object sender, EventArgs e)
        {
            fundWalletSetup();
            double balance = await walletHelper.GetWalletBalance(fundWallet);
            lblFundBalance.Text = Math.Round(balance, 3).ToString();
            AppState.WriteConsole(lblFundBalance.Text);
            // Get the cluster from the .env file
            string envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");
            string[] lines = File.ReadAllLines(envPath);
            string cluster = "";
            if (cluster == "")
            {
                foreach (string line in lines)
                {
                    if (line.StartsWith("CLUSTER="))
                    {
                        cluster = line.Substring("CLUSTER=".Length);
                        break;
                    }
                }
            }
            cbxCluster.SelectedItem = cluster;
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
            fundWallet = walletHelper.CheckForFundWallet();
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

        private void cbxCluster_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Change the cluster in .env to the selected one
                string selectedCluster = cbxCluster.SelectedItem.ToString();
                string envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");

                if (!File.Exists(envPath))
                {
                    MessageBox.Show(".env file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] lines = File.ReadAllLines(envPath);
                bool clusterUpdated = false;

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].StartsWith("CLUSTER="))
                    {
                        lines[i] = "CLUSTER=" + selectedCluster;
                        clusterUpdated = true;
                        break;
                    }
                }

                if (clusterUpdated)
                {
                    File.WriteAllLines(envPath, lines);
                    // Update the cluster in the app
                    AppState.WriteConsole("Cluster changed to: " + selectedCluster);
                }
                else
                {
                    MessageBox.Show("CLUSTER setting not found in .env file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the cluster: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
