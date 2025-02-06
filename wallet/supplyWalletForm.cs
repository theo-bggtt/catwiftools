using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace catwiftools.wallet
{
    public partial class supplyWalletForm : Form
    {
        public supplyWalletForm()
        {
            InitializeComponent();
        }

        private async void btnGetMinAmount_Click(object sender, EventArgs e)
        {
        }

        public async Task<double> getMinAmount(System.Windows.Forms.Button pressedButton)
        {
            double min = 0;
            using (var numberInputForm = new supplyWalletForm())
            {
                var result = numberInputForm.ShowDialog();
                btnSubmit.Click += (sender, e) =>
                {
                    if (double.TryParse(tbxAmount.Text, out double number))
                    {
                        MessageBox.Show($"You entered: {number}");
                        min = number;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Input was canceled or invalid.");
                        Close();
                    }
                };
            }
            return min;
        }
    }
}
