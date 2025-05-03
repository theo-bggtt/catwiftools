using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace catwiftools.tasks
{
    public class Commenting
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public static string GetCurrentTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
        }

        public static string SignMessage(string base58PrivateKey, string timestamp)
        {
            var account = Account.FromSecretKey(base58PrivateKey);
            string message = $"Sign in to pump.fun: {timestamp}";
            var messageBytes = Encoding.UTF8.GetBytes(message);
            var signature = account.Sign(messageBytes);
            return Convert.ToBase64String(signature);
        }

        public static async Task<string> GetAuthTokenFromPrivateKey(string base58PrivateKey)
        {
            var account = Account.FromSecretKey(base58PrivateKey);
            string walletAddress = account.PublicKey;

            // Register the wallet first (optional, but shown in logs)
            var registerPayload = JsonSerializer.Serialize(new { address = walletAddress });
            var regResponse = await httpClient.PostAsync(
                "https://frontend-api-v3.pump.fun/users/register",
                new StringContent(registerPayload, Encoding.UTF8, "application/json")
            );

            // Timestamp and signed message
            string timestamp = GetCurrentTimestamp();
            string signature = SignMessage(base58PrivateKey, timestamp);

            // Debugging output
            Console.WriteLine("Address: " + walletAddress);
            Console.WriteLine("Timestamp: " + timestamp);
            Console.WriteLine("Signature: " + signature);

            var loginPayload = JsonSerializer.Serialize(new
            {
                address = walletAddress,
                signature = signature,
                timestamp = long.Parse(timestamp)
            });

            var request = new HttpRequestMessage(HttpMethod.Post, "https://frontend-api-v3.pump.fun/auth/login")
            {
                Content = new StringContent(loginPayload, Encoding.UTF8, "application/json")
            };

            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
            request.Headers.Add("Origin", "https://pump.fun");
            request.Headers.Add("Referer", "https://pump.fun");
            request.Headers.Add("Accept", "*/*");

            var response = await httpClient.SendAsync(request);
            string responseText = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Login response: " + responseText);

            using var doc = JsonDocument.Parse(responseText);
            if (doc.RootElement.TryGetProperty("auth_token", out var tokenProp))
            {
                return tokenProp.GetString();
            }

            throw new Exception("auth_token not found in login response.");
        }

        public static async Task<string> PostComment(string authToken, string mintAddress, string commentText)
        {
            var payload = new
            {
                text = commentText,
                mint = mintAddress
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://frontend-api-v3.pump.fun/replies")
            {
                Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json")
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            request.Headers.Add("User-Agent", "Mozilla/5.0");
            request.Headers.Add("Origin", "https://pump.fun");
            request.Headers.Add("Referer", "https://pump.fun");
            request.Headers.Add("Accept", "*/*");

            var response = await httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> CommentAsWallet(string base58PrivateKey, string mintAddress, string commentText)
        {
            string authToken = await GetAuthTokenFromPrivateKey(base58PrivateKey);
            return await PostComment(authToken, mintAddress, commentText);
        }
    }
}
