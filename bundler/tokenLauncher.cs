using Solnet.Programs;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Models;
using Solnet.Wallet;
using System.Text;
using Solnet.Rpc;
using Solnet.Metaplex.NFT.Library;
using Solnet.Metaplex.NFT;

namespace catwiftools.bundler
{
    internal class tokenLauncher
    {

    //    public async Task<string> CreatePumpFunToken(
    //        string privateKey,
    //        string tokenName,
    //        string tokenDescription,
    //        decimal initialSolLiquidity = 0.1m,
    //string rpcUrl = "https://api.mainnet-beta.solana.com")
    //    {
    //        try
    //        {
    //            // 1. Initialize connections
    //            var rpc = ClientFactory.GetClient(rpcUrl);
    //            var wallet = new Wallet(privateKey);
    //            var account = wallet.Account;

    //            // 2. Create Token Mint
    //            var mint = new Wallet().Account; // New keypair for the mint
    //            var mintIx = TokenProgram.InitializeMint(
    //                mint.PublicKey,
    //                9, // Decimals
    //                account.PublicKey, // Mint authority
    //                account.PublicKey  // Freeze authority
    //            );

    //            // 3. Create Associated Token Account
    //            var associatedTokenAccount = AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(
    //                account.PublicKey,
    //                mint.PublicKey);

    //            var createAtaIx = AssociatedTokenAccountProgram.CreateAssociatedTokenAccount(
    //                account,
    //                account.PublicKey,
    //                mint.PublicKey);

    //            // 4. Create Metadata Account (Using Solnet.Metaplex)
    //            var metadataClient = new MetadataClient(rpc);
    //            var metadata = MetadataAccount.GetPDA(mint.PublicKey);

    //            var metadataIx = MetadataProgram.CreateMetadataAccount(
    //                metadata,
    //                mint.PublicKey,
    //                account.PublicKey, // Creator
    //                account.PublicKey, // Update authority
    //                account.PublicKey, // Payer
    //                tokenName,
    //                "TOKEN", // Symbol (can parameterize this)
    //                tokenDescription,
    //                "https://your-metadata-url.com", // Replace with actual URI
    //                null, // Additional creators
    //                500, // Seller fee basis points
    //                true, // Is mutable
    //                false // Primary sale happened
    //            );

    //            // 5. Create pump.fun Pool
    //            var (poolIx, poolAddress) = CreatePumpFunPoolInstruction(
    //                account,
    //                mint.PublicKey,
    //                initialSolLiquidity);

    //            // 6. Build and send transaction
    //            var blockHash = await rpc.GetRecentBlockHashAsync();
    //            var tx = new TransactionBuilder()
    //                .SetRecentBlockHash(blockHash.Result.Value.Blockhash)
    //                .SetFeePayer(account)
    //                .AddInstruction(mintIx)
    //                .AddInstruction(createAtaIx)
    //                .AddInstruction(metadataIx)
    //                .AddInstruction(poolIx)
    //                .Build(new List<Account> { account, mint });

    //            var result = await rpc.SendTransactionAsync(tx);
    //            return result.WasSuccessful
    //                ? $"Token created!\nMint: {mint.PublicKey}\nPool: {poolAddress}\nTx: {result.Result}"
    //                : $"Error: {result.Reason}";
    //        }
    //        catch (Exception ex)
    //        {
    //            return $"Critical error: {ex.Message}\n{ex.StackTrace}";
    //        }
    //    }

    //    private (TransactionInstruction, PublicKey) CreatePumpFunPoolInstruction(
    //        Account creator,
    //        PublicKey tokenMint,
    //        decimal solLiquidity)
    //    {
    //        var pumpProgramId = new PublicKey("PUMPXKdBBFp9oE8g9S5bj8johKUYme4q8wJH4wQ8ieX");
    //        var poolSeed = $"{creator.PublicKey}-{tokenMint}";
    //        var poolAddress = PublicKey.FindProgramAddress(
    //            Encoding.UTF8.GetBytes(poolSeed),
    //            pumpProgramId).PublicKey;

    //        var data = new List<byte> { 0x01 } // Create pool instruction
    //            .Concat(BitConverter.GetBytes((ulong)(solLiquidity * 1000000000)))
    //            .ToArray();

    //        var ix = new TransactionInstruction
    //        {
    //            ProgramId = pumpProgramId,
    //            Keys = new List<AccountMeta>
    //    {
    //        AccountMeta.Writable(creator.PublicKey, true),
    //        AccountMeta.Writable(tokenMint, false),
    //        AccountMeta.Writable(poolAddress, false),
    //        AccountMeta.ReadOnly(SystemProgram.ProgramIdKey, false),
    //        AccountMeta.ReadOnly(TokenProgram.ProgramIdKey, false)
    //    },
    //            Data = data
    //        };

    //        return (ix, poolAddress);
    //    }
    }
}
