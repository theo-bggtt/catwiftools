using catwiftools.transactions;
using catwiftools.wallet;
using Solnet.Pumpfun;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace catwiftools.tasks
{
    class TasksManager
    {
        public async static void ExecuteBumpItBuyTask(int taskId, List<string> wallets)
        {
            Random random = new Random();
            var parameters = TaskHelper.GetTaskParameters(taskId);

            int delay = int.Parse(parameters["Delay"]);
            decimal totalAmount = decimal.Parse(parameters["Buy Amount"], CultureInfo.GetCultureInfo("fr-FR"));
            bool runIndefinitely = bool.Parse(parameters["Run Indefinitely"]);

            int quantityToRepeat = runIndefinitely
                ? int.MaxValue
                : int.Parse(parameters["Quantity to Repeat"]);

            int walletCount = wallets.Count;

            decimal amountPerIteration = runIndefinitely
                ? totalAmount
                : totalAmount / quantityToRepeat;

            decimal amountPerWalletPerIteration = amountPerIteration / walletCount;

            int iteration = 0;

            while (iteration < quantityToRepeat)
            {
                AppState.WriteConsole($"Starting BumpItBuy iteration {iteration + 1}...");

                foreach (var wallet in wallets)
                {
                    decimal randomAmount = amountPerWalletPerIteration + (decimal)(random.NextDouble() * 0.1 - 0.05);
                    await TransactionHelper.Buy(wallet, ConfigHelper.selectedToken, randomAmount.ToString(), null);
                    AppState.WriteConsole($"Wallet: {wallet} bought {ConfigHelper.selectedToken} for {amountPerWalletPerIteration} SOL");

                    int sleepTime = (delay <= 4)
                        ? delay * 1000
                        : random.Next((delay - 4) * 1000, (delay + 4) * 1000);

                    Thread.Sleep(sleepTime);

                    AppState.RecentAction($"BumpItBuy Bought {amountPerWalletPerIteration} from {wallet}");
                }

                iteration++;

                if (!runIndefinitely && iteration >= quantityToRepeat)
                    break;
            }

            Console.WriteLine("BumpItBuy task completed.");
        }

        public async static void ExecuteMicroBuyTask(int taskId, List<string> wallets)
        {
            Random random = new Random();
            var parameters = TaskHelper.GetTaskParameters(taskId);

            int delay = int.Parse(parameters["Delay"]);
            decimal minimum = decimal.Parse(parameters["Minimum Buy"], CultureInfo.InvariantCulture);
            decimal maximum = decimal.Parse(parameters["Maximum Buy"], CultureInfo.InvariantCulture);

            foreach (var wallet in wallets)
            {
                decimal amount = (decimal)(random.NextDouble() * (double)(maximum - minimum) + (double)minimum);
                Console.WriteLine($"Wallet: {wallet} bought {ConfigHelper.selectedToken} for {amount} SOL");
                await TransactionHelper.Buy(wallet, ConfigHelper.selectedToken, amount.ToString(), null);
                Thread.Sleep(random.Next(delay - 4, delay + 4) * 1000);
                AppState.RecentAction($"MicroBuy Bought {amount} from {wallet}");
            }
        }

        public static void ExecuteGenVolumeTask(int taskId, List<string> wallets)
        {
            Random random = new Random();
            var parameters = TaskHelper.GetTaskParameters(taskId);
        }

        public static async Task ExecuteSellAllTask(int taskId, List<string> wallets)
        {
            Random random = new Random();
            var parameters = TaskHelper.GetTaskParameters(taskId);

            int cycleAmount = parameters.ContainsKey("Cycle") ? int.Parse(parameters["Cycle"]) : 1;
            int delay = parameters.ContainsKey("Delay") ? int.Parse(parameters["Delay"]) : 0;

            foreach (var wallet in wallets)
            {
                TransactionHelper.Sell(wallet, ConfigHelper.selectedToken, "0");

                if (delay <= 4)
                {
                    Thread.Sleep(delay * 1000);
                }
                else
                {
                    Thread.Sleep(random.Next(delay - 4, delay + 4) * 1000);
                }
            }
        }

        public static void ExecuteSingleSellTask(int taskId)
        {
            var parameters = TaskHelper.GetTaskParameters(taskId);
            string wallet = parameters.ContainsKey("Wallets") ? parameters["Wallets"] : "";
            string privateKey = walletHelper.GetWalletPrivateKey(wallet);
            TransactionHelper.Sell(privateKey, ConfigHelper.selectedToken, "0");
        }

        public async static void ExecuteCommentBotTask()
        {
        }

        public static async void StopTask(int taskId)
        {
            AppState.WriteConsole($"Task {taskId} should be stopped.");
        }
    }
}
