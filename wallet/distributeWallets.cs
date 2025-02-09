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
        Functions functions = new Functions();
        // These private keys and public keys are all empty and the solana used is on DevNet, no harm can be done to these wallets, they are used for TEST ONLY!
        public static async Task Distribute(List<String>selectedAddresses)
        {

            for (int i = 0; i < selectedAddresses.Count; i++)
            {
                await new DistributeWallets().SendSol(selectedAddresses[i]);
            }
        }

        //private async Task RecallSol(string address)
        //{
        //    try
        //    {
        //        var rpcClient = ClientFactory.GetClient(Cluster.DevNet);

        //        // Get the wallet mnemonic or private key from the database
        //        string privateKeyString = functions.GetWalletphrase(null,address);

        //        // Ensure correct wallet initialization
        //        Wallet wallet;
        //        if (privateKeyString.Contains(" ")) // Check if it's a mnemonic
        //        {
        //            wallet = new Wallet(privateKeyString);
        //        }
        //        else
        //        {
        //            byte[] privateKeyBytes = Convert.FromBase64String(privateKeyString); // Ensure correct format
        //            wallet = new Wallet(privateKeyBytes);
        //        }

        //        PublicKey fromAccount = wallet.Account.PublicKey;
        //        PublicKey toAccount = new PublicKey("3k6XVaNMmUHP97SZKQibU2dyVgMGvYr9abs8WNVXepsp");

        //        // Check balance
        //        var balanceResponse = await rpcClient.GetBalanceAsync(fromAccount);
        //        double balanceSol = balanceResponse.Result.Value / 1_000_000_000.0;
        //        Console.WriteLine($"🔎 Wallet Balance: {balanceSol} SOL");

        //        if (balanceSol < 0.002) // Ensure sufficient balance for fees
        //        {
        //            Console.WriteLine("❌ Not enough SOL to send.");
        //            return;
        //        }

        //        // Fetch latest block hash
        //        var blockHashResponse = await rpcClient.GetLatestBlockHashAsync();
        //        if (!blockHashResponse.WasSuccessful)
        //        {
        //            Console.WriteLine("❌ Failed to fetch latest block hash.");
        //            return;
        //        }
        //        string blockHash = blockHashResponse.Result.Value.Blockhash;
        //        Console.WriteLine($"🔎 Blockhash: {blockHash}");

        //        // Amount to send (adjust as needed)
        //        ulong amountLamports = 200_000_000; // 0.2 SOL

        //        // Build transaction
        //        var tx = new TransactionBuilder()
        //            .SetRecentBlockHash(blockHash)
        //            .SetFeePayer(fromAccount)
        //            .AddInstruction(MemoProgram.NewMemo(fromAccount, "Hello from Sol.Net :)"))
        //            .AddInstruction(SystemProgram.Transfer(fromAccount, toAccount, amountLamports))
        //            .Build(wallet.Account); // Ensure proper signing

        //        // Send transaction
        //        var firstSig = await rpcClient.SendTransactionAsync(tx);
        //        Console.WriteLine($"✅ Transaction Sent! Signature: {firstSig.Result}");

        //        if (!firstSig.WasSuccessful)
        //        {
        //            Console.WriteLine($"❌ Transaction Failed: {firstSig.Reason}");
        //            Console.WriteLine($"❌ Full Response: {firstSig.RawRpcResponse}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"❌ Error: {ex.Message}");
        //    }
        //}


        private async Task SendSol(string address)
        {
            try
            {
                var rpcClient = ClientFactory.GetClient(Cluster.DevNet);
                string privateKey = "gloom like bronze helmet team zone drill version polar glare firm silk";
                Wallet wallet = new Wallet(privateKey);
                PublicKey fromAccount = wallet.Account.PublicKey;
                PublicKey toAccount = new PublicKey(address);

                var balanceResponse = await rpcClient.GetBalanceAsync(fromAccount);
                Console.WriteLine($"🔎 Wallet Balance: {balanceResponse.Result.Value / 1_000_000_000.0} SOL");

                var blockHashResponse = await rpcClient.GetLatestBlockHashAsync();
                if (!blockHashResponse.WasSuccessful)
                {
                    Console.WriteLine("❌ Failed to fetch latest block hash.");
                    return;
                }
                string blockHash = blockHashResponse.Result.Value.Blockhash;
                Console.WriteLine($"🔎 Blockhash: {blockHash}");

                var tx = new TransactionBuilder()
                    .SetRecentBlockHash(blockHash)
                    .SetFeePayer(fromAccount)
                    .AddInstruction(MemoProgram.NewMemo(fromAccount, "Hello from Sol.Net :)"))
                    .AddInstruction(SystemProgram.Transfer(fromAccount, toAccount, 200000000)) // 0.2 SOL
                    .Build(wallet.Account);

                var firstSig = await rpcClient.SendTransactionAsync(tx);
                Console.WriteLine($"✅ Transaction Sent! Signature: {firstSig.Result}");

                if (!firstSig.WasSuccessful)
                {
                    Console.WriteLine($"❌ Transaction Failed: {firstSig.Reason}");
                    Console.WriteLine($"❌ Full Response: {firstSig.RawRpcResponse}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }
    }
}
