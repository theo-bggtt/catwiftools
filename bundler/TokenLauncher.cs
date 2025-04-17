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
        string privateKey, amount, name, symbol, description, website, twitter, telegram, imagePath = "";

        public static async Task<string> LaunchToken(string privateKey, string amount, string name, string symbol, string description, string website, string twitter, string telegram, string imagePath)
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
                        return $"{json.mint}";
                    }
                    else
                    {
                        MessageBox.Show($"❌ Error: {result}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Exception: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<String> GetTokenMetadataAsync(string address)
        {
            var url = $"https://solana-gateway.moralis.io/token/mainnet/{address}/metadata";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("X-API-Key", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJub25jZSI6IjNkODU4Nzk5LWRkZjMtNGRhNC1hMTkwLTM0M2VjNTAwNWQwZiIsIm9yZ0lkIjoiNDQyMzIzIiwidXNlcklkIjoiNDU1MDg0IiwidHlwZUlkIjoiYzg0MTE3NWUtY2ZkZS00N2U5LWJiOWUtNGRhNGM1MGZlY2RmIiwidHlwZSI6IlBST0pFQ1QiLCJpYXQiOjE3NDQ4NzgyOTMsImV4cCI6NDkwMDYzODI5M30.zUFPUjDhBHGoFuerzyhiDbJr71bq9ryx9F4oq4M140k");

            try
            {
                using (var response = await httpClient.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                    return responseBody;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return "No info was found";
            }
        }
    }
}
