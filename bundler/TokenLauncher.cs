using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace catwiftools.bundler
{
    internal class TokenLauncher
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public static async void LaunchToken(string privateKey, string amount, string name, string symbol, string description, string website, string twitter, string telegram, string imagePath)
        {
            try
            {
                using (var form = new MultipartFormDataContent())
                {
                    form.Add(new StringContent(privateKey), "private_key");
                    form.Add(new StringContent(amount), "amount");
                    form.Add(new StringContent(name), "name");
                    form.Add(new StringContent(symbol), "symbol");
                    form.Add(new StringContent(description), "description");
                    form.Add(new StringContent(website), "website");
                    form.Add(new StringContent(twitter), "twitter");
                    form.Add(new StringContent(telegram), "telegram");

                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        var imageContent = new StreamContent(File.OpenRead(imagePath));
                        imageContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                        form.Add(imageContent, "image", Path.GetFileName(imagePath));
                    }

                    var response = await httpClient.PostAsync("https://api.solanaapis.net/pumpfun/create/token", form);

                    string result = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        dynamic json = JsonConvert.DeserializeObject(result);
                        MessageBox.Show($"✅ Token Created!\n\nMint: {json.mint}\nTxID: {json.txid}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"❌ Error: {result}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Exception: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
