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
        public static void ExecuteBumpItBuyTask(int taskId, List<string> wallets, string mintAddress)
        {
            Random random = new Random();
            var parameters = TaskHelper.GetTaskParameters(taskId);
            // Get the wallet group from the task's group id's wallet group id

            // Parse parameters
            int delay = int.Parse(parameters["Delay"]);
            decimal totalAmount = decimal.Parse(parameters["amount"]);
            bool runIndefinitely = bool.Parse(parameters["run_indefinitely"]);
            int quantityToRepeat = runIndefinitely ? int.MaxValue : int.Parse(parameters["quantity_to_repeat"]);

            // Retrieve wallets in the selected wallet group
            //int walletCount = wallets.Count;

            // Calculate amount per wallet per iteration
            //decimal amountPerWalletPerIteration = totalAmount / quantityToRepeat / walletCount;

            // Execute the task
            for (int i = 0; i < quantityToRepeat; i++)
            {
                //foreach (var wallet in wallets)
                //{
                //    // Make the buy transaction
                //    Thread.Sleep(random.Next(delay - 4, delay + 4) * 1000);
                //    AppState.RecentAction($"BumpItBuy Bought {amountPerWalletPerIteration} from {wallet}");
                //}
                // Update progress
                //UpdateTaskProgress(taskId, i + 1);
            }
        }

        public async static void ExecuteMicroBuyTask(int taskId, List<string> wallets, string mintAddress)
        {
            Random random = new Random();
            var parameters = TaskHelper.GetTaskParameters(taskId);

            // Parse parameters
            int delay = int.Parse(parameters["Delay"]);
            decimal minimum = decimal.Parse(parameters["Minimum Buy"], CultureInfo.InvariantCulture);
            decimal maximum = decimal.Parse(parameters["Maximum Buy"], CultureInfo.InvariantCulture);

            //decimal maximum = decimal.Parse(parameters["Maximum Buy"]);
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
                delay = 5;
            }

            foreach (var wallet in wallets)
            {
                // Make the sell transaction
                Thread.Sleep(random.Next(delay - 4, delay + 4) * 1000);
                //transactionHelper.SellTokens(wallet, mintAddress, 0, 25.0m, cycleAmount);
                
            }
        }

        public static void ExecuteSingleSellTask(int taskId, string mintAddress)
        {
            var parameters = TaskHelper.GetTaskParameters(taskId);
            string wallet = "";
            if (parameters.ContainsKey("wallet"))
            {
                wallet = parameters["wallet"];
            }

            //transactionHelper.SellTokens(wallet, mintAddress, 0, 25, 1);

        }

        public static void ExecuteCommentBotTask(int taskId, List<string> wallets, string mintAddress)
        {
        }
    }
}
