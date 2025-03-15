using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catwiftools.tasks
{
    class TasksManager
    {
        public void ExecuteBumpItBuyTask(int taskId)
        {
            Functions functions = new Functions();
            var parameters = TaskHelper.GetTaskParameters(taskId);

            // Parse parameters
            int delay = int.Parse(parameters["delay"]);
            decimal totalAmount = decimal.Parse(parameters["amount"]);
            bool runIndefinitely = bool.Parse(parameters["run_indefinitely"]);
            int quantityToRepeat = runIndefinitely ? int.MaxValue : int.Parse(parameters["quantity_to_repeat"]);
            int walletGroup = int.Parse(parameters["wallet_group"]);

            // Retrieve wallets in the selected wallet group
            var wallets = functions.GetWalletsInGroup(walletGroup);
            int walletCount = wallets.Count;

            // Calculate amount per wallet per iteration
            decimal amountPerWalletPerIteration = totalAmount / quantityToRepeat / walletCount;

            // Execute the task
            for (int i = 0; i < quantityToRepeat; i++)
            {
                foreach (var wallet in wallets)
                {
                    // Make the buy transaction

                    Thread.Sleep(delay * 1000);
                }
                // Update progress
                //UpdateTaskProgress(taskId, i + 1);
            }
        }
    }
}
