using Solnet.Programs;
using Solnet.Rpc.Builders;
using Solnet.Rpc;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using catwiftools.transactions;
using catwiftools.tasks;
using Solnet.Metaplex.Bubblegum.Types;

namespace catwiftools.bundler
{
    public partial class bundlerMainPage : UserControl
    {
        public bundlerMainPage()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        private void bundlerMainPage_Load(object sender, EventArgs e)
        {
            List<string> tokenAddress = TokenHelper.GetTokenAddresses();
            foreach (string Address in tokenAddress)
            {
                Dictionary<string, string> token = TokenHelper.GetTokenInfo(Address);
                //flpTokenList.Controls.Add(TokenHelper.CreateTokenPanel(token["address"], token["name"], token["symbol"], token["description"], token["imageUrl"], token["twitterUrl"], token["telegramUrl"]));
            }
        }

        

        private async void btnTasks_Click(object sender, EventArgs e)
        {
            //string token = TokenLauncher.LaunchToken("2jGdoShA2SjkhhjyTE81vqiAm3hvJot3VJw4kaP2z8HjgGQuFmrketzTm12hcAvXp549w9uWP6XuxAb47XbkNwC", "0.005", "Test Token", "TT", "Test Description", "https://example.com", "https://twitter.com/example", "https://t.me/example", @"C:\Users\theo.bggtt\Documents\2024-2025\Atelier_Programmation\sem2\catwiftools\img\logo\1.png");
            string token = "AeuGfjZa6YRgMz33XMRPLdxGNbr9s5Emj6DPd9unpump";
            string url = $"https://pump.fun/coin/{token}";
            ProcessStartInfo sInfo = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };
            Process.Start(sInfo);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TokenLauncher.GetTokenMetadataAsync("AeuGfjZa6YRgMz33XMRPLdxGNbr9s5Emj6DPd9unpump");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Show the TokenInfo form
            TokenInfo tokenInfoForm = new TokenInfo();
            tokenInfoForm.Show();
            tokenInfoForm.BringToFront();
            tokenInfoForm.Focus();
            // Set the token address in the TokenInfo form
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TransactionHelper.Buy("57b81x5yA4RxQW7RTpdFX6qAvsv22TFReaAcBoGCwYXcK48pcJcTWochgmbU4UBV5JB48yCndpiLpMYE3eST1zp1", "8n8V2YvfVsrRUHnYFQYSXVrngZ47NEALpo2bsjr3pump", "0.005", null);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TransactionHelper.Sell("57b81x5yA4RxQW7RTpdFX6qAvsv22TFReaAcBoGCwYXcK48pcJcTWochgmbU4UBV5JB48yCndpiLpMYE3eST1zp1", "8n8V2YvfVsrRUHnYFQYSXVrngZ47NEALpo2bsjr3pump", "357636");
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string authToken = await PumpFunAuthenticator.GetAuthTokenAsync();
            Console.WriteLine($"Your auth token: {authToken}");

            TasksManager.ExecuteCommentBotTask();
        }

        
    }
}
