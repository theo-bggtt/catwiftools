using System;
using WalletGenerator;

namespace catwiftools.wallet
{
    public partial class walletBundler : UserControl
    {
        public walletBundler()
        {
            InitializeComponent();
        }


        private void btnGenWallet_Click(object sender, EventArgs e)
        {
            using (var numberInputForm = new walletCreatorForm())
            {
                var result = numberInputForm.ShowDialog();
                if (result == DialogResult.OK && numberInputForm.InputNumber.HasValue)
                {
                    MessageBox.Show($"You entered: {numberInputForm.InputNumber.Value}");
                    WalletCreator.SaveData(numberInputForm.InputNumber.Value, btnGenWallet);

                }
                else
                {
                    MessageBox.Show("Input was canceled.");
                }
                
            }
            

            

            Console.WriteLine("Data saved successfully!");


        }
    }
}
