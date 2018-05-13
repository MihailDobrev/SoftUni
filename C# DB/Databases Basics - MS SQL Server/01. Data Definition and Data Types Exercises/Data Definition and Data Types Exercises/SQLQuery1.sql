--Problem 1.	Create Database
CREATE DATABASE Minions

--Problem 2.	Create Tables
CREATE TABLE Minions(
Id INT PRIMARY KEY,
[Name] NVARCHAR(50),
Age INT
)

CREATE TABLE Towns(
Id INT PRIMARY KEY,
[Name] NVARCHAR(50)
)

--Problem 3.	Alter Minions Table
ALTER TABLE Minions
ADD TownId INT


ALTER TABLE Minions
ADD CONSTRAINT FK_TownId
FOREIGN KEY (TownId) REFERENCES Towns(Id) 


--Problem 4.	Insert Records in Both Tables

INSERT INTO Towns(Id, [Name]) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions(Id, [Name], Age, TownId) VALUES
(1,'Kevin', 22, 1),
(2,'Bob', 15, 3),
(3,'Steward', NULL, 2)


--Problem 5.	Truncate Table Minions

TRUNCATE TABLE Minions

--Problem 6.	Drop All Tables

DROP TABLE Minions
DROP TABLE Towns

--Problem 7.	Create Table People

USE Minions

CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX),
Height DECIMAL(15,2),
[Weight] DECIMAL(15,2),
Gender CHAR NOT NULL,
Birthdate DATE NOT NULL,
Biography NVARCHAR(MAX)
)
INSERT INTO People VALUES
('Gosho', 0101, 180.05, 80.06,'m', '1991-05-08','He was born in 1990. He started school in 1996 and finished 2004'),
('Pesho', 0101101, 175.05,85.06,'m', '1989-10-09' ,'He was born in 1989. He started school in 1996 and finished 2004'),
('Drago', 01001101, 182.04,84.01,'m', '1994-01-09' ,'He was born in 1994. He started school in 2000 and finished 2006'),
('Jana', 01101101, 182.04,84.01,'f', '1994-01-09' ,'He was born in 1994. He started school in 2000 and finished 2006'),
('Mitko', 011011101, 176.02,84.01,'m', '1996-01-09' ,'He was born in 1996. He started school in 2000 and finished 2006')

--Problem 8.	Create Table Users

CREATE TABLE Users(
Id BIGINT UNIQUE IDENTITY,
Username NVARCHAR(30) NOT NULL,
[Password] NVARCHAR(26),
ProfilePicture VARBINARY(MAX),
LastLoginTime DATE,
IsDeleted BIT
)

INSERT INTO Users VALUES
('Gosho', 'pass1', 0101110,'1997-05-07',1),
('Pesho', 'pass2', 0101001110,'1995-05-04',0),
('Dobrin', 'pass3', 0101110,'1994-02-08',1),
('Mimi', 'pass4', 011010011110,'1993-05-08', 0),
('Ginka', 'pass5', 010011110,'1992-06-08', 1)

--Problem 9.	Change Primary Key
ALTER TABLE Users
ADD CONSTRAINT PK_USERS
PRIMARY KEY (Id)

ALTER TABLE Users
DROP CONSTRAINT PK_USERS

ALTER TABLE Users
ADD CONSTRAINT PK_USERS 
PRIMARY KEY (Id, Username)

--Problem 10.	Add Check Constraint

ALTER TABLE Users
ADD CONSTRAINT PasswordLenght
CHECK (LEN([Password])>=5)

--Problem 11.	Set Default Value of a Field
 
ALTER TABLE Users
ADD DEFAULT GETDATE()
FOR LastLoginTime

--Problem 12.	Set Unique Field
ALTER TABLE Users
DROP CONSTRAINT PK_USERS

ALTER TABLE Users
ADD CONSTRAINT PK_USERS
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT UsernameLenght
CHECK (LEN(Username)>=3)

--Problem 13.	Movies Database

CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY,
DirectorName NVARCHAR(50),
Notes NVARCHAR(MAX)
)

CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY,
GenreName NVARCHAR(50),
Notes NVARCHAR(MAX)
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(50),
Notes NVARCHAR(MAX)
)

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(50),
DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
CopyrightYear DATE,
[Length] DECIMAL(15,2),
GenreId INT FOREIGN KEY REFERENCES Genres(Id),
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Rating INT,
Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName, Notes) VALUES
('Steven Spielberg', 'One of the most influential personalities in the history of cinema'),
('Martin Scorsese','Martin Charles Scorsese was born on November 17, 1942 in Queens'),
('Alfred Hitchcock', 'Alfred Joseph Hitchcock was born in Leytonstone, Essex, England.'),
('Stanley Kubrick','Stanley Kubrick was born in Manhattan, New York City, to Sadie Gertrude (Perveler) and Jacob Leonard Kubrick, a physician.'),
('Quentin Tarantino','Quentin Jerome Tarantino was born in Knoxville, Tennessee. His father, Tony Tarantino, is an Italian-American actor and musician from New York, and his mother')

INSERT INTO Genres(GenreName, Notes) VALUES
('Action Comedies', '43040'),
('Action Thrillers','43048'),
('Dark Comedies','869'),
('Thriller','4922'),
('Dramas based on Books','4961')

INSERT INTO Categories(CategoryName, Notes) VALUES
('Action & Adventure', '1365'),
('Comedies','6548'),
('Dramas','5763'),
('Documentaries','6839'),
('Horror Movies','8711')

INSERT INTO Movies(Title, DirectorId,CopyrightYear,[Length], GenreId, CategoryId, Rating, Notes) VALUES
('Jaws',1,'1975-06-20',124,5,5,9, 'Jaws is a 1975 American thriller film directed by Steven Spielberg and based on Peter Benchleys 1974 novel of the same name'),
('Minority Report',1,'2002-05-06',145,4,1,8, 'In a future where a special police unit is able to arrest murderers before they commit their crimes, an officer from that unit is himself accused of a future murder.'),
('2001: A Space Odyssey',3,'1968-01-09',146.2,1,1,10, 'Humanity finds a mysterious, obviously artificial object buried beneath the Lunar surface'),
('Reservoir Dogs ',5,'1992-05-06',139.5,1,1,10, 'After a simple jewelry heist goes terribly wrong, the surviving criminals begin to suspect that one of them is a police informant.'),
('Psycho',3,'1960-05-09',110,4,5,9, 'A Phoenix secretary embezzles $40,000 from her employers client, goes on the run, and checks into a remote motel run by a young man under the domination of his mother.')

--Problem 14.	Car Rental Database

CREATE DATABASE CarRental 

USE CarRental

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY NOT NULL,
CategoryName NVARCHAR(50) NOT NULL,
DailyRate DECIMAL(15,2),
WeeklyRate DECIMAL(15,2),
MonthlyRate DECIMAL(15,2),
WeekendRate DECIMAL(15,2)
)

CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY NOT NULL,
PlateNumber NVARCHAR(20) UNIQUE NOT NULL,
Manufacturer NVARCHAR(50) NOT NULL,
Model NVARCHAR(50) NOT NULL,
CarYear INT NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
Doors INT NOT NULL,
Picture VARBINARY(MAX),
Condition NVARCHAR(50) NOT NULL,
Available BIT NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Title NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY NOT NULL,
DriverLicenceNumber INT NOT NULL,
FullName NVARCHAR(50) NOT NULL,
[Address] NVARCHAR(250) NOT NULL,
City NVARCHAR(50) NOT NULL,
ZIPCode INT,
Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders(
Id INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
TankLevel DECIMAL(15,2) NOT NULL,
KilometrageStart INT NOT NULL,
KilometrageEnd INT NOT NULL,
TotalKilometrage INT,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
TotalDays INT,
RateApplied DECIMAL(15,2) NOT NULL,
TaxRate DECIMAL(15,2) NOT NULL,
OrderStatus BIT NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)  VALUES
('Hedgeback', 0.2, 1.4, 5.5, 0.4),
('Sedan', 0.1, 1.1, 4.5 ,0.2),
('Combi', 0.3, 1.8, 7.5 ,1.4)


INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('H1234JK', 'BMW','320',2004, 3 ,4 ,011010101110,'In good condition', 1),
('H4567IO', 'Audi','A4', 2003, 2 , 2 ,011010101101110,'In good condition', 1),
('H7890PL', 'Volkswagen','MK-4', 1999, 1 , 2 ,01101100101110,'In good condition', 1)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Pesho', 'Petrov','Manager', NULL),
('Ivan', 'Ivanov','Seller', NULL),
('Mitko', 'Dimitrov','Repairman', NULL)

INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
( 644518, 'Vanyo Georgiev','Maritza str. 16', 'Sliven', 4587, NULL),
( 644518, 'Bogomil Pavlov','Vasil Levski str. 20', 'Stara Zagora', 5787, NULL),
( 645614, 'Krasimir Kostov','Hristo Botev str. 05', 'Petrich', 7587, NULL)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES
(2,2,1,80,150100, 150300, 200, '2018-05-06', '2018-05-12', 50 ,5, 20, 1, 'The order was taken onlihe'),
(2,1,2,100,180400, 180600, 200, '2018-03-12', '2018-03-20', 40 ,10, 20, 0, 'The order was ordered by the phone'),
(2,3,3,120,101300, 101600, 300, '2018-04-15', '2018-05-22', 50 ,15, 20, 0, 'The order was taken onlihe')

--Problem 15.	Hotel Database

CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Title NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Customers(
AccountNumber INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
PhoneNumber NVARCHAR(20),
EmergencyName NVARCHAR(50),
EmergencyNumber NVARCHAR(20),
Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus(
RoomStatus NVARCHAR(20) PRIMARY KEY NOT NULL,
Notes NVARCHAR(MAX)
) 

CREATE TABLE RoomTypes(
RoomType NVARCHAR(50) PRIMARY KEY NOT NULL,
Notes NVARCHAR(MAX)
) 

CREATE TABLE BedTypes(
BedType NVARCHAR(20) PRIMARY KEY NOT NULL,
Notes NVARCHAR(MAX)
) 

CREATE TABLE Rooms(
RoomNumber INT PRIMARY KEY IDENTITY,
RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
BedType NVARCHAR(20) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
Rate SMALLINT,
RoomStatus NVARCHAR(20) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
Notes NVARCHAR(MAX)
) 

CREATE TABLE Payments (
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
PaymentDate DATE NOT NULL,
AccountNumber NVARCHAR(30) NOT NULL,
FirstDateOccupied DATE NOT NULL,
LastDateOccupied DATE NOT NULL,
TotalDays INT NOT NULL,
AmountCharged DECIMAL(15,2) NOT NULL,
Rate SMALLINT,
TaxRate DECIMAL(10,2),
TaxAmount DECIMAL(10,2),
PaymentTotal MONEY NOT NULL,
Notes NVARCHAR(MAX)
) 

CREATE TABLE Occupancies(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
DateOccupied DATE NOT NULL,
AccountNumber NVARCHAR(30) NOT NULL,
RoomNumber SMALLINT,
RateApplied SMALLINT,
PhoneCharge DECIMAL(10,2),
Notes NVARCHAR(MAX)
)

INSERT INTO Employees VALUES
('Kancho', 'Ivanov', 'Receptionist', 'Loyal and hard-working'),
('Petar', 'Stamatov', 'Security guard', 'Helpful and patrols well'),
('Stoyanka', 'Dimitrova', 'Maid', 'Keeps the rooms always tidy')

INSERT INTO Customers VALUES
('Drago', 'Georgiev', '+3598889548234', 'Stoycho','+359888458135', 'Booked for 5 days' ),
('Mariyana', 'Vladimirova', '+359888548631', 'Galia','+3598888452436','Booked for 8 days'),
('Plamen', 'Yordanov', '+359888785135', 'Ico','+359888485923' ,'Booked for 9 days')

INSERT INTO RoomStatus VALUES
('Occupied','Cannot be used by other clients but can be entered from cleaning staff'),
('Avaliable', 'Free to be used by clients and cleaning staff'),
('DO NOT DISTURB!', 'Cannot be used by either clients nor cleaning staff')

INSERT INTO RoomTypes VALUES
('Standart room with 1 bed','Cannot be used by other clients but can be entered from cleaning staff'),
('Standart room with 2 beds', 'Free to be used by clients and cleaning staff'),
('Luxurious room with 1 large bed', 'Cannot be used by either clients nor cleaning staff')

INSERT INTO BedTypes VALUES
('Small for 1', 'It is the common bed that is placed in most standart rooms'),
('Large for 2', 'It is placed in some standart rooms for couples'),
('Large for 1', 'Only available in a kuxurious rooms')

INSERT INTO Rooms(RoomType,BedType,Rate,RoomStatus,Notes) VALUES
('Standart room with 1 bed','Small for 1', 3,'Occupied','Room 105 on first floor'),
('Standart room with 1 bed', 'Large for 2', 4, 'Avaliable', 'Room 204 on second floor'),
('Luxurious room with 1 large bed','Large for 1', 6, 'DO NOT DISTURB!', 'Room 402 on top floor')

INSERT INTO Payments VALUES
(1,'2018-04-09', 'BGUNCR-9881-6554-1453-7825','2018-04-08','2018-04-11',3, 80.2,3, 5 ,4.05,84.25, 'The client payed in cash'),
(1,'2018-04-20', 'BGUNCR-9881-4524-4895-1258','2018-04-10','2018-04-20',4, 250.4, 10, 20, 50, 300.4, 'The client payed with his debit card'),
(1,'2018-04-12', 'BGUNCR-9881-7528-4825-2485','2018-04-12','2018-04-18',6, 300.60, 6, 10,30, 330.60, 'The client payed with his credit card')

INSERT INTO Occupancies VALUES
(1,'2018-04-16', 'BGUNC-9881-6554-1453-7825', 424, 5, 3.5, 'Kancho is occuping room 424 for period 16.04 to 21.04.'),
(2,'2018-04-16', 'BGUBB-9881-4524-4895-1258', 153, 10, 4.2, 'Petar is occuping room 153 for period 16.04 to 21.04.'),
(3,'2018-04-23', 'BGCIB-9881-7528-4825-2485', 244, 15, 5.6, 'Stoyanka is occuping room 244 for period 16.04 to 21.04.')

--Problem 16.	Create SoftUni Database

CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY,
AddressText NVARCHAR(250) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL, 
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
JobTitle NVARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
HireDate DATE NOT NULL,
Salary MONEY NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

INSERT INTO Towns VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees(FirstName,MiddleName,LastName,JobTitle,DepartmentId,HireDate,Salary) VALUES
('Ivan','Ivanov','Ivanov','.NET Developer',4,'2013-02-01', 3500.00),
('Petar','Petrov','Petrov','Senior Engineer',1,'2004-03-01', 4000.00),
('Maria','Petrova','Ivanova','Intern',5,'2016-08-28', 525.25),
('Georgi','Teziev','Ivanov','CEO',2,'2007-12-09', 3000.00),
('Peter','Pan','Pan','Intern',3,'2016-08-28', 599.88)


--Problem 19.	Basic Select All Fields
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--Problem 20.	Basic Select All Fields and Order Them

SELECT * FROM Towns ORDER BY [Name]
SELECT * FROM Departments ORDER BY [Name]
SELECT * FROM Employees ORDER BY Salary DESC

--Problem 21.	Basic Select Some Fields

SELECT [Name] FROM Towns ORDER BY [Name]
SELECT [Name] FROM Departments ORDER BY [Name]
SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC

--Problem 22.	Increase Employees Salary

UPDATE Employees
SET Salary = Salary * 1.1

SELECT Salary FROM Employees

--Problem 23.	Decrease Tax Rate

USE Hotel

UPDATE Payments
SET TaxRate=TaxRate-TaxRate*0.03

SELECT TaxRate FROM Payments

--Problem 24.	Delete All Records

TRUNCATE TABLE Occupancies



