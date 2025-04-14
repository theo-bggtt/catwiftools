using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json;


public class WalletData
{
    public string WKey { get; set; }
    public string PublicKey { get; set; }
    public string PrivateKey { get; set; }
}

public class PumpTokenLauncher
{
    private static readonly HttpClient client = new HttpClient();

    // STEP 1: Create a new wallet
    public static async Task<WalletData> CreateWalletAsync()
    {
        var response = await client.GetAsync("https://api.pumplify.fun/wallets/new");
        var json = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception("Wallet creation failed: " + json);

        dynamic data = JsonConvert.DeserializeObject(json);

        return new WalletData
        {
            WKey = data.wKey,
            PublicKey = data.wallet.publicKey,
            PrivateKey = data.wallet.privateKey
        };
    }

    // STEP 2: Import an existing wallet using base58 private key
    public static async Task<WalletData> ImportWalletAsync(string base58PrivateKey)
    {
        var body = new
        {
            privateKey = base58PrivateKey
        };

        var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://api.pumplify.fun/wallets/import", content);
        var json = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception("Wallet import failed: " + json);

        dynamic data = JsonConvert.DeserializeObject(json);
        return new WalletData
        {
            WKey = data.wKey,
            PublicKey = data.wallet.publicKey,
            PrivateKey = data.wallet.privateKey
        };
    }

    public static async Task<string> UploadMetadataAsync(string name, string symbol, string description, string twitter, string telegram, string website, string logoPath)
    {
        Console.WriteLine("[UploadMetadataAsync] Début");

        var metadata = new
        {
            name = name,
            symbol = symbol,
            description = description,
            extensions = new
            {
                twitter = twitter,
                telegram = telegram,
                website = website
            }
        };

        string jsonMetadata = JsonConvert.SerializeObject(metadata);

        using (var client = new HttpClient())
        using (var content = new MultipartFormDataContent())
        {
            // Ajout du JSON (métadonnées sans image)
            var jsonPart = new StringContent(jsonMetadata, Encoding.UTF8, "application/json");
            content.Add(jsonPart, "data");

            // Ajout de l'image (en tant que fichier)
            byte[] imageBytes = await File.ReadAllBytesAsync(logoPath);
            var imageContent = new ByteArrayContent(imageBytes);
            imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            content.Add(imageContent, "image", Path.GetFileName(logoPath));

            Console.WriteLine("[UploadMetadataAsync] Requête POST vers https://pump.fun/api/ipfs");

            var response = await client.PostAsync("https://pump.fun/api/ipfs", content);
            string responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"[UploadMetadataAsync] Statut HTTP: {response.StatusCode}");
            Console.WriteLine($"[UploadMetadataAsync] Réponse: {responseString}");

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Metadata upload failed: {response.StatusCode} - {responseString}");

            using (JsonDocument json = JsonDocument.Parse(responseString))
            {
                var uri = json.RootElement.GetProperty("uri").GetString();
                Console.WriteLine($"[UploadMetadataAsync] Metadata URI: {uri}");
                return uri;
            }
        }
    }




    // STEP 4: Launch the token using warp transaction
    public static async Task LaunchTokenAsync(WalletData wallet, string name, string symbol, string metadataUri, double devBuyAmount = 1, double priorityFee = 0.001)
    {
        var launchPayload = new
        {
            tokenMetadata = new
            {
                name = name,
                symbol = symbol,
                uri = metadataUri
            },
            amount = devBuyAmount,
            ccy = "sol",
            priorityFee = priorityFee
        };

        var content = new StringContent(JsonConvert.SerializeObject(launchPayload), Encoding.UTF8, "application/json");
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        client.DefaultRequestHeaders.Remove("X-PUMPLIFY-WKEY");
        client.DefaultRequestHeaders.Add("X-PUMPLIFY-WKEY", wallet.WKey);

        var response = await client.PostAsync("https://api.pumplify.fun/trade/warp/launch", content);
        var json = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception("Token launch failed: " + json);

        dynamic data = JsonConvert.DeserializeObject(json);
        Console.WriteLine($"🚀 Transaction: https://solscan.io/tx/{data.signature}");
        Console.WriteLine($"🌐 pump.fun page: https://pump.fun/coin/{data.ca}");
    }
}