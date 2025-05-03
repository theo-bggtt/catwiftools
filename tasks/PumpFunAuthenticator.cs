using System.Threading.Tasks;
using Microsoft.Playwright;

namespace catwiftools.tasks
{
    public class PumpFunAuthenticator
    {
        public static async Task<string> GetAuthTokenAsync()
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true, // Runs without showing browser window
                Args = new[]
                {
                    "--disable-gpu",
                    "--no-sandbox",
                    "--disable-dev-shm-usage"
                }
            });

            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            // Navigate to pump.fun homepage
            await page.GotoAsync("https://pump.fun", new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });

            // Small wait to ensure page and JS frameworks load
            await page.WaitForTimeoutAsync(2000);

            // Attempt to read auth_token directly from localStorage
            string authToken = await page.EvaluateAsync<string>("() => window.localStorage.getItem('auth_token')");

            await browser.CloseAsync();

            if (string.IsNullOrEmpty(authToken))
            {
                throw new System.Exception("Auth token not found. You must connect your wallet manually at least once.");
            }

            return authToken;
        }
    }
}
