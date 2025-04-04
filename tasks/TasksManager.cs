using catwiftools.transactions;
using catwiftools.wallet;
using Solnet.Pumpfun;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
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

        public static void ExecuteMicroBuyTask(int taskId, List<string> wallets, string mintAddress)
        {
            Random random = new Random();
            var parameters = TaskHelper.GetTaskParameters(taskId);
            //List<string> wallets = TaskHelper.GetWalletsFromTaskId(taskId);
        }

        public static void ExecuteGenVolumeTask(int taskId, List<string> wallets, string mintAddress)
        {
            Random random = new Random();
            var parameters = TaskHelper.GetTaskParameters(taskId);
            //List<string> wallets = TaskHelper.GetWalletsFromTaskId(taskId);
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
                transactionHelper.SellTokens(wallet, mintAddress, 0, 25, cycleAmount);
                
            }
        }

        public static void ExecuteSingleSellTask(int taskId, List<string> wallets, string mintAddress)
        {
            foreach (var wallet in wallets)
            {
                transactionHelper.SellTokens(wallet, mintAddress, 0, 25, 1);
            }

        }

        public static void ExecuteCommentBotTask(int taskId, List<string> wallets, string mintAddress)
        {
        }
    }
}
