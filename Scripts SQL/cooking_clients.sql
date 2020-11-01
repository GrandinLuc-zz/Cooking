CREATE DATABASE  IF NOT EXISTS `cooking` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `cooking`;
-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: cooking
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clients` (
  `nomClient` varchar(20) NOT NULL,
  `teleClient` varchar(10) DEFAULT NULL,
  `codeC` varchar(40) NOT NULL,
  `motDePasse` varchar(40) DEFAULT NULL,
  `CommandesDejaEffectuees` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`codeC`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES ('Juniot','0123456789','C654','2348653','Fondants au chocolat-Tiramisu-Forêt noire-Tarte au citron-Pâtes à la Carbonara-Gratin Dauphinois-Salade lyonnaise'),('Delon','0258147369','C655','5672821','Fondants au chocolat-Salade lyonnaise'),('Gabin','0369258147','C657','34567','Fondants au chocolat-Fondants au chocolat-Salade lyonnaise'),('Reno','0147258369','C658','2348653','Fondants au chocolat-Tiramisu-Salade lyonnaise'),('Delon','0123789456','C659','bonbon01','Pâtes à la Carbonara-Gratin Dauphinois-Salade lyonnaise'),('Depardieu','0789456123','C660','757665','Tiramisu-Forêt noire-Tarte au citron-Pâtes à la Carbonara-Gratin Dauphinois-Salade lyonnaise'),('Depardieu','0456123789','C661','34567','Fondants au chocolat-Tiramisu-Fondants au chocolat-Forêt noire'),('Depardieu','0456789123','C662','2348653','Salade lyonnaise'),('Dujardin','0789123456','C663','Jnspeav','Fondants au chocolat-Salade lyonnaise'),('Boon','0987654321','C664','757665','Gratin Dauphinois-Tiramisu-Salade lyonnaise'),('Willis','0654987321','C665','34567','Tarte au citron-Tiramisu-Pâtes à la Carbonara-Gratin Dauphinois-Salade lyonnaise'),('Cassel','0987321654','C666','2348653','Fondants au chocolat-Forêt noire-Tarte au citron-Fondants au chocolat-Pâtes à la Carbonara-Gratin Dauphinois-'),('Charlot','0321654987','C667','5672821','Fondants au chocolat'),('Canet','0321987654','C668','757665','Pâtes à la Carbonara-Gratin Dauphinois-Pâtes à la Carbonara-Salade lyonnaise'),('Richard','0963852741','C669','34567','Gratin Dauphinois-Tiramisu-Salade lyonnaise'),('Canet','0852963741','C670','75235','Fondants au chocolat-Tiramisu-Forêt noire-Tarte au citron-Pâtes à la Carbonara-Gratin Dauphinois-Salade lyonnaise'),('Premier','0963741852','C671','34354','Pâtes à la Carbonara-Pâtes à la Carbonara-Salade lyonnaise'),('Richard','0741852369','C672','346767','Fondants au chocolat-Tiramisu');
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-05-11 17:22:19
