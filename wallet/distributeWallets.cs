using Solnet.Programs;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Wallet;
using System;
using System.Threading.Tasks;

namespace catwiftools.wallet
{
    internal class DistributeWallets
    {
        Functions Functions = new Functions();
        // These private keys and public keys are all empty and the solana used is on DevNet, no harm can be done to these wallets, they are used for TEST ONLY!
        public static async Task Distribute(List<String>selectedAddresses, double selectedAmount)
        {
            double amountPerWall = (selectedAmount / selectedAddresses.Count - (selectedAddresses.Count*0.01));
            AppState.WriteConsole($"Amount per wallet to send: {amountPerWall}");
            for (int i = 0; i < selectedAddresses.Count; i++)
            {
                await new DistributeWallets().SendSol(selectedAddresses[i], amountPerWall);
            }
        }

        public static async Task Recall(List<String> selectedAddresses)
        {
            foreach (string address in selectedAddresses)
            {
                await new DistributeWallets().RecallSol(address);
            }
        }

        private async Task RecallSol(string address)
        {
            try
            {
                var rpcClient = ClientFactory.GetClient(Cluster.DevNet);

                // Get the wallet mnemonic or private key from the database
                string privateKeyString = Functions.GetWalletphrase(null, address);

                // Ensure correct wallet initialization
                Wallet wallet;
                if (privateKeyString.Contains(" ")) // Check if it's a mnemonic
                {
                    wallet = new Wallet(privateKeyString);
                }
                else
                {
                    byte[] privateKeyBytes = Convert.FromBase64String(privateKeyString); // Ensure correct format
                    wallet = new Wallet(privateKeyBytes);
                }

                PublicKey fromAccount = wallet.Account.PublicKey;
                PublicKey toAccount = new PublicKey(Functions.CheckForFundWallet());

                // Check balance
                var balanceResponse = await rpcClient.GetBalanceAsync(fromAccount);
                AppState.WriteConsole($"🔎 Sending amount: {balanceResponse.Result.Value / 1_000_000_000.0} SOL");

                // Fetch latest block hash
                var blockHashResponse = await rpcClient.GetLatestBlockHashAsync();
                if (!blockHashResponse.WasSuccessful)
                {
                    AppState.WriteConsole("❌ Failed to fetch latest block hash.");
                    return;
                }
                string blockHash = blockHashResponse.Result.Value.Blockhash;
                AppState.WriteConsole($"🔎 Blockhash: {blockHash}");

                ulong amountLamports = balanceResponse.Result.Value - 5000;

                // Build transaction
                var tx = new TransactionBuilder()
                    .SetRecentBlockHash(blockHash)
                    .SetFeePayer(fromAccount)
                    .AddInstruction(MemoProgram.NewMemo(fromAccount, "Hello from CatWifTools :)"))
                    .AddInstruction(SystemProgram.Transfer(fromAccount, toAccount, amountLamports))
                    .Build(wallet.Account); // Ensure proper signing

                // Send transaction
                var firstSig = await rpcClient.SendTransactionAsync(tx);
                AppState.WriteConsole($"✅ Transaction Sent! Signature: {firstSig.Result}");

                if (!firstSig.WasSuccessful)
                {
                    AppState.WriteConsole($"❌ Transaction Failed: {firstSig.Reason}");
                    AppState.WriteConsole($"❌ Full Response: {firstSig.RawRpcResponse}");
                }
            }
            catch (Exception ex)
            {
                AppState.WriteConsole($"❌ Error: {ex.Message}");
            }
        }


        private async Task SendSol(string address, double amount)
        {
            try
            {
                var rpcClient = ClientFactory.GetClient(Cluster.DevNet);
                string privateKey = Functions.GetWalletphrase(null, Functions.CheckForFundWallet());
                Wallet wallet = new Wallet(privateKey);
                PublicKey fromAccount = wallet.Account.PublicKey;
                PublicKey toAccount = new PublicKey(address);

                AppState.WriteConsole($"🔎 Amount Sending: {amount} SOL");
                
                ulong amountLamports = (ulong)((amount * 1_000_000_000.0) - 5000);


                var blockHashResponse = await rpcClient.GetLatestBlockHashAsync();
                if (!blockHashResponse.WasSuccessful)
                {
                    AppState.WriteConsole("❌ Failed to fetch latest block hash.");
                    return;
                }
                string blockHash = blockHashResponse.Result.Value.Blockhash;
                AppState.WriteConsole($"🔎 Blockhash: {blockHash}");

                var tx = new TransactionBuilder()
                    .SetRecentBlockHash(blockHash)
                    .SetFeePayer(fromAccount)
                    .AddInstruction(MemoProgram.NewMemo(fromAccount, "Hello from CatWifTools :)"))
                    .AddInstruction(SystemProgram.Transfer(fromAccount, toAccount, amountLamports))
                    .Build(wallet.Account);

                var firstSig = await rpcClient.SendTransactionAsync(tx);
                AppState.WriteConsole($"✅ Transaction Sent! Signature: {firstSig.Result}");

                if (!firstSig.WasSuccessful)
                {
                    AppState.WriteConsole($"❌ Transaction Failed: {firstSig.Reason}");
                    AppState.WriteConsole($"❌ Full Response: {firstSig.RawRpcResponse}");
                }
            }
            catch (Exception ex)
            {
                AppState.WriteConsole($"❌ Error: {ex.Message}");
            }
        }
    }
}
