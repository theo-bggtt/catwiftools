using Solnet.Programs;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Core.Http;
using Solnet.Rpc.Messages;
using Solnet.Rpc.Models;
using Solnet.Rpc.Types;
using Solnet.Wallet;
using Solnet.Wallet.Bip39;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catwiftools
{
    public class WalletCreatorScript
    {
        public string CreateWallets(int walletQuantity)
        {
            string wallets = "";
            for (int i = 0; i < walletQuantity; i++)
            {
                var newMnemonic = new Mnemonic(WordList.English, WordCount.Twelve);
                wallets += "Wallet N°" + (i + 1) + ": " + newMnemonic.ToString() + Environment.NewLine;
            }
            return wallets;
        }
    }
}