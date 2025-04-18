using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace catwiftools.bundler
{
    internal class PumpFunApiClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.pumplify.fun";

        public PumpFunApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<BundleResponse> CreateBundleAsync(BundleRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{BaseUrl}/trade/local/bundle", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<BundleResponse>(responseContent);
        }

        public async Task<string> UploadMetadataAsync(MetadataRequest metadata, string imagePath)
        {
            using var content = new MultipartFormDataContent();

            // Add image file
            var imageContent = new StreamContent(File.OpenRead(imagePath));
            content.Add(imageContent, "file", Path.GetFileName(imagePath));

            // Add metadata fields
            content.Add(new StringContent(metadata.Name), "name");
            content.Add(new StringContent(metadata.Symbol), "symbol");

            if (!string.IsNullOrEmpty(metadata.Description))
                content.Add(new StringContent(metadata.Description), "description");
            if (!string.IsNullOrEmpty(metadata.Twitter))
                content.Add(new StringContent(metadata.Twitter), "twitter");
            if (!string.IsNullOrEmpty(metadata.Telegram))
                content.Add(new StringContent(metadata.Telegram), "telegram");
            if (!string.IsNullOrEmpty(metadata.Website))
                content.Add(new StringContent(metadata.Website), "website");

            var response = await _httpClient.PostAsync("https://pump.fun/api/ipfs", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(responseContent);
            return doc.RootElement.GetProperty("metadataUri").GetString();
        }

        public async Task<string> SendBundleToJitoAsync(List<string> signedTransactions)
        {
            var jitoRequest = new
            {
                jsonrpc = "2.0",
                id = 1,
                method = "sendBundle",
                @params = new object[]  // Using @ to escape the reserved keyword
                {
                    signedTransactions,
                    new { encoding = "base64" }
                }
            };

            var json = JsonSerializer.Serialize(jitoRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://mainnet.block-engine.jito.wtf/api/v1/bundles", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(responseContent);
            return doc.RootElement.GetProperty("result").GetString();
        }
    }

    public class BundleRequest
    {
        public double Tip { get; set; } = 0.001;
        public LaunchRequest Launch { get; set; }
        public List<SwapRequest> Swaps { get; set; }
    }

    public class LaunchRequest
    {
        public string PublicKey { get; set; }
        public string Mint { get; set; }
        public TokenMetadata TokenMetadata { get; set; }
        public double Amount { get; set; }
        public string Ccy { get; set; } = "sol";
    }

    public class TokenMetadata
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Uri { get; set; }
    }

    public class SwapRequest
    {
        public string Action { get; set; } = "buy";
        public string PublicKey { get; set; }
        public string Mint { get; set; }
        public double Amount { get; set; }
        public string Ccy { get; set; } = "sol";
        public int Slippage { get; set; } = 50;
        public string Pool { get; set; } = "pump";
    }

    public class BundleResponse
    {
        public List<BundleTransaction> Transactions { get; set; }
    }

    public class BundleTransaction
    {
        public string Base64 { get; set; }
        public string Action { get; set; }
        public List<string> SignersNeeded { get; set; }
    }

    public class MetadataRequest
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public string Twitter { get; set; }
        public string Telegram { get; set; }
        public string Website { get; set; }
    }
}