using MySqlConnector;
using Solnet.Rpc;
using Solnet.Wallet;
using System;
using System.Data;
using WalletGenerator;
using Solnet.Rpc.Types;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Text;

namespace catwiftools.wallet
{
    public partial class walletBundler : UserControl
    {
        private const string HeliusApiKey = "300e94e7-9909-4a9d-9a4e-24088e7c065b"; // Replace with your API key
        private static readonly string heliusUrl = $"https://devnet.helius-rpc.com/?api-key={HeliusApiKey}";
        displayWallets displayWallets = new displayWallets();
        private List<Wallet> wallets;
        public walletBundler()
        {
            InitializeComponent();
            displayWallets.LoadWalletsToGrid(1, dataGridViewWallets);
        }


        private void btnGenWallet_Click(object sender, EventArgs e)
        {
            displayWallets.getwalletqt(btnGenWallet, dataGridViewWallets);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            // Adjust scrolling based on mouse wheel delta
            int scrollValue = e.Delta > 0 ? -1 : 1; // -1 for up, 1 for down
            var verticalScroll = dataGridViewWallets.FirstDisplayedScrollingRowIndex;

            // Update scrolling, ensuring it stays within bounds
            if (verticalScroll + scrollValue >= 0 && verticalScroll + scrollValue < dataGridViewWallets.RowCount)
            {
                dataGridViewWallets.FirstDisplayedScrollingRowIndex += scrollValue;
            }
            base.OnMouseWheel(e);
        }


        private async void btnCheckBalances_Click(object sender, EventArgs e)
        {
            string walletAddress = txtWalletAddress.Text.Trim(); // Get wallet address from a textbox
            if (string.IsNullOrEmpty(walletAddress))
            {
                MessageBox.Show("Please enter a valid wallet address.");
                return;
            }

            try
            {
                // Await the result from the asynchronous method
                var balance = await GetWalletBalance(walletAddress);

                // Update the UI with the result
                MessageBox.Show($"Wallet Balance: {balance:F9} SOL"); // Use :F9 to display up to 9 decimal places
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching wallet balance: {ex.Message}");
            }
        }

        public static async Task<double> GetWalletBalance(string walletAddress)
        {
            using (var httpClient = new HttpClient())
            {
                var requestPayload = new
                {
                    jsonrpc = "2.0",
                    id = 1,
                    method = "getBalance",
                    @params = new object[] { walletAddress }
                };

                var jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(requestPayload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                try
                {
                    var response = await httpClient.PostAsync(heliusUrl, content);
                    response.EnsureSuccessStatusCode();

                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var result = JObject.Parse(jsonResponse);

                    // Corrected path to access the balance
                    var balanceInLamports = result["result"]?["value"]?.Value<long>() ?? 0;

                    // Convert lamports to SOL
                    return balanceInLamports / 1_000_000_000.0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving wallet balance: {ex.Message}");
                    throw; // Re-throw the exception to handle it in the caller method
                }
            }
        }
    }
}