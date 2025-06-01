using Microsoft.Data.Sqlite;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catwiftools.bundler
{
    internal class TokenHelper
    {

        public static void SaveToken(string address)
        {
            string query = $"INSERT INTO token (address) VALUES ('{address}')";
            using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
            using (SqliteCommand command = new SqliteCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static List<string> GetTokenAddresses()
        {
            List<string> tokenAddresses = new List<string>();
            string query = "SELECT address FROM token";
            using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
            using (SqliteCommand command = new SqliteCommand(query, connection))
            {
                connection.Open();
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tokenAddresses.Add(reader.GetString(0));
                    }
                }
            }
            return tokenAddresses;
        }

        public static Dictionary<string, string> GetTokenInfo(string tokenAddress)
        {
            var token = new Dictionary<string, string>();
            string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJub25jZSI6IjNkODU4Nzk5LWRkZjMtNGRhNC1hMTkwLTM0M2VjNTAwNWQwZiIsIm9yZ0lkIjoiNDQyMzIzIiwidXNlcklkIjoiNDU1MDg0IiwidHlwZUlkIjoiYzg0MTE3NWUtY2ZkZS00N2U5LWJiOWUtNGRhNGM1MGZlY2RmIiwidHlwZSI6IlBST0pFQ1QiLCJpYXQiOjE3NDQ4NzgyOTMsImV4cCI6NDkwMDYzODI5M30.zUFPUjDhBHGoFuerzyhiDbJr71bq9ryx9F4oq4M140k"; // Replace with your Moralis API key
            string url = $"https://solana-gateway.moralis.io/token/mainnet/{tokenAddress}/metadata";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                try
                {
                    // Step 1: Fetch basic metadata
                    var response = client.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode();
                    string json = response.Content.ReadAsStringAsync().Result;
                    JObject coreMeta = JObject.Parse(json);

                    token["name"] = coreMeta["name"]?.ToString() ?? "";
                    token["symbol"] = coreMeta["symbol"]?.ToString() ?? "";
                    token["mint"] = coreMeta["mint"]?.ToString() ?? "";
                    token["standard"] = coreMeta["standard"]?.ToString() ?? "";
                    token["logo"] = coreMeta["logo"]?.ToString() ?? "";
                    token["imageUrl"] = token["logo"]; // Fallback image if none in extended

                    // Step 2: Fetch extended metadata from IPFS/Arweave
                    string metadataUri = coreMeta["metaplex"]?["metadataUri"]?.ToString();
                    if (!string.IsNullOrEmpty(metadataUri))
                    {
                        var metaResponse = client.GetAsync(metadataUri).Result;
                        if (metaResponse.IsSuccessStatusCode)
                        {
                            string extendedJson = metaResponse.Content.ReadAsStringAsync().Result;
                            JObject extendedMeta = JObject.Parse(extendedJson);

                            token["description"] = extendedMeta["description"]?.ToString() ?? "";
                            token["imageUrl"] = extendedMeta["image"]?.ToString() ?? token["logo"];

                            // Optional: Twitter / Telegram
                            token["twitterUrl"] = extendedMeta["twitter"]?.ToString() ?? "";
                            token["telegramUrl"] = extendedMeta["telegram"]?.ToString() ?? "";
                        }
                        else
                        {
                            token["description"] = "";
                            token["twitterUrl"] = "";
                            token["telegramUrl"] = "";
                        }
                    }
                    else
                    {
                        token["description"] = "";
                        token["twitterUrl"] = "";
                        token["telegramUrl"] = "";
                    }
                }
                catch (Exception ex)
                {
                    token["name"] = "Error";
                    token["symbol"] = "ERR";
                    token["description"] = ex.Message;
                    token["imageUrl"] = ""; // You could use a placeholder image
                    token["twitterUrl"] = "";
                    token["telegramUrl"] = "";
                }
            }

            return token;
        }


        public static Panel CreateTokenPanel(string address, string name, string symbol, string description, string imageUrl, string twitterUrl, string telegramUrl)
        {
            Panel tokenPanel = new Panel
            {
                Size = new Size(150, 35),
                BackColor = Color.FromArgb(40, 40, 40),
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10),
                Name = address,
            };

            PictureBox pictureBox1 = new PictureBox
            {
                Location = new Point(117, 0),
                Name = "pictureBox1",
                Size = new Size(30, 30),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.None,
                TabIndex = 45,
                TabStop = false
            };

            Label nameLabel = new Label
            {
                Location = new Point(5, 27),
                Text = name,
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft
            };

            tokenPanel.MouseEnter += (s, e) => tokenPanel.BackColor = Color.FromArgb(60, 60, 60);
            tokenPanel.MouseLeave += (s, e) => tokenPanel.BackColor = Color.FromArgb(40, 40, 40);
            pictureBox1.MouseEnter += (s, e) => tokenPanel.BackColor = Color.FromArgb(60, 60, 60);
            pictureBox1.MouseLeave += (s, e) => tokenPanel.BackColor = Color.FromArgb(40, 40, 40);
            nameLabel.MouseEnter += (s, e) => tokenPanel.BackColor = Color.FromArgb(60, 60, 60);
            nameLabel.MouseLeave += (s, e) => tokenPanel.BackColor = Color.FromArgb(40, 40, 40);

            tokenPanel.Click += (s, e) => tokenInstance.pnlTokenPanel_Click(s, e);
            pictureBox1.Click += (s, e) => tokenInstance.pnlTokenPanel_Click(s, e);
            nameLabel.Click += (s, e) => tokenInstance.pnlTokenPanel_Click(s, e);

            try
            {
                if (!string.IsNullOrEmpty(imageUrl))
                    pictureBox1.Load(imageUrl);
            }
            catch
            {
                string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img");
                string imagePath = Path.Combine(basePath, "defaultToken.png");
                pictureBox1.Image = Image.FromFile(imagePath);
            }

            tokenPanel.Controls.Add(pictureBox1);
            tokenPanel.Controls.Add(nameLabel);

            return tokenPanel;
        }



        public static string loadTokenName(string address)
        {
            Dictionary<string, string> token = TokenHelper.GetTokenInfo(address);
            return token["name"];
        }
    }
}
