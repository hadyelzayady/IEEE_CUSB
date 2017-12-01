
CREATE TABLE IF NOT EXISTS `MahmoudMorsy`.`Volunteer` (
  `ID` INT auto_increment NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `Gender` CHAR NOT NULL,
  `National_ID` VARCHAR(14) NOT NULL,
  `Birthdate` DATE NULL,
  `Mobile` VARCHAR(11) NULL,
  `Job_Title` VARCHAR(45) NULL,
  `Activity_Status` INT NOT NULL,
  `Responsibility_Description` VARCHAR(45) NULL,
  `Mail` VARCHAR(45) NULL,
  `College` VARCHAR(45) NULL,
  `University` VARCHAR(45) NULL,
  `Department` VARCHAR(45) NULL,
  `Graduation_Year` YEAR NULL,
  `Committee_ID` INT NOT NULL,
  `Helping_Comm_ID` INT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC),
  UNIQUE INDEX `Mobile_UNIQUE` (`Mobile` ASC),
  FOREIGN KEY (`Committee_ID`)
    REFERENCES `MahmoudMorsy`.`Committee` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`Helping_Comm_ID`)
    REFERENCES `MahmoudMorsy`.`Committee` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    CREATE TABLE IF NOT EXISTS `MahmoudMorsy`.`Committee` (
  `Season` YEAR NOT NULL,
  `ID` INT auto_increment NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `Start_Date` DATE NULL,
  `End_Date` DATE NULL,
  `Head_ID` INT NOT NULL,
  `Vice_ID` INT NOT NULL,
  `Section_ID` INT NOT NULL,
  PRIMARY KEY (`Season`, `ID`),
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC),
  UNIQUE INDEX `Head_ID_UNIQUE` (`Head_ID` ASC),
  UNIQUE INDEX `Vice_ID_UNIQUE` (`Vice_ID` ASC),
    FOREIGN KEY (`Head_ID`)
    REFERENCES `MahmoudMorsy`.`Volunteer` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`Vice_ID`)
    REFERENCES `MahmoudMorsy`.`Volunteer` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`Section_ID`)
    REFERENCES `MahmoudMorsy`.`Section` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE IF NOT EXISTS `MahmoudMorsy`.`Request` (
  `ID` INT auto_increment NOT NULL,
  `Title` VARCHAR(45) NOT NULL,
  `Description` VARCHAR(45) NULL,
  `Priority` INT NULL,
  `Creation_Date` DATE NULL,
  `End_Date` DATE NULL,
  `Start_Date` DATE NULL,
  `Deadline_Date` DATE NULL,
  `Sender_Comm_ID` INT NOT NULL,
  `Reciever_Comm_ID` INT NOT NULL,
   `Progress_Description` VARCHAR(100) NULL,
  PRIMARY KEY (`ID`),
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC),
  FOREIGN KEY (`Sender_Comm_ID`)
    REFERENCES `MahmoudMorsy`.`Committee` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  FOREIGN KEY (`Sender_Comm_ID`)
    REFERENCES `MahmoudMorsy`.`Committee` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    CREATE TABLE IF NOT EXISTS `MahmoudMorsy`.`Section` (
  `Season` YEAR NOT NULL,
  `ID` INT NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `Description` VARCHAR(45) NULL,
  `Supervisor_ID` INT NOT NULL,
  PRIMARY KEY (`Season`, `ID`),
  FOREIGN KEY (`Supervisor_ID`)
    REFERENCES `MahmoudMorsy`.`Volunteer` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE IF NOT EXISTS `MahmoudMorsy`.`Participant` (
  `ID` INT auto_increment NOT NULL,
  `National_ID` VARCHAR(14) NOT NULL,
  `Name` VARCHAR(45) NULL,
  `Gender` CHAR NOT NULL,
  `Birthdate` DATE NULL,
  `Mobile` VARCHAR(11) NULL,
  `Mail` VARCHAR(45) NULL,
  `Activity_Status` INT NULL,
  `College` VARCHAR(45) NULL,
  `University` VARCHAR(45) NULL,
  `Department` VARCHAR(45) NULL,
  PRIMARY KEY (`ID`),
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC),
  UNIQUE INDEX `National_ID_UNIParQUE` (`National_ID` ASC));

