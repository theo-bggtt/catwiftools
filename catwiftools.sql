-- phpMyAdmin SQL Dump
-- version 5.2.1deb3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Jan 24, 2025 at 07:12 PM
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
(20, 'Ge4EkaccAUaiw5aq9EQL5GavCeSUujAhURznZFdiKqqv', 'like rate fatal wood glimpse end large plate tag suffer country income', 1, 0);

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
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `wallets`
--
ALTER TABLE `wallets`
  MODIFY `idWallet` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

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
