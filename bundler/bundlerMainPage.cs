using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catwiftools.bundler
{
    public partial class bundlerMainPage : UserControl
    {
        public bundlerMainPage()
        {
            InitializeComponent();
        }

        private async void btnTasks_Click(object sender, EventArgs e)
        {
            TokenLauncher.LaunchToken("2jGdoShA2SjkhhjyTE81vqiAm3hvJot3VJw4kaP2z8HjgGQuFmrketzTm12hcAvXp549w9uWP6XuxAb47XbkNwC", "0.005", "Test Token", "TT", "Test Description", "https://example.com", "https://twitter.com/example", "https://t.me/example", @"C:\Users\theo.bggtt\Documents\2024-2025\Atelier_Programmation\sem2\catwiftools\img\logo\1.png");
        }

    }
}