CREATE TABLE IF NOT EXISTS `MahmoudMorsy`.`Session` (
  `Number` INT NOT NULL,
  `Workshop_ID` INT NOT NULL,
  `Title` VARCHAR(45) NOT NULL,
  `Date` DATE NULL,
  `Location` VARCHAR(45) NULL,
  `Status` VARCHAR(45) NULL,
  PRIMARY KEY (`Number`,`Workshop_ID`),
  FOREIGN KEY (`Workshop_ID`)
    REFERENCES `MahmoudMorsy`.`Workshop` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE IF NOT EXISTS `MahmoudMorsy`.`Task` (
  `ID` INT auto_increment NOT NULL,
  `Title` VARCHAR(45) NOT NULL,
  `Start_Date` DATE NULL,
  `End_Date` DATE NULL,
  `Creation_Date` DATE NULL,
  `Deadline_Date` DATE NULL,
  `Submission_Date` DATE NULL,
  `Progress` INT NULL,
  `Status` enum ('Accepted','Rejected'),
  `Committee_ID` INT NOT NULL,
  `Assigner_ID` INT NOT NULL,
  `Reciever_ID` INT NOT NULL,
  PRIMARY KEY (`ID`),
  FOREIGN KEY (`Committee_ID`)
    REFERENCES `MahmoudMorsy`.`Committee` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  FOREIGN KEY (`Assigner_ID`)
    REFERENCES `MahmoudMorsy`.`Volunteer` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`Reciever_ID`)
    REFERENCES `MahmoudMorsy`.`Volunteer` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE IF NOT EXISTS `MahmoudMorsy`.`Event` (
  `ID` INT auto_increment NOT NULL,
  `Title` VARCHAR(45) NOT NULL,
  `Description` VARCHAR(125) NULL,
  `Start_Date` DATE NULL,
  `End_Date` DATE NULL,
  `Committee_ID` INT NOT NULL,
  PRIMARY KEY (`ID`),
  FOREIGN KEY (`Committee_ID`)
    REFERENCES `MahmoudMorsy`.`Committee` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


CREATE TABLE IF NOT EXISTS `MahmoudMorsy`.`Workshop` (
  `ID` INT auto_increment NOT NULL,
  `Committee_ID` INT NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `Outline` VARCHAR(45) NULL,
  `Progress` INT NULL,
  `Start_Date` DATE NULL,
  `End_Date` DATE NULL,
  PRIMARY KEY (`ID`),
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC),
  FOREIGN KEY (`Committee_ID`)
    REFERENCES `MahmoudMorsy`.`Committee` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE IF NOT EXISTS `MahmoudMorsy`.`Message` (
  `ID` INT auto_increment NOT NULL,
  `Sender_ID` INT NOT NULL,
  `Reciever_ID` INT NOT NULL,
  `Text` VARCHAR(255) NOT NULL,
  `Send_Date` DATE NULL,
  `Delivery_Status` INT NULL,
  PRIMARY KEY (`ID`),
  FOREIGN KEY (`Sender_ID`)
    REFERENCES `MahmoudMorsy`.`Volunteer` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`Reciever_ID`)
    REFERENCES `MahmoudMorsy`.`Volunteer` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


CREATE TABLE IF NOT EXISTS `MahmoudMorsy`.`Complaint` (
  `ID` INT auto_increment NOT NULL,
  `Sender_ID` INT NOT NULL,
  `Title` VARCHAR(45) NOT NULL,
  `Description` VARCHAR(255) NULL,
  `Date` DATE NULL,
  `Status` INT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC),
  FOREIGN KEY (`Sender_ID`)
    REFERENCES `MahmoudMorsy`.`Volunteer` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


CREATE TABLE IF NOT EXISTS `MahmoudMorsy`.`Timetable` (
  `Vol_ID` INT NOT NULL,
  `Saturday` VARCHAR(255) NOT NULL,
  `Sunday` VARCHAR(255) NULL,
  `Monday` VARCHAR(255) NULL,
  `Tuesday` VARCHAR(255) NULL,
  `Wednesday` VARCHAR(255) NULL,
  `Thursday` VARCHAR(255) NULL,
  `Friday` VARCHAR(255) NULL,
  PRIMARY KEY (`Vol_ID`),
  UNIQUE INDEX `Vol_ID_UNIQUE` (`Vol_ID` ASC),
  FOREIGN KEY (`Vol_ID`)
    REFERENCES `MahmoudMorsy`.`Volunteer` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE IF NOT EXISTS `MahmoudMorsy`.`File` (
  `ID` INT auto_increment NOT NULL,
  `Title` VARCHAR(45) NOT NULL,
  `Description` VARCHAR(255) NULL,
  `Version` INT NOT NULL,
  `Opened` INT NULL,
  `Type` VARCHAR(45) NULL,
  `Writer_ID` INT NOT NULL,
  `Committee_ID` INT NOT NULL,
  PRIMARY KEY (`ID`,`Version`),
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC),
  FOREIGN KEY (`Writer_ID`)
    REFERENCES `MahmoudMorsy`.`Volunteer` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  FOREIGN KEY (`Committee_ID`)
    REFERENCES `MahmoudMorsy`.`Committee` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE IF NOT EXISTS `MahmoudMorsy`.`Notification` (
  `ID` INT auto_increment NOT NULL,
  `Description` VARCHAR(255) NOT NULL,
  `Type` VARCHAR(45) NOT NULL,
  `Vol_ID` INT NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC),
   FOREIGN KEY (`Vol_ID`)
    REFERENCES `MahmoudMorsy`.`Volunteer` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
  
  CREATE TABLE IF NOT EXISTS `MahmoudMorsy`.`Volunteer_Workshop_Enrolled` (
  `Workshop_ID` INT NOT NULL,
  `Volunteer_ID` INT NOT NULL,
  FOREIGN KEY (`Workshop_ID`)
    REFERENCES `MahmoudMorsy`.`Workshop` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`Volunteer_ID`)
    REFERENCES `MahmoudMorsy`.`Volunteer` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


CREATE TABLE IF NOT EXISTS `MahmoudMorsy`.`Participant_Workshop_Enrolled` (
  `Workshop_ID` INT NOT NULL,
  `Participant_ID` INT NOT NULL,
  FOREIGN KEY (`Workshop_ID`)
    REFERENCES `MahmoudMorsy`.`Workshop` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`Participant_ID`)
    REFERENCES `MahmoudMorsy`.`Volunteer` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
CREATE TABLE IF NOT EXISTS `MahmoudMorsy`.`Volunteer_Session_Attend` (
  `Session_Number` INT NOT NULL,
  `Workshop_ID` INT NOT NULL,
  `Attender_ID` INT NOT NULL,
  FOREIGN KEY (`Session_Number`)
    REFERENCES `MahmoudMorsy`.`Session` (`Number`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  FOREIGN KEY (`Workshop_ID`)
    REFERENCES `MahmoudMorsy`.`Workshop` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`Attender_ID`)
    REFERENCES `MahmoudMorsy`.`Volunteer` (`ID`)
    OEventN DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE IF NOT EXISTS `MahmoudMorsy`.`Participant_Session_Attend` (
  `Session_Number` INT NOT NULL,
  `Workshop_ID` INT NOT NULL,
  `Attender_ID` INT NOT NULL,
  FOREIGN KEY (`Session_Number`)
    REFERENCES `MahmoudMorsy`.`Session` (`Number`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  FOREIGN KEY (`Workshop_ID`)
    REFERENCES `MahmoudMorsy`.`Workshop` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`Attender_ID`)
    REFERENCES `MahmoudMorsy`.`Volunteer` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);   



