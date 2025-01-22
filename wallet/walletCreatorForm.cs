using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catwiftools.wallet
{
    public partial class walletCreatorForm : Form
    {
        public int? InputNumber { get; private set; }
        public walletCreatorForm()
        {
            InitializeComponent();

            // Add a TextBox for input
            var textBox = new TextBox { Name = "InputTextBox", Location = new System.Drawing.Point(15, 15), Width = 200 };
            Controls.Add(textBox);

            // Add an OK button
            var okButton = new Button { Text = "OK", Location = new System.Drawing.Point(15, 50), DialogResult = DialogResult.OK };
            okButton.Click += (sender, e) =>
            {
                if (int.TryParse(textBox.Text, out int number))
                {
                    InputNumber = number;
                    Close();
                }
                else
                {
                    MessageBox.Show("Please enter a valid number.");
                }
            };
            Controls.Add(okButton);
        }
    }
}
