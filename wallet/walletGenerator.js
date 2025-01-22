// Import necessary libraries
const { Keypair } = require("@solana/web3.js"); // Solana library for wallet operations
const { generateMnemonic, mnemonicToSeedSync } = require("bip39"); // Mnemonic generation and seed conversion

/**
 * Generates a new Solana wallet using a mnemonic phrase.
 * @returns {Object} An object containing the wallet's public key, private key, and mnemonic.
 */
function generateWallet() {
    // Generate a 12-word mnemonic phrase
    const mnemonic = generateMnemonic(128);

    // Convert mnemonic to seed
    const seed = mnemonicToSeedSync(mnemonic).slice(0, 32); // Use the first 32 bytes of the seed

    // Generate a Solana wallet keypair from the seed
    const keypair = Keypair.fromSeed(seed);

    // Return wallet details
    return {
        address: keypair.publicKey.toBase58(), // Public address
        privateKey: Buffer.from(keypair.secretKey).toString("hex"), // Private key in hexadecimal
        mnemonic // The mnemonic phrase
    };
}

const fs = require("fs");

function saveWalletsToFile(numWallets, filePath) {
    const wallets = [];
    for (let i = 0; i < numWallets; i++) {
        wallets.push(generateWallet());
    }
    fs.writeFileSync(filePath, JSON.stringify(wallets, null, 2));
    console.log(`Saved ${numWallets} wallets to ${filePath}`);
}

saveWalletsToFile(5, "wallets.json");

// Generate and print wallet details
const wallet = generateWallet();
console.log(JSON.stringify(wallet, null, 2)); // Print wallet details as a JSON string