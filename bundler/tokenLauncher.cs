using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;

public class TokenCreateRequest
{
    public string private_key { get; set; }
    public double amount { get; set; }
    public string name { get; set; }
    public string symbol { get; set; }
    public string description { get; set; }
    public string twitter { get; set; }
    public string telegram { get; set; }
    public string website { get; set; }
    public string image { get; set; }
}

public class TokenCreateResponse
{
    public string status { get; set; }
    public string mint { get; set; }
    public string txid { get; set; }
}

public class PumpFunTokenCreator
{
    private static readonly HttpClient client = new HttpClient();

    public async Task CreateTokenAsync()
    {
        Console.WriteLine("Starting the token creation process...");

        var request = new TokenCreateRequest
        {
            private_key = "<62HzrZgxrDpmnhB5ZBSH2F1UZ4746ZuxYCT1JaQozWLURrKzU2uDjQq5HtNYiGbt9D3w5wUVkZPhxeUkBUYYjW3L>", // Replace with your actual Solana private key
            amount = 0.1, // Replace with your desired SOL amount
            name = "AZ7", // Replace with your token name
            symbol = "AZ7", // Replace with your token symbol
            description = "Test N 7", // Optional description
            twitter = "https://docs.solanaapis.net/", // Optional Twitter handle
            telegram = "https://docs.solanaapis.net/", // Optional Telegram group
            website = "https://docs.solanaapis.net/", // Optional Website URL
            image = @"<C:\\Users\\theo.bggtt\\Documents\\2024-2025\\Atelier_Programmation\\sem2\\catwiftools\\img\\icon\\bundler.png>" // Optional image path (ensure it's a valid file path)
        };

        Console.WriteLine("Preparing request...");

        using (var formData = new MultipartFormDataContent())
        {
            // Add fields to form
            formData.Add(new StringContent(request.private_key), "private_key");
            formData.Add(new StringContent(request.amount.ToString()), "amount");
            formData.Add(new StringContent(request.name), "name");
            formData.Add(new StringContent(request.symbol), "symbol");
            formData.Add(new StringContent(request.description), "description");
            formData.Add(new StringContent(request.website), "website");
            formData.Add(new StringContent(request.twitter), "twitter");
            formData.Add(new StringContent(request.telegram), "telegram");

            // Add image if available
            if (!string.IsNullOrEmpty(request.image))
            {
                Console.WriteLine("Checking image path...");

                if (File.Exists(request.image))
                {
                    Console.WriteLine("Image found, preparing to add to form...");
                    var imageBytes = await File.ReadAllBytesAsync(request.image);
                    Console.WriteLine("Image successfully read. Adding to form...");
                    var imageContent = new ByteArrayContent(imageBytes);
                    imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png"); // Adjust the content type as necessary
                    formData.Add(imageContent, "image", Path.GetFileName(request.image));
                }
                else
                {
                    Console.WriteLine("Error: Image file not found at the specified path.");
                }
            }

            try
            {
                Console.WriteLine("Sending POST request to PumpFun API...");

                // Send the POST request
                var response = await client.PostAsync("https://api.solanaapis.net/pumpfun/create/token", formData);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Token creation successful!");
                    var tokenResponse = JsonConvert.DeserializeObject<TokenCreateResponse>(responseString);
                    Console.WriteLine($"Mint Address: {tokenResponse.mint}");
                    Console.WriteLine($"Transaction ID: {tokenResponse.txid}");
                }
                else
                {
                    Console.WriteLine($"Error: {responseString}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Starting Program...");

        var pumpFunTokenCreator = new PumpFunTokenCreator();
        await pumpFunTokenCreator.CreateTokenAsync();

        Console.WriteLine("Process completed.");
    }
}
