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
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            walletCreator1.Visible = false;
            walletManager1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            walletCreator1.Visible = true;
            walletManager1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            walletManager1.Visible = true;
            walletCreator1.Visible = false;
        }
    }
}
