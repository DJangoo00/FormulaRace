-- formularace.team definition
CREATE TABLE
    `team` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
        PRIMARY KEY (`Id`),
        UNIQUE KEY `equipos_Nombre_IDX` (`name`) USING BTREE
    ) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;

-- formularace.driver definition
CREATE TABLE
    `driver` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `name` varchar(60) DEFAULT NULL,
        `age` int DEFAULT NULL,
        `IdTeam` int DEFAULT NULL,
        PRIMARY KEY (`Id`),
        KEY `driver_FK` (`IdTeam`)
    ) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;

-- formularace.teamdriver definition
CREATE TABLE
    `teamdriver` (
        `IdTeam` int NOT NULL,
        `IdDriver` int NOT NULL,
        PRIMARY KEY (`IdTeam`, `IdDriver`),
        KEY `teamdriver_FK_1` (`IdDriver`),
        CONSTRAINT `teamdriver_FK` FOREIGN KEY (`IdTeam`) REFERENCES `team` (`Id`),
        CONSTRAINT `teamdriver_FK_1` FOREIGN KEY (`IdDriver`) REFERENCES `driver` (`Id`)
    ) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;