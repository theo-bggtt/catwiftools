-- phpMyAdmin SQL Dump
-- version 5.2.1deb3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Jan 26, 2025 at 11:06 PM
-- Server version: 10.11.8-MariaDB-0ubuntu0.24.04.1
-- PHP Version: 8.3.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `catwiftools`
--
CREATE DATABASE IF NOT EXISTS `catwiftools` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `catwiftools`;

-- --------------------------------------------------------

--
-- Table structure for table `wallets`
--

CREATE TABLE `wallets` (
  `idWallet` int(11) NOT NULL,
  `walletAddress` varchar(50) NOT NULL,
  `walletphrase` varchar(300) NOT NULL,
  `walletType` int(11) NOT NULL,
  `balance` double DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `wallets`:
--   `walletType`
--       `wallettypes` -> `idType`
--

--
-- Dumping data for table `wallets`
--

INSERT INTO `wallets` (`idWallet`, `walletAddress`, `walletphrase`, `walletType`, `balance`) VALUES
(1, '3k6XVaNMmUHP97SZKQibU2dyVgMGvYr9abs8WNVXepsp', 'gloom like bronze helmet team zone drill version polar glare firm silk', 1, 5),
(2, '81EXmNXxaQZ6BHsyrvJRdor22hedhHN5uB24fpHiwW2y', 'carpet yellow pet sock upgrade suggest usual machine thrive entry ticket post', 1, 0),
(3, '5BS6SeUFu4wX2mL7YW3Absi7nxWfAwjg88HAyS9i6Q12', 'afford about proof celery knife task pigeon key scan brisk say dune', 1, 0),
(4, '6aaspdN4z6BBvjYSgkWwWH4gAexyRW78VGSLTvavpWrh', 'boat shield time swarm trade leisure need tone access dress spice item', 1, 0),
(5, '7hZVXoKrornHwxqWn5Tfb4XJE8WBa7LApivECWnTcbTm', 'list manage master occur imitate rib blue vehicle rabbit across mango keen', 1, 0),
(6, 'CbGoFNypS9URWNS7MTiSwg9Ur7A3DVsGn212H2XR9AXd', 'ritual neutral moon picnic spy struggle liberty shop course biology undo cradle', 1, 0),
(7, '8iZk4KQMu7bCkqHBuFW6wmvZzGaFr1Feg2G7oXaT6uX6', 'bar book aunt remember school dwarf giraffe wing proof milk finish toddler', 1, 0),
(8, 'EeWYhK3AzXy47DToJZjphu4o69tMoQrXT9ZA1LJzVctF', 'huge roast debris coyote dismiss wagon bike make health horror fury recipe', 1, 0),
(9, 'DeozwZNwyFTzwcTQFgQPgkwd7P8WPjvkHjcRFKcJx6dK', 'buddy gorilla motor ethics lyrics ketchup all wage absorb east loud pole', 1, 0),
(10, '2NMRNC9BZH7GuCp2ZDUKCDT9ei2Etpcmkr2JuWShrGRa', 'remove decorate tail slice sister breeze swallow file hamster frame celery during', 1, 0),
(11, '51VYoXNGovReyqg1aNvhRmpJKQT2YXB6UcBaEpaU3Y3s', 'like oblige capital father device point alcohol snow cry slam strategy student', 1, 0),
(12, '3xoMp4hEKgmPJLyMarrcTDwUDDnxGTn4NF5XNexzC6E9', 'unlock reject method hire virtual shallow define guide garlic winner genius impact', 1, 0),
(13, 'G7uEcHs4bJzZykbPMgfgAdncrstvvQR2V87JwHaRk9DF', 'tennis prefer across mixture deposit boost expose renew light lottery head giraffe', 1, 0),
(14, '56LjYqitJgZ1QgTknZ4a6g4tgThET9CDfsX24kfNNruE', 'fish length urban crane struggle stadium laptop bundle trust wall open crystal', 1, 0),
(15, 'EfKamFhzFX3apezqGyYNXmfR1T2eC8t2T5ZfcFYBwRqh', 'story old cluster bless nephew gospel unique potato collect organ arrest toward', 1, 0),
(16, '726ExktJkBPtiap3i4mkxU4JNBKBEbaeaksZeeYbyC8z', 'quote book foil swap elite bulb sad away render trouble shaft orchard', 1, 0),
(17, '3rmMLUytpG8mkX94Lpt4zrRT48nWLwkGfixBt9W5QgbH', 'purpose ask pluck alarm drill act merry snow upper payment adult student', 1, 0),
(18, 'J6NAYaiSQo4xWVhqTcAemYeavtRiKMEog9eCJ4NKutT6', 'obscure uncle cherry fence visa awful race wisdom crew dolphin merge chef', 1, 0),
(19, 'E3pvci92XT9ZwC6y7R34pa9SJWeGDUr5szpgScTXGLo1', 'biology cinnamon wave pizza space stumble popular popular blade trick program will', 1, 0),
(20, 'Ge4EkaccAUaiw5aq9EQL5GavCeSUujAhURznZFdiKqqv', 'like rate fatal wood glimpse end large plate tag suffer country income', 1, 5),
(21, '5oBSmok8N9gNFE2YPsMqBk43oN3x3iC7uFUxaks7PAvu', 'zone feature tongue pledge bracket stay chaos secret photo joy first vicious', 2, 0),
(22, 'HbbXcPUDjUp9coxmpscydn2q7ureJZShRf9cWKEXVuUf', 'sheriff attract camp power point snack floor subway lizard tribe hybrid crunch', 2, 0),
(23, '3FtYSvqKq5NAZTvZSbahUnj2MsvuPgJ1TZqhnSXSzsBR', 'inflict walnut pottery captain claim reform skull capable random record weather breeze', 2, 0),
(24, '2K92TvyMc76mn9Aw3JLb7beNKQUhhWosU2bRu5QhVJ4X', 'cash piece rebel useful donkey cable impulse discover mouse that harbor kingdom', 2, 0),
(25, '7C9RVBa1wBewwGJ8NQLCBNfG8QNi9srPvRCRgmk3spqt', 'vital defy rail grape party trophy profit bamboo elegant dice grid fiber', 2, 0),
(26, '7BFKeCchZ9s5vVjad8oLW2UYueSDuR97gHyqhgizWegd', 'own miracle shine audit field stumble shuffle general congress patch congress wisdom', 2, 0),
(27, '6rMG9pBgUX6CTWrtkwunSXpUsuLeuXJiisUtCURaDEJ6', 'hobby alcohol congress hen mirror praise oven shock tank razor govern inner', 2, 0),
(28, 'GU8fFpT4iXXXvaWXPiphNkbveJcrQo7DhaXSDah31PEH', 'negative trap recipe apple miss napkin toss palm dizzy element duty fashion', 2, 0),
(29, '2akF2nAZKaL41PsN7U3VNfZBnHyUojJcbuDQNUgWraZp', 'two kid life hospital supreme impact barely elevator monitor credit abstract ladder', 2, 0),
(30, '8SoLU5Ayhtu3qmwnCDgTjZwMQGT7cSpELERiZUsmnTeM', 'among reduce happy equip outdoor emotion fit stick release swallow scrub flip', 2, 0),
(31, 'J2jKkW5S2WbPpWHcBkPs6E6c3VgXGspn8veRNC9KAYVk', 'hurry expose magic law lab use violin permit strong close mind gift', 3, 0),
(32, '2XQNcCNWWWbZ67aBZacdVHLGEVf1B9xo61QgDhVUvHPq', 'retreat license what merge sample pony purity good people shadow long tired', 3, 0),
(33, 'CkNUqMN3vfZg6UyfXxLyJskSxUshtB8GDCGEkiKfj46t', 'wrap noble number sibling inner proof win loyal sibling grape clever fly', 3, 0),
(34, 'GJkxtdXQXJRcU44xahYBBQu3tKhffcoeRz4NkriFwjwB', 'churn omit grunt become sand rigid brand vivid praise dynamic life body', 3, 0),
(35, '5YTiCNYfnzrcyR6x5CutLdsvPwxX6vPP5BGdpYbs6nes', 'milk plastic resist lyrics volume connect clock tank eye laundry smart kite', 3, 0);

-- --------------------------------------------------------

--
-- Table structure for table `wallettypes`
--

CREATE TABLE `wallettypes` (
  `idType` int(11) NOT NULL,
  `typeName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `wallettypes`:
--

--
-- Dumping data for table `wallettypes`
--

INSERT INTO `wallettypes` (`idType`, `typeName`) VALUES
(3, 'Bump It'),
(1, 'Bundle'),
(2, 'Volume');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `wallets`
--
ALTER TABLE `wallets`
  ADD PRIMARY KEY (`idWallet`),
  ADD UNIQUE KEY `walletphrase` (`walletphrase`),
  ADD KEY `walletType` (`walletType`);

--
-- Indexes for table `wallettypes`
--
ALTER TABLE `wallettypes`
  ADD PRIMARY KEY (`idType`),
  ADD UNIQUE KEY `typeName` (`typeName`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `wallets`
--
ALTER TABLE `wallets`
  MODIFY `idWallet` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT for table `wallettypes`
--
ALTER TABLE `wallettypes`
  MODIFY `idType` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `wallets`
--
ALTER TABLE `wallets`
  ADD CONSTRAINT `fk_walettype` FOREIGN KEY (`walletType`) REFERENCES `wallettypes` (`idType`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
