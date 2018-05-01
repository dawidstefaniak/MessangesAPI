BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
	`MigrationId`	TEXT NOT NULL,
	`ProductVersion`	TEXT NOT NULL,
	CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY(`MigrationId`)
);
INSERT INTO `__EFMigrationsHistory` VALUES ('20180412120933_ConnectMessageWithCaseInitial','2.0.2-rtm-10011');
INSERT INTO `__EFMigrationsHistory` VALUES ('20180420094613_CaseStatusAdded','2.0.2-rtm-10011');
INSERT INTO `__EFMigrationsHistory` VALUES ('20180420095140_CaseStatusAdded2','2.0.2-rtm-10011');
INSERT INTO `__EFMigrationsHistory` VALUES ('20180420095908_CaseStatusAdded3','2.0.2-rtm-10011');
CREATE TABLE IF NOT EXISTS `Users` (
	`UserId`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`CreationDate`	TEXT NOT NULL,
	`Email`	TEXT NOT NULL,
	`FirstName`	TEXT NOT NULL,
	`Password`	TEXT NOT NULL,
	`SecondName`	TEXT NOT NULL,
	`UserName`	TEXT NOT NULL,
	`UserType`	TEXT NOT NULL,
	CONSTRAINT `AlternateKey_Username` UNIQUE(`UserName`)
);
INSERT INTO `Users` VALUES (0,'2017-04-21 22:14:40','ctott9@ustream.tv','Cosmo','aZTtn2h','Tott','ctott9','U');
INSERT INTO `Users` VALUES (1,'2017-04-20 02:51:22','tparram0@blog.com','Toinette','pass','Parram','tparram0','P');
INSERT INTO `Users` VALUES (2,'2018-01-05 05:12:51','ccloake1@free.fr','Charo','FUXZJweLBON','Cloake','ccloake1','U');
INSERT INTO `Users` VALUES (3,'2017-08-23 10:39:51','abridel2@spiegel.de','Arte','fho54E','Bridel','abridel2','P');
INSERT INTO `Users` VALUES (4,'2017-10-14 01:44:47','jsussans3@joomla.org','Joycelin','WdfwDKR','Sussans','jsussans3','U');
INSERT INTO `Users` VALUES (5,'2017-06-21 09:56:37','smacgee4@spiegel.de','Svend','KAr7Of6g6H','MacGee','smacgee4','P');
INSERT INTO `Users` VALUES (6,'2018-01-27 21:13:52','sepelett5@netlog.com','Saloma','NJpbwkRZd','Epelett','sepelett5','P');
INSERT INTO `Users` VALUES (7,'2018-03-02 03:34:25','ppullinger6@ustream.tv','Prudy','p10GKzD8b','Pullinger','ppullinger6','P');
INSERT INTO `Users` VALUES (8,'2017-05-21 16:47:47','pworthington7@yellowpages.com','Polly','ETYnRNv','Worthington','pworthington7','U');
INSERT INTO `Users` VALUES (9,'2018-03-19 04:18:04','vcarnier8@1und1.de','Virginia','DddbHQMr','Carnier','vcarnier8','P');
INSERT INTO `Users` VALUES (15,'2018-04-12 14:41:21.52351','Email@email.com','Dawid','test1','Stefaniak','test1','U');
CREATE TABLE IF NOT EXISTS `TypesOfCrime` (
	`TypeOfCrimeId`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`CrimeDescription`	TEXT NOT NULL
);
INSERT INTO `TypesOfCrime` VALUES (0,'Theft');
INSERT INTO `TypesOfCrime` VALUES (1,'Rape');
INSERT INTO `TypesOfCrime` VALUES (2,'Burglary ');
CREATE TABLE IF NOT EXISTS `Messages` (
	`MessageId`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`CaseId`	INTEGER NOT NULL,
	`MessageText`	TEXT,
	`IsPoliceSender` BOOLEAN NOT NULL,
	`SentDate`	TEXT NOT NULL,
	CONSTRAINT `FK_Messages_Cases_CaseId` FOREIGN KEY(`CaseId`) REFERENCES `Cases`(`CaseId`) ON DELETE RESTRICT,
);
CREATE TABLE IF NOT EXISTS `Cases` (
	`CaseId`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`Address`	TEXT NOT NULL,
	`Email`	TEXT NOT NULL,
	`FirstName`	TEXT NOT NULL,
	`OfficerId`	INTEGER NOT NULL,
	`PhoneNumber`	TEXT NOT NULL,
	`RefNumber`	TEXT NOT NULL,
	`ReportDate`	TEXT NOT NULL,
	`SecondName`	TEXT NOT NULL,
	`TypeOfCrimeId`	INTEGER NOT NULL,
	`CaseStatus`	TEXT,
	CONSTRAINT `AlternateKey_RefNumber` UNIQUE(`RefNumber`),
	CONSTRAINT `FK_Cases_TypesOfCrime_TypeOfCrimeId` FOREIGN KEY(`TypeOfCrimeId`) REFERENCES `TypesOfCrime`(`TypeOfCrimeId`) ON DELETE RESTRICT,
	CONSTRAINT `FK_Cases_Users_OfficerId` FOREIGN KEY(`OfficerId`) REFERENCES `Users`(`UserId`) ON DELETE RESTRICT
);
INSERT INTO `Cases` VALUES (1,'Peacock Street, Clanny House Block 11 Flat 92 SR57DD','ctott9@ustream.tv','Cosmo',1,'+44 2010392049','S239CDL20W','2018-01-27 21:13:52','Tott',0,'In Progress');
INSERT INTO `Cases` VALUES (2,'Peacock Street, Clanny House Block 11 Flat 92 SR57DD','ctott9@ustream.tv','Cosmo',1,'+44 2010392049','S239CDL20P','2018-01-27 21:13:52','Tott',1,'In Progress');

CREATE INDEX IF NOT EXISTS `IX_Messages_CaseId` ON `Messages` (
	`CaseId`
);
CREATE INDEX IF NOT EXISTS `IX_Cases_TypeOfCrimeId` ON `Cases` (
	`TypeOfCrimeId`
);
CREATE INDEX IF NOT EXISTS `IX_Cases_OfficerId` ON `Cases` (
	`OfficerId`
);
COMMIT;
