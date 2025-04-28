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
        public async static void ExecuteBumpItBuyTask(int taskId, List<string> wallets, string mintAddress)
        {
            Random random = new Random();
            var parameters = TaskHelper.GetTaskParameters(taskId);

            // Parse parameters
            int delay = int.Parse(parameters["Delay"]);
            decimal totalAmount = decimal.Parse(parameters["Buy Amount"], CultureInfo.GetCultureInfo("fr-FR"));
            bool runIndefinitely = bool.Parse(parameters["Run Indefinitely"]);

            int quantityToRepeat = runIndefinitely
                ? int.MaxValue
                : int.Parse(parameters["Quantity to Repeat"]);

            int walletCount = wallets.Count;

            // If not indefinite, spread totalAmount across the number of repetitions
            decimal amountPerIteration = runIndefinitely
                ? totalAmount
                : totalAmount / quantityToRepeat;

            // Calculate amount per wallet per iteration
            decimal amountPerWalletPerIteration = amountPerIteration / walletCount;

            int iteration = 0;

            while (iteration < quantityToRepeat)
            {
                AppState.WriteConsole($"Starting BumpItBuy iteration {iteration + 1}...");

                foreach (var wallet in wallets)
                {
                    // Randomise the amount
                    decimal randomAmount = amountPerWalletPerIteration + (decimal)(random.NextDouble() * 0.1 - 0.05);
                    // Make the buy transaction
                    await TransactionHelper.Buy(wallet, mintAddress, randomAmount.ToString(), null);
                    AppState.WriteConsole($"Wallet: {wallet} bought {mintAddress} for {amountPerWalletPerIteration} SOL");

                    // Apply random delay
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


        public async static void ExecuteMicroBuyTask(int taskId, List<string> wallets, string mintAddress)
        {
            Random random = new Random();
            var parameters = TaskHelper.GetTaskParameters(taskId);

            // Parse parameters
            int delay = int.Parse(parameters["Delay"]);
            decimal minimum = decimal.Parse(parameters["Minimum Buy"], CultureInfo.InvariantCulture);
            decimal maximum = decimal.Parse(parameters["Maximum Buy"], CultureInfo.InvariantCulture);

            //bool runIndefinitely = bool.Parse(parameters["run_indefinitely"]);
            //int quantityToRepeat = runIndefinitely ? int.MaxValue : int.Parse(parameters["quantity_to_repeat"]);

            foreach (var wallet in wallets)
            {
                decimal amount = (decimal)(random.NextDouble() * (double)(maximum - minimum) + (double)minimum);
                Console.WriteLine($"Wallet: {wallet} bought {mintAddress} for {amount} SOL");
                //await transactionHelper.BuyTokens(wallet, mintAddress, amount, 25.0m);
                Thread.Sleep(random.Next(delay - 4, delay + 4) * 1000);
                AppState.RecentAction($"MicroBuy Bought {amount} from {wallet}");
            }
        }

        public static void ExecuteGenVolumeTask(int taskId, List<string> wallets, string mintAddress)
        {
            Random random = new Random();
            var parameters = TaskHelper.GetTaskParameters(taskId);
        }

        public static async Task ExecuteSellAllTask(int taskId, List<string> wallets, string mintAddress)
         {
            Random random = new Random();
            var parameters = TaskHelper.GetTaskParameters(taskId);

            int cycleAmount, delay;
            // Parse parameters
            if (parameters.ContainsKey("Cycle"))
            {
                cycleAmount = int.Parse(parameters["Cycle"]);
            }
            else
            {
                cycleAmount = 1;
            }
            if (parameters.ContainsKey("Delay"))
            {
                delay = int.Parse(parameters["Delay"]);
            }
            else
            {
                delay = 0;
            }

            foreach (var wallet in wallets)
            {
                TransactionHelper.Sell(wallet, mintAddress, "0");
                // Make the sell transaction
                if (delay <= 4)
                {
                    Thread.Sleep(delay * 1000);
                } else
                {
                    Thread.Sleep(random.Next(delay - 4, delay + 4) * 1000);
                }
            }
        }

        public static void ExecuteSingleSellTask(int taskId, string mintAddress)
        {
            var parameters = TaskHelper.GetTaskParameters(taskId);
            string wallet = "";
            if (parameters.ContainsKey("Wallets"))
            {
                wallet = parameters["Wallets"];
            }
            string privateKey = walletHelper.GetWalletPrivateKey(wallet);
            TransactionHelper.Sell(privateKey, mintAddress, "0");

        }

        public static void ExecuteCommentBotTask(int taskId, List<string> wallets, string mintAddress)
        {
        }
    }
}
