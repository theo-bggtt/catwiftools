-- phpMyAdmin SQL Dump
-- version 5.2.1deb3
-- https://www.phpmyadmin.net/
--
-- Hôte : localhost:3306
-- Généré le : ven. 10 jan. 2025 à 14:03
-- Version du serveur : 10.11.8-MariaDB-0ubuntu0.24.04.1
-- Version de PHP : 8.3.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `catwiftools`
--

-- --------------------------------------------------------

--
-- Structure de la table `wallets`
--

CREATE TABLE `wallets` (
  `idWallet` int(11) NOT NULL,
  `walletName` varchar(50) NOT NULL,
  `walletphrase` varchar(300) NOT NULL,
  `walletType` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `wallets`
--

INSERT INTO `wallets` (`idWallet`, `walletName`, `walletphrase`, `walletType`) VALUES
(31, 'Wallet-1', 'hero tunnel stumble into loop riot depth walnut love tragic private ship', 'bundle'),
(32, 'Wallet-2', 'canvas patient lemon unfair rifle depart put ridge beach suspect head dance', 'bundle'),
(33, 'Wallet-3', 'frost oblige leader cupboard trap toy upgrade olive magnet panel garment tortoise', 'bundle'),
(34, 'Wallet-4', 'early forget dress ridge license chuckle math before harvest pulse width tape', 'bundle'),
(35, 'Wallet-5', 'sample abuse permit glove tiger appear subject zone little tragic panther learn', 'bundle'),
(36, 'Wallet-1', 'above culture current uncover armor ahead stand apart lens believe impact real', 'bundle'),
(37, 'Wallet-2', 'vacuum argue zebra few village volume country animal ridge topic lab talk', 'bundle'),
(38, 'Wallet-3', 'poet circle spring brass slight rug alarm usual action assume library copper', 'bundle'),
(39, 'Wallet-4', 'tree tribe section feed pluck illness guess click room term harvest solve', 'bundle'),
(40, 'Wallet-5', 'seed method east denial minute route bundle hawk radio casino saddle that', 'bundle'),
(41, 'Wallet-1', 'spoon outside fatal peanut police capital unfair arrange very demise such dumb', 'bundle'),
(42, 'Wallet-2', 'venture bird salmon joke post cruel train page hard summer october trial', 'bundle'),
(43, 'Wallet-3', 'random hen outdoor thing chase setup public prison silk envelope leave ignore', 'bundle'),
(44, 'Wallet-4', 'cradle image fresh great soldier filter toss carry sadness purse antique choose', 'bundle'),
(45, 'Wallet-5', 'budget bonus orphan recipe other alarm piano develop clay park hill goddess', 'bundle');

-- --------------------------------------------------------

--
-- Structure de la table `wallettypes`
--

CREATE TABLE `wallettypes` (
  `idType` int(11) NOT NULL,
  `typeName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `wallettypes`
--

INSERT INTO `wallettypes` (`idType`, `typeName`) VALUES
(1, 'bundle');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `wallets`
--
ALTER TABLE `wallets`
  ADD PRIMARY KEY (`idWallet`),
  ADD UNIQUE KEY `walletphrase` (`walletphrase`),
  ADD KEY `walletType` (`walletType`);

--
-- Index pour la table `wallettypes`
--
ALTER TABLE `wallettypes`
  ADD PRIMARY KEY (`idType`),
  ADD UNIQUE KEY `typeName` (`typeName`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `wallets`
--
ALTER TABLE `wallets`
  MODIFY `idWallet` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=46;

--
-- AUTO_INCREMENT pour la table `wallettypes`
--
ALTER TABLE `wallettypes`
  MODIFY `idType` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `wallets`
--
ALTER TABLE `wallets`
  ADD CONSTRAINT `wallets_ibfk_1` FOREIGN KEY (`walletType`) REFERENCES `wallettypes` (`typeName`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
