-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: travela
-- ------------------------------------------------------
-- Server version	8.0.32

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
-- Table structure for table `city`
--

DROP TABLE IF EXISTS `city`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `city` (
  `cityId` int NOT NULL AUTO_INCREMENT,
  `cityName` varchar(45) NOT NULL,
  `isActive` tinyint NOT NULL DEFAULT '1',
  `isDelete` tinyint NOT NULL DEFAULT '0',
  `createdBy` varchar(45) NOT NULL DEFAULT 'Admin',
  `createdDate` datetime NOT NULL DEFAULT '2024-05-02 12:00:00',
  PRIMARY KEY (`cityId`),
  UNIQUE KEY `cityName_UNIQUE` (`cityName`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `city`
--

LOCK TABLES `city` WRITE;
/*!40000 ALTER TABLE `city` DISABLE KEYS */;
INSERT INTO `city` VALUES (1,'Hyderabad',1,0,'Admin','2024-04-26 00:00:00'),(2,'Pune',1,0,'Admin','2024-04-26 00:00:00'),(3,'Indore',1,0,'Admin','2024-04-26 00:00:00'),(4,'SINGAPORE',1,0,'Admin','2024-04-26 00:00:00'),(5,'MUMBAI',1,0,'Admin','2024-05-02 12:00:00'),(6,'Daman',1,0,'Admin','2024-05-03 16:27:12'),(7,'Tianjin',0,0,'Admin','2024-06-20 17:26:33'),(8,'MOSCOW',1,0,'Admin','2024-06-20 17:20:42'),(9,'Chennai',0,0,'Admin','2024-05-06 16:48:17'),(10,'BEIJING',1,0,'Admin','2024-06-20 17:19:09'),(11,'Karachi',1,0,'Admin','2024-06-20 17:19:29'),(12,'Istanbul',1,0,'Admin','2024-06-20 17:19:40'),(13,'Hong Kong',1,0,'Admin','2024-05-06 17:02:36'),(14,'BOGOTA',1,0,'Admin','2024-05-06 17:03:31'),(15,'DHAKA',1,0,'Admin','2024-06-20 17:19:51'),(16,'Nashik',1,0,'Admin','2024-05-15 10:24:30'),(17,'lucknow',1,0,'Admin','2024-05-14 13:51:39'),(18,'Agra',1,0,'Admin','2024-05-14 13:49:40'),(19,'Chandigarh',1,0,'Admin','2024-05-06 17:12:43'),(20,'TOKYO',1,0,'Admin','2024-06-20 17:20:06'),(21,'Jaipur',1,0,'Admin','2024-05-06 17:24:56'),(22,'Shanghai',1,0,'Admin','2024-06-20 17:18:41'),(23,'Bengaluru',1,0,'Admin','2024-05-08 11:52:45'),(24,'Vyara',0,0,'Admin','2024-05-08 11:53:13'),(25,'amreli',0,0,'Admin','2024-05-14 12:05:59'),(26,'BANGKOK',0,0,'Admin','2024-05-14 12:07:43'),(27,'ahmedabad',1,0,'Admin','2024-05-14 12:14:34'),(28,'Surat',0,0,'Admin','2024-05-14 12:27:30'),(29,'Bhavnagar',1,0,'Admin','2024-05-14 12:35:50'),(30,'london',1,0,'Admin','2024-06-21 10:50:22'),(31,'Bhopal',1,0,'Admin','2024-05-14 12:58:24'),(32,'New York',1,0,'Admin','2024-06-21 10:51:44'),(33,'JAKARTA',1,0,'Admin','2024-06-21 10:52:46'),(34,'Seoul',0,0,'Admin','2024-05-14 13:01:49'),(35,'Nagpur',1,0,'Admin','2024-05-15 10:24:00'),(36,'rajkot',1,1,'Admin','2024-05-18 10:41:14'),(37,'Lahore',1,1,'Admin','2024-06-20 17:32:29'),(38,'MEXICO',1,0,'Admin','2024-06-20 17:35:41'),(39,'Shenzhen',1,0,'Admin','2024-06-20 17:37:00'),(40,'ROME',1,0,'Admin','2024-06-20 17:46:02'),(41,'Los Angeles',1,0,'Admin','2024-06-21 10:49:42'),(42,'Dwarka',1,0,'Admin','2024-06-21 11:08:07');
/*!40000 ALTER TABLE `city` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `destination`
--

DROP TABLE IF EXISTS `destination`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `destination` (
  `destinationId` int NOT NULL AUTO_INCREMENT,
  `destinationName` varchar(45) NOT NULL,
  `isActive` tinyint NOT NULL DEFAULT '1',
  `isDelete` tinyint NOT NULL DEFAULT '0',
  `createdBy` varchar(20) NOT NULL DEFAULT 'Admin',
  `createdDate` datetime NOT NULL DEFAULT '2024-05-02 12:00:00',
  PRIMARY KEY (`destinationId`),
  UNIQUE KEY `destinationName_UNIQUE` (`destinationName`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `destination`
--

LOCK TABLES `destination` WRITE;
/*!40000 ALTER TABLE `destination` DISABLE KEYS */;
INSERT INTO `destination` VALUES (1,'Katra',1,1,'Admin','2024-05-15 15:32:41'),(2,'Pathankot',1,0,'Admin','2024-05-15 16:37:52'),(3,'Bangalore',1,0,'Admin','2024-05-15 16:43:48'),(4,'dwarka',1,1,'Admin','2024-05-18 10:42:31');
/*!40000 ALTER TABLE `destination` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hotel`
--

DROP TABLE IF EXISTS `hotel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hotel` (
  `hotelId` int NOT NULL AUTO_INCREMENT,
  `hotelImage` varchar(245) NOT NULL,
  `hotelName` varchar(45) NOT NULL,
  `hotelPhone` int NOT NULL,
  `cityId` int NOT NULL,
  `isActive` tinyint NOT NULL DEFAULT '1',
  `isDelete` tinyint NOT NULL DEFAULT '0',
  `createdDate` datetime NOT NULL,
  `createdBy` varchar(45) NOT NULL DEFAULT 'Admin',
  PRIMARY KEY (`hotelId`),
  KEY `cityName_idx` (`cityId`),
  CONSTRAINT `cityId` FOREIGN KEY (`cityId`) REFERENCES `city` (`cityId`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hotel`
--

LOCK TABLES `hotel` WRITE;
/*!40000 ALTER TABLE `hotel` DISABLE KEYS */;
INSERT INTO `hotel` VALUES (1,'img','Hyatt Regency',0,4,1,1,'2024-05-17 17:50:23','Admin'),(2,'sad','fjh',0,3,0,1,'2024-05-17 17:55:34','Admin'),(3,'/Images/7b2d63ea-89ac-472a-ad55-9e993b36c70c.jpg','Gitanjali hotel',9865432,3,1,0,'2024-06-12 12:09:47','Admin'),(4,'/Images/f6d5e1c7-9607-4904-84ad-2ff511b049ca.png','hjbgdvf',5965,29,1,0,'2024-06-05 13:05:08','Admin'),(5,'/Images/73306402-a281-4ead-aa9b-e5a0ed727ada.jpg','hjbgdvf',5965,31,1,0,'2024-06-04 12:17:18','Admin'),(6,'/Images/0bcd2790-3158-43ed-8c68-a9574d1d276c.png','xtgfdh',65255,35,1,1,'2024-06-05 11:48:47','Admin'),(7,'/Images/0fdadb56-cd5c-47e3-80ea-357349c81de5.jpg','safcxx',5465,30,1,1,'2024-06-05 12:36:10','Admin'),(8,'/Images/eefd13b6-dff7-40a0-9c0c-c58c0d87d44a.jpg','efvc ',76854621,31,1,0,'2024-06-12 10:51:21','Admin'),(9,'cgbhn','hii',74658432,21,1,1,'2024-06-19 11:13:31','Admin'),(10,'/Images/f2b1f3da-d277-4c3f-b9be-b295fbf52c99.jpg','mariott',0,19,1,0,'2024-06-05 14:45:53','Admin'),(11,'/Images/9e000f27-7cf0-4d84-ab23-4ad960869b05.jpg','xyz',0,29,0,0,'2024-06-07 11:40:27','Admin'),(15,'/Images/421450d1-1314-4bc9-b54e-e95a26eac621.jpg','Imperial Hotel',452476324,18,1,0,'2024-06-12 10:47:31','Admin'),(16,'/Images/64fd1cb2-fc29-4f45-ba42-1fda3af153cf.jpg','hjbgdvf',0,3,0,1,'2024-06-07 12:34:46','Admin'),(17,'/Images/22feff17-7662-44cc-8fae-45e768d0e9d7.jpg','Plannet Hollywood',0,18,1,0,'2024-06-07 12:47:28','Admin'),(18,'/Images/8c13b25a-857a-4335-9dd7-c121f9eb3b20.jpg','The Oberoi',789254631,28,0,0,'2024-06-11 16:02:24','Admin'),(19,'/Images/532fcb35-2ecb-4e61-abd0-ee25c313dd67.jpg','Taj Mahal Palace',0,5,1,0,'2024-06-07 12:51:54','Admin'),(20,'/Images/be17e7c2-5ae8-4c1c-91c1-1827810cec55.jpg','ggjj',565325465,35,1,1,'2024-06-07 12:55:50','Admin'),(21,'/Images/2c46f4ab-3a3b-410d-9d22-c77197e8883e.jpg','Planet Hollywood',469873523,6,1,0,'2024-06-07 13:00:13','Admin'),(22,'/Images/c0fa15b4-209b-489d-b0cb-4e308f5e1b2b.jpg','Planet Hollywood',0,2,1,0,'2024-06-07 15:59:19','Admin'),(23,'/Images/535693ec-0ed7-418a-a03a-63ecd6bbf712.jpg','Planet Hollywood',0,30,1,0,'2024-06-07 16:02:23','Admin'),(24,'/Images/b56d6944-07df-4dbc-bc3d-5665161fa87a.jpg','Silver Springs',0,27,1,0,'2024-06-11 11:20:15','Admin'),(25,'/Images/f24087a5-d869-41c7-b01c-863609796df7.JPG','Ashok Hotel',547899651,19,1,0,'2024-06-12 11:21:20','Admin'),(26,'/Images/d7569c92-0c0b-425b-ab84-b8f3b78df70f.jpg','jyf',56,28,0,0,'2024-06-12 12:33:53','Admin'),(27,'/Images/065c08c0-8d0e-4bb1-8a58-6343ec2f3dc2.JPG','hfg',5,30,0,0,'2024-06-12 12:34:17','Admin'),(28,'/Images/eb6f103e-e69a-4e84-bd1a-2c1582b9122e.JPG','hjbgdvf',20453363,27,1,0,'2024-06-12 13:00:42','Admin'),(31,'','gfdg',5464,27,1,1,'2024-06-12 13:04:42','Admin'),(32,'','gfdg',5464,27,1,1,'2024-06-12 13:04:44','Admin'),(33,'/Images/eb6f103e-e69a-4e84-bd1a-2c1582b9122e.JPG','hjbgdvf',20453363,27,1,0,'2024-06-12 13:04:58','Admin'),(34,'/Images/2fd873e7-0725-44bd-a9d8-68320eef0185.jpg','Jahanvi',4578523,30,0,0,'2024-06-19 13:09:41','Admin'),(40,'/Images/a5ea83ec-72c5-4b68-904f-df76b753c42f.JPG','Planet Hollywood',0,24,1,0,'2024-06-19 17:51:44','Admin'),(46,'/Images/6141b206-b56a-4635-89db-b89d8e95be05.jpg','fdf',43543543,29,0,0,'2024-06-20 11:25:08','Admin'),(47,'/Images/083c0da7-b2a2-4ee0-9d32-746ba9e64dd4.JPG','vnhbjh',0,28,1,0,'2024-06-20 12:37:54','Admin'),(48,'/Images/33f15170-ebd6-4351-aa75-c33fea1c045e.jpg','fdf',46354653,24,0,0,'2024-06-20 14:50:54','Admin');
/*!40000 ALTER TABLE `hotel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hotel_booking`
--

DROP TABLE IF EXISTS `hotel_booking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hotel_booking` (
  `hotel_bookingID` int NOT NULL AUTO_INCREMENT,
  `hotelId` int NOT NULL,
  `userId` int NOT NULL,
  `adults` int NOT NULL,
  `child` int NOT NULL,
  `bookingDate` datetime NOT NULL,
  `paymentMode` varchar(45) NOT NULL,
  `isActive` tinyint NOT NULL,
  `isDelete` tinyint NOT NULL,
  `createdBy` varchar(45) NOT NULL,
  `createdDate` datetime NOT NULL,
  PRIMARY KEY (`hotel_bookingID`),
  KEY `hotel_hotelId_idx` (`hotelId`),
  KEY `hotel_userId_idx` (`userId`),
  CONSTRAINT `hotel_hotelId` FOREIGN KEY (`hotelId`) REFERENCES `hotel` (`hotelId`),
  CONSTRAINT `hotel_userId` FOREIGN KEY (`userId`) REFERENCES `user` (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hotel_booking`
--

LOCK TABLES `hotel_booking` WRITE;
/*!40000 ALTER TABLE `hotel_booking` DISABLE KEYS */;
/*!40000 ALTER TABLE `hotel_booking` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hotelrooms`
--

DROP TABLE IF EXISTS `hotelrooms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hotelrooms` (
  `hotelRoomsId` int NOT NULL AUTO_INCREMENT,
  `hotelId` varchar(45) NOT NULL,
  `roomTypeId` int NOT NULL,
  `roomNo` int NOT NULL,
  `amount` decimal(10,0) NOT NULL,
  `isActive` tinyint NOT NULL DEFAULT '1',
  `isDelete` tinyint NOT NULL DEFAULT '0',
  `createdBy` varchar(45) NOT NULL DEFAULT 'Admin',
  `createdDate` datetime NOT NULL,
  PRIMARY KEY (`hotelRoomsId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hotelrooms`
--

LOCK TABLES `hotelrooms` WRITE;
/*!40000 ALTER TABLE `hotelrooms` DISABLE KEYS */;
INSERT INTO `hotelrooms` VALUES (2,'5',3,101,1200,1,1,'Admin','2024-06-06 11:32:37'),(3,'33',1,102,1600,1,0,'Admin','2024-06-12 13:05:21'),(4,'33',2,104,1500,1,0,'Admin','2024-06-12 13:05:25'),(5,'34',1,128,2820,1,0,'Admin','2024-06-19 11:54:52'),(6,'34',4,102,1600,1,0,'Admin','2024-06-19 13:09:56'),(7,'40',2,102,1600,1,0,'Admin','2024-06-19 17:52:00'),(8,'46',4,45,545,1,0,'Admin','2024-06-20 11:25:20'),(9,'46',2,545,1600,1,0,'Admin','2024-06-20 11:25:23'),(10,'47',4,657,3021,1,0,'Admin','2024-06-20 12:37:55');
/*!40000 ALTER TABLE `hotelrooms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pack_booking`
--

DROP TABLE IF EXISTS `pack_booking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pack_booking` (
  `pack_bookingId` int NOT NULL AUTO_INCREMENT,
  `packageId` int NOT NULL,
  `userId` int NOT NULL,
  `paymentMode` varchar(10) NOT NULL,
  `bookingDate` datetime NOT NULL,
  `isActive` tinyint NOT NULL,
  `isDelete` tinyint NOT NULL,
  `createdBy` varchar(45) NOT NULL,
  `createdDate` datetime NOT NULL,
  PRIMARY KEY (`pack_bookingId`),
  KEY `packId_idx` (`packageId`),
  KEY `userid_idx` (`userId`),
  CONSTRAINT `packId` FOREIGN KEY (`packageId`) REFERENCES `package` (`packageId`),
  CONSTRAINT `userid` FOREIGN KEY (`userId`) REFERENCES `user` (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pack_booking`
--

LOCK TABLES `pack_booking` WRITE;
/*!40000 ALTER TABLE `pack_booking` DISABLE KEYS */;
/*!40000 ALTER TABLE `pack_booking` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `package`
--

DROP TABLE IF EXISTS `package`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `package` (
  `packageId` int NOT NULL AUTO_INCREMENT,
  `packageName` varchar(45) NOT NULL,
  `packageOverview` varchar(445) NOT NULL,
  `image` varchar(245) NOT NULL,
  `avlDates` varchar(45) NOT NULL,
  `packageAmt` int NOT NULL,
  `noOfDays` int NOT NULL,
  `noOfNights` int NOT NULL,
  `packageType` varchar(45) NOT NULL,
  `itinerary` varchar(445) NOT NULL,
  `gallery` varchar(45) NOT NULL,
  `include` varchar(545) NOT NULL,
  `exclud` varchar(445) NOT NULL,
  `sourceId` int NOT NULL,
  `destinationId` int NOT NULL,
  `hotelId` int NOT NULL,
  `isActive` tinyint NOT NULL,
  `isDelete` tinyint NOT NULL DEFAULT '0',
  `createdBy` varchar(45) NOT NULL DEFAULT 'admin',
  `createdDate` datetime NOT NULL,
  PRIMARY KEY (`packageId`),
  UNIQUE KEY `packageName_UNIQUE` (`packageName`),
  KEY `hotelId_idx` (`hotelId`),
  KEY `sourceId_idx` (`sourceId`),
  KEY `destinationId_idx` (`destinationId`),
  CONSTRAINT `destinationId` FOREIGN KEY (`destinationId`) REFERENCES `destination` (`destinationId`),
  CONSTRAINT `hotelId` FOREIGN KEY (`hotelId`) REFERENCES `hotel` (`hotelId`),
  CONSTRAINT `sourceId` FOREIGN KEY (`sourceId`) REFERENCES `source` (`sourceId`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `package`
--

LOCK TABLES `package` WRITE;
/*!40000 ALTER TABLE `package` DISABLE KEYS */;
INSERT INTO `package` VALUES (1,'c xzcv','DSfcsvfbgvfgn bcvbndghjnxgfhbxbdgfbfzgbv ','Afcsxdgvd','i7bjhxasgdc',21032,2,6,'xfghx','dxhbn ','cxhgbn m','chvbm n','cxm',1,2,5,1,0,'admin','2024-06-28 11:36:10'),(6,'gvb xgf','xzfgvb ','dfbhv','sdgzvg',4635,2,6,'fxnhbxvcgb','mslogfdhflgkjhdfkjhgkjbfgkhdsfiuhaklsdjhflakjhdf','fankgjsdfbdsfkgbndfb','n fdskgdsfbgkcxnvb','djbvg kbnkjnfdgb',4,4,4,0,0,'admin','2024-06-28 12:00:39'),(7,'Manali','gdkjydsgc','null','12',15202,21,4,'Couple','gvjcdah','null','gskudxwgs','hgbdjchg',4,4,2,1,0,'admin','2024-06-29 11:31:36'),(8,'gdgrd','dfdesf','null','45',54321,45,45,'fds','fdgr','null','dsfesd','fdsfe',4,4,4,1,0,'admin','2024-06-29 11:34:52');
/*!40000 ALTER TABLE `package` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roomtype`
--

DROP TABLE IF EXISTS `roomtype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roomtype` (
  `roomTypeId` int NOT NULL AUTO_INCREMENT,
  `roomTypeName` varchar(45) NOT NULL,
  `isActive` tinyint NOT NULL DEFAULT '1',
  `isDelete` tinyint NOT NULL DEFAULT '0',
  `createdBy` varchar(45) NOT NULL DEFAULT 'Admin',
  `createdDate` datetime NOT NULL,
  PRIMARY KEY (`roomTypeId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roomtype`
--

LOCK TABLES `roomtype` WRITE;
/*!40000 ALTER TABLE `roomtype` DISABLE KEYS */;
INSERT INTO `roomtype` VALUES (1,'Ac',1,0,'Admin','2024-05-16 11:19:10'),(2,'Non Ac',1,0,'Admin','2024-05-16 11:19:52'),(3,'Double Bed',1,0,'Admin','2024-05-16 11:21:36'),(4,'Deluxe',1,0,'Admin','2024-05-17 16:06:15'),(5,'Queen Bed',1,0,'Admin','2024-06-20 12:49:23'),(6,'Single bed',1,0,'Admin','2024-05-18 10:44:44'),(7,'King Bed',1,0,'Admin','2024-06-15 15:28:14');
/*!40000 ALTER TABLE `roomtype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `source`
--

DROP TABLE IF EXISTS `source`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `source` (
  `sourceId` int NOT NULL AUTO_INCREMENT,
  `sourceName` varchar(45) NOT NULL,
  `isActive` tinyint NOT NULL DEFAULT '1',
  `isDelete` tinyint NOT NULL DEFAULT '0',
  `createdBy` varchar(45) NOT NULL DEFAULT 'Admin',
  `createdDate` datetime NOT NULL DEFAULT '2024-05-02 12:00:00',
  PRIMARY KEY (`sourceId`),
  UNIQUE KEY `sourceName_UNIQUE` (`sourceName`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `source`
--

LOCK TABLES `source` WRITE;
/*!40000 ALTER TABLE `source` DISABLE KEYS */;
INSERT INTO `source` VALUES (1,'Vadodara',1,1,'Admin','2024-05-15 15:23:37'),(2,'Surat',1,1,'Admin','2024-05-15 15:10:47'),(3,'Rajkot',1,0,'Admin','2024-05-15 15:27:35'),(4,'Ahmedabad',1,0,'Admin','2024-06-20 12:51:45'),(5,'diu',1,1,'Admin','2024-05-18 10:41:57'),(6,'Bengaluru',1,0,'Admin','2024-06-01 11:42:11'),(7,'PARIS',1,0,'Admin','2024-06-20 17:40:46'),(8,'TAIPEI',1,0,'Admin','2024-06-20 17:41:26'),(9,'Nagpur',1,0,'Admin','2024-06-20 17:41:53'),(10,'Toronto	',0,0,'Admin','2024-06-20 17:43:14'),(11,'ROME	',1,0,'Admin','2024-06-20 17:43:58');
/*!40000 ALTER TABLE `source` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `userId` int NOT NULL AUTO_INCREMENT,
  `userName` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `phoneNo` int NOT NULL,
  `address` varchar(245) NOT NULL,
  `isActive` tinyint NOT NULL,
  `isDelete` tinyint NOT NULL,
  `createdDate` datetime NOT NULL,
  `createdBy` varchar(50) NOT NULL,
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'travela'
--

--
-- Dumping routines for database 'travela'
--
/*!50003 DROP PROCEDURE IF EXISTS `InsertOrUpdateCity` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOrUpdateCity`(
	IN Id INT, 
	IN CityName VARCHAR(50),
    IN IsActive TINYINT
    -- IN CreatedDate DATETIME
)
BEGIN
	IF EXISTS (SELECT 1 FROM city WHERE cityId = Id) THEN
        -- Update city
        UPDATE city
        SET cityName = CityName,
        isActive = IsActive,
        createdDate = now()
        WHERE cityId = Id;
        SELECT Id AS recid;
    ELSE
        -- Insert new city
        set Id=last_insert_id();
        INSERT INTO city (cityName, isActive, createdDate)
        VALUES (CityName, IsActive, now());
		select Id as recid;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertOrUpdateDestination` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOrUpdateDestination`(
	IN Id INT, 
	IN DestinationName VARCHAR(50),
    IN IsActive TINYINT
    -- IN CreatedDate DATETIME
)
BEGIN
	IF EXISTS (SELECT 1 FROM destination WHERE destinationId = Id) THEN
        -- Update destination
        UPDATE destination
        SET destinationName = DestinationName,
        isActive = IsActive,
        createdDate = now()
        WHERE destinationId = Id;
        SELECT Id AS recid;
    ELSE
        -- Insert new destination
        set Id=last_insert_id();
        INSERT INTO destination (destinationName, isActive, createdDate)
        VALUES (DestinationName, IsActive, now());
		select Id as recid;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertOrUpdateHotel` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOrUpdateHotel`(
	IN Id INT, 
    IN HotelImg VARCHAR(245),
	IN HotelName VARCHAR(45),
    IN HotelPhone INT,
    IN CityId INT,
    IN IsActive TINYINT
    -- IN CreatedDate DATETIME
)
BEGIN
	IF EXISTS (SELECT 1 FROM hotel WHERE hotelId = Id) THEN
        -- Update hotel
        UPDATE hotel
        SET hotelImage = HotelImg,
        hotelName = HotelName,
        hotelPhone = HotelPhone,
        cityId = CityId,
        isActive = IsActive,
        createdDate = now()
        WHERE hotelId = Id;
        SELECT Id AS recid;
    ELSE
        -- Insert new hotel
        INSERT INTO hotel (hotelImage, hotelName, hotelPhone, cityId, isActive, createdDate)
        VALUES (HotelImg, HotelName, HotelPhone, CityId, IsActive, now());
		set Id=last_insert_id();
		select Id as recid;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertOrUpdateHotelRooms` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOrUpdateHotelRooms`(
    IN p_HotelId INT,
    IN p_RoomTypeId INT,
    IN p_RoomNo INT,
    IN p_Amount DECIMAL,
    IN p_IsActive TINYINT
    -- IN CreatedDate DATETIME
)
BEGIN
    IF EXISTS (SELECT 1 FROM hotelrooms WHERE hotelId = p_HotelId AND roomNo = p_RoomNo) THEN
        -- Update existing hotel room record
        UPDATE hotelrooms
        SET roomTypeId = p_RoomTypeId,
            amount = p_Amount,
            isActive = p_IsActive,
			createdDate = now()
        WHERE hotelId = p_HotelId AND roomNo = p_RoomNo;
    ELSE
        -- Insert new hotel room record
        INSERT INTO hotelrooms (hotelId, roomTypeId, roomNo, amount, isActive, createdDate)
        VALUES (p_HotelId, p_RoomTypeId, p_RoomNo, p_Amount, p_IsActive, now());
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertOrUpdatePackage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOrUpdatePackage`(
	IN Id INT, 
	IN PackageName VARCHAR(50),
    IN PackageOverview VARCHAR(445),
    IN Image VARCHAR(245), 
    IN AvlDates VARCHAR(45),
    IN PackageAmt INT,
    IN NoOfDays INT,
    IN NoOfNights INT,
    IN PackageType VARCHAR(45),
    IN Itinerary VARCHAR(445),
    IN Gallery VARCHAR(45),
    IN Include VARCHAR(545),
    IN Exclud VARCHAR(445),
    IN SourceId INT,
    IN DestinationId INT,
    IN HotelId INT,
    IN IsActive TINYINT
    -- IN CreatedDate DATETIME
)
BEGIN
	IF EXISTS (SELECT 1 FROM package WHERE packageId = Id) THEN
        -- Update package
        UPDATE package
        SET packageName = PackageName,
        packageOverview = PackageOverview,
        image = Image,
        avlDates = AvlDates,
        packageAmt = PackageAmt,
        noOfDays = NoOfDays,
        noOfNights = NoOfNights,
        packageType = PackageType,
        itinerary = Itinerary,
        gallery = Gallery,
        include = Include,
        exclud = Exclud,
        sourceId = SourceId,
        destinationId = DestinationId,
        hotelId = HotelId,
        isActive = IsActive,
        createdDate = now()
        WHERE packageId = Id;
        SELECT Id AS recid;
    ELSE
        -- Insert new package
        INSERT INTO package (packageName, packageOverview, image, avlDates, packageAmt, noOfDays, noOfNights, packageType, itinerary, gallery, include, exclud, sourceId, destinationId, hotelId, isActive, createdDate)
        VALUES (PackageName, PackageOverview, Image, AvlDates, PackageAmt, NoOfDays, NoOfNights, PackageType, Itinerary, Gallery, Include, Exclud, SourceId, DestinationId, HotelId, IsActive, now());
		set Id=last_insert_id();
		select Id as recid;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertOrUpdateRoomType` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOrUpdateRoomType`(
	IN Id INT, 
	IN RoomTypeName VARCHAR(50),
    IN IsActive TINYINT
    -- IN CreatedDate DATETIME
)
BEGIN
	IF EXISTS (SELECT 1 FROM roomtype WHERE roomTypeId = Id) THEN
        -- Update room type
        UPDATE roomtype
        SET roomTypeName = RoomTypeName,
        isActive = IsActive,
        createdDate = now()
        WHERE roomTypeId = Id;
        SELECT Id AS recid;
    ELSE
        -- Insert new room type
        set Id=last_insert_id();
        INSERT INTO roomtype (roomTypeName, isActive, createdDate)
        VALUES (RoomTypeName, IsActive, now());
		select Id as recid;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertOrUpdateSource` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOrUpdateSource`(
	IN Id INT, 
	IN SourceName VARCHAR(50),
    IN IsActive TINYINT
    -- IN CreatedDate DATETIME
)
BEGIN
	IF EXISTS (SELECT 1 FROM source WHERE sourceId = Id) THEN
        -- Update source
        UPDATE source
        SET sourceName = SourceName,
        isActive = IsActive,
        createdDate = now()
        WHERE sourceId = Id;
        SELECT Id AS recid;
    ELSE
        -- Insert new source
        set Id=last_insert_id();
        INSERT INTO source (sourceName, isActive, createdDate)
        VALUES (SourceName, IsActive, now());
		select Id as recid;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_GetCity` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_GetCity`()
BEGIN
	Select * from city where isDelete = 0 order by 1 desc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_GetDestination` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_GetDestination`()
BEGIN
	Select * from destination where isDelete = 0 order by 1 desc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_GetHotel` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_GetHotel`()
BEGIN
    SELECT
        city.cityName AS strcity,
        hotel.*, 
        city.cityName
    FROM 
        hotel hotel 
    INNER JOIN 
        city city ON hotel.cityId = city.cityId
    WHERE 
        hotel.isDelete = 0
    ORDER BY 
        hotel.createdDate DESC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_GetHotelRooms` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_GetHotelRooms`()
BEGIN
	Select * from hotelrooms where isDelete = 0 order by 1 desc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_GetPackage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_GetPackage`()
BEGIN
	Select * from package where isDelete = 0 order by 1 desc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_GetRoomType` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_GetRoomType`()
BEGIN
	Select * from roomtype where isDelete = 0 order by 1 desc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_GetSource` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_GetSource`()
BEGIN
	Select * from source where isDelete = 0;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveCity` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveCity`(in Id INT)
BEGIN
	update city set isDelete=1  where cityId=Id ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveDestination` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveDestination`(in Id INT)
BEGIN
	update destination set isDelete=1  where destinationId=Id ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveHotel` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveHotel`(in Id INT)
BEGIN
	update hotel set isDelete=1  where hotelId=Id ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemovePackage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemovePackage`(in Id INT)
BEGIN
	update package set isDelete=1  where packageId=Id ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveRooms` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveRooms`(IN p_HotelRoomId INT)
BEGIN
    update hotelrooms set isDelete=1  where hotelRoomsId = p_HotelRoomId ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveRoomType` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveRoomType`(in Id INT)
BEGIN
	update roomtype set isDelete=1  where roomTypeId=Id ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveSource` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveSource`(in Id INT)
BEGIN
	update source set isDelete=1  where sourceId=Id ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-29 16:39:20
