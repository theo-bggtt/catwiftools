-- phpMyAdmin SQL Dump
-- version 5.2.1deb3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Jan 24, 2025 at 06:14 PM
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
  `walletType` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `wallets`
--

INSERT INTO `wallets` (`idWallet`, `walletAddress`, `walletphrase`, `walletType`) VALUES
(1, '3k6XVaNMmUHP97SZKQibU2dyVgMGvYr9abs8WNVXepsp', 'gloom like bronze helmet team zone drill version polar glare firm silk', 1),
(2, '81EXmNXxaQZ6BHsyrvJRdor22hedhHN5uB24fpHiwW2y', 'carpet yellow pet sock upgrade suggest usual machine thrive entry ticket post', 1),
(3, '5BS6SeUFu4wX2mL7YW3Absi7nxWfAwjg88HAyS9i6Q12', 'afford about proof celery knife task pigeon key scan brisk say dune', 1),
(4, '6aaspdN4z6BBvjYSgkWwWH4gAexyRW78VGSLTvavpWrh', 'boat shield time swarm trade leisure need tone access dress spice item', 1),
(5, '7hZVXoKrornHwxqWn5Tfb4XJE8WBa7LApivECWnTcbTm', 'list manage master occur imitate rib blue vehicle rabbit across mango keen', 1),
(6, 'CbGoFNypS9URWNS7MTiSwg9Ur7A3DVsGn212H2XR9AXd', 'ritual neutral moon picnic spy struggle liberty shop course biology undo cradle', 1),
(7, '8iZk4KQMu7bCkqHBuFW6wmvZzGaFr1Feg2G7oXaT6uX6', 'bar book aunt remember school dwarf giraffe wing proof milk finish toddler', 1),
(8, 'EeWYhK3AzXy47DToJZjphu4o69tMoQrXT9ZA1LJzVctF', 'huge roast debris coyote dismiss wagon bike make health horror fury recipe', 1),
(9, 'DeozwZNwyFTzwcTQFgQPgkwd7P8WPjvkHjcRFKcJx6dK', 'buddy gorilla motor ethics lyrics ketchup all wage absorb east loud pole', 1),
(10, '2NMRNC9BZH7GuCp2ZDUKCDT9ei2Etpcmkr2JuWShrGRa', 'remove decorate tail slice sister breeze swallow file hamster frame celery during', 1);

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
  MODIFY `idWallet` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

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
