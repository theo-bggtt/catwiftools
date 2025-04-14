using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

public class PumplifyWarpLauncher
{
    private readonly HttpClient _httpClient;
    private readonly string _wKey;

    public PumplifyWarpLauncher(string wKey)
    {
        _wKey = wKey ?? throw new ArgumentNullException(nameof(wKey));
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.pumplify.fun/")
        };
        _httpClient.DefaultRequestHeaders.Add("X-PUMPLIFY-WKEY", _wKey);
    }

    public async Task<(string Signature, string TokenAddress)> LaunchTokenAsync(
        string tokenName,
        string symbol,
        string metadataUri,
        decimal amount = 0.01m,
        string currency = "sol",
        decimal priorityFee = 0.001m,
        int? percentage = null)
    {
        // Validate parameters
        if (string.IsNullOrWhiteSpace(tokenName))
            throw new ArgumentException("Token name is required");
        if (string.IsNullOrWhiteSpace(symbol))
            throw new ArgumentException("Symbol is required");
        if (string.IsNullOrWhiteSpace(metadataUri))
            throw new ArgumentException("Metadata URI is required");
        if (amount <= 0 && percentage == null)
            throw new ArgumentException("Either amount or percentage must be specified");
        if (percentage.HasValue && (percentage < 1 || percentage > 80))
            throw new ArgumentException("Percentage must be between 1 and 80");

        try
        {
            var requestBody = new
            {
                tokenMetadata = new
                {
                    name = tokenName,
                    symbol,
                    uri = metadataUri
                },
                amount = percentage == null ? amount : (decimal?)null,
                ccy = percentage == null ? currency : null,
                percentage = percentage,
                priorityFee
            };

            var response = await _httpClient.PostAsync(
                "trade/warp/launch",
                new StringContent(JsonConvert.SerializeObject(requestBody),
                Encoding.UTF8,
                "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"API request failed: {response.StatusCode} - {errorContent}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<WarpLaunchResponse>(responseContent);

            Console.WriteLine($"✅ Token launched successfully!");
            Console.WriteLine($"🔗 Transaction: https://solscan.io/tx/{result.Signature}");
            Console.WriteLine($"🚀 Token Address: {result.TokenAddress}");
            Console.WriteLine($"💎 View on pump.fun: https://pump.fun/coin/{result.TokenAddress}");

            return (result.Signature, result.TokenAddress);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Token launch failed: {ex.Message}");
            throw;
        }
    }

    public async Task<string> UploadMetadataAsync(
        string imagePath,
        string tokenName,
        string symbol,
        string description = "",
        string twitterUrl = "",
        string telegramUrl = "",
        string websiteUrl = "")
    {
        try
        {
            using var formData = new MultipartFormDataContent();
            using var imageStream = System.IO.File.OpenRead(imagePath);
            formData.Add(new StreamContent(imageStream), "file", "logo.png");
            formData.Add(new StringContent(tokenName), "name");
            formData.Add(new StringContent(symbol), "symbol");
            formData.Add(new StringContent(description), "description");
            formData.Add(new StringContent(twitterUrl), "twitter");
            formData.Add(new StringContent(telegramUrl), "telegram");
            formData.Add(new StringContent(websiteUrl), "website");

            var response = await _httpClient.PostAsync("https://pump.fun/api/ipfs", formData);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MetadataResponse>(responseContent);

            return result.metadataUri;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Metadata upload failed: {ex.Message}");
            throw;
        }
    }

    private class WarpLaunchResponse
    {
        public string Signature { get; set; }
        public string TokenAddress { get; set; }
    }

    private class MetadataResponse
    {
        public string metadataUri { get; set; }
        public Metadata metadata { get; set; }

        public class Metadata
        {
            public string name { get; set; }
            public string symbol { get; set; }
        }
    }
}