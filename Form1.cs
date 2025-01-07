namespace catwiftools
{
    public partial class Form1 : Form
    {
        private WalletCreator walletCreator;

        public Form1()
        {
            InitializeComponent();
            walletCreator = new WalletCreator();
        }

        private void btncreatewallet_Click(object sender, EventArgs e)
        {
            string texte;
            int walletQuantity = Convert.ToInt32(tbxwalletqt.Text);
            if (walletQuantity <= 0)
            {
                texte = "Please enter a valid number of wallets to create.";
            }
            else
            {
                texte = walletCreator.CreateWallets(walletQuantity);

            }
            tbxlog.Text += texte + Environment.NewLine;
        }
    }
}