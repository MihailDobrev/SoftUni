--Table Relations Exercises

--Problem 1.	One-To-One Relationship

CREATE TABLE Passports(
PassportID INT PRIMARY KEY,
PassportNumber NVARCHAR(50)
)

CREATE TABLE Persons(
PersonId INT IDENTITY NOT NULL,
FirstName NVARCHAR(50),
Salary MONEY,
PassportID INT
)

ALTER TABLE Persons
ADD CONSTRAINT PK_PERSONS
PRIMARY KEY (PersonId)

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports
FOREIGN KEY (PassportId)
REFERENCES Passports(PassportId)

INSERT INTO Passports VALUES
(101,'N34FG21B'),
(102,'K65LO4R7'),
(103,'ZE657QP2')

INSERT INTO Persons VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

--Problem 2.	One-To-Many Relationship

CREATE TABLE Manufacturers(
ManufacturerId INT IDENTITY NOT NULL,
Name NVARCHAR(50),
EstablishedOn DATE
)

CREATE TABLE Models(
ModelId INT NOT NULL,
Name NVARCHAR(50),
ManufacturerID INT
)

ALTER TABLE Models
ADD CONSTRAINT PK_Models
PRIMARY KEY (ModelID)

ALTER TABLE Manufacturers
ADD CONSTRAINT PK_Manufacturers
PRIMARY KEY (ManufacturerID)

ALTER TABLE Models
ADD CONSTRAINT FK_Models_Manufacturers
FOREIGN KEY (ManufacturerID)
REFERENCES Manufacturers(ManufacturerID)

INSERT INTO Manufacturers VALUES
('BMW', '1916-03-07'),
('Tesla', '2003-01-01'),
('Lada', '1966-05-01')

INSERT INTO Models VALUES
(101,'X1', 1),
(102,'i6', 1),
(103,'Model S', 2),
(104,'Model X', 2),
(105,'Model 3', 2),
(106,'Nova', 3)

--Problem 3.	Many-To-Many Relationship

USE TableRelations

CREATE TABLE Students(
StudentID INT IDENTITY NOT NULL,
[Name] NVARCHAR(50)
)

CREATE TABLE Exams(
ExamID INT NOT NULL,
[Name] NVARCHAR(50)
)

CREATE TABLE StudentsExams(
StudentID INT NOT NULL,
ExamID INT NOT NULL
)

ALTER TABLE Students
ADD CONSTRAINT PK_Students
PRIMARY KEY (StudentID) 

ALTER TABLE Exams
ADD CONSTRAINT PK_Exams
PRIMARY KEY (ExamID) 

ALTER TABLE StudentsExams
ADD CONSTRAINT PK_StudentsExams
PRIMARY KEY (StudentID,ExamID)

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_StudentID
FOREIGN KEY (StudentID)
REFERENCES Students(StudentID)

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_ExamID
FOREIGN KEY (ExamID)
REFERENCES Exams(ExamID)

INSERT INTO Students VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams VALUES
(101, 'SpringMVC'),
(102, 'Neo4j'),
(103, 'Oracle 11g')

INSERT INTO StudentsExams VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

--Problem 4.	Self-Referencing 

CREATE TABLE Teachers(
TeacherID INT NOT NULL,
[Name] NVARCHAR(50),
ManagerID INT
)

ALTER TABLE Teachers
ADD CONSTRAINT PK_Teachers
PRIMARY KEY (TeacherID)

ALTER TABLE Teachers
ADD CONSTRAINT FK_Teachers
FOREIGN KEY (ManagerID)
REFERENCES Teachers(TeacherID)

INSERT INTO Teachers VALUES
(101, 'John', NULL),
(102, 'Maya', 106),
(103, 'Silvia', 106),
(104, 'Ted', 105),
(105, 'Mark', 101),
(106, 'Greta', 101)

SELECT * FROM Teachers

--Problem 5.	Online Store Database

CREATE TABLE Cities(
CityID INT PRIMARY KEY,
Name NVARCHAR(50)
)

CREATE TABLE Customers(
CustomerID INT PRIMARY KEY,
Name NVARCHAR(50),
Bithday DATE,
CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
OrderId INT PRIMARY KEY,
CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes(
ItemTypeID INT PRIMARY KEY,
Name NVARCHAR(50)
)

CREATE TABLE Items(
ItemID INT PRIMARY KEY,
Name NVARCHAR(50),
ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems(
OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
CONSTRAINT PK_OrderItems
PRIMARY KEY(OrderID, ItemID)
)


--Problem 6.	University Database

CREATE TABLE Majors(
MajorID INT PRIMARY KEY,
Name NVARCHAR(50)
)

CREATE TABLE Subjects(
SubjectID INT PRIMARY KEY,
SubjectName NVARCHAR(50)
)

CREATE TABLE Students(
StudentID INT PRIMARY KEY,
StudentNumber INT,
StudentName NVARCHAR(50),
MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments(
PaymentID INT PRIMARY KEY,
PaymentDate DATE,
PaymentAmount MONEY,
StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Agenda(
StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
CONSTRAINT PK_Agenda
PRIMARY KEY(StudentID, SubjectID)
)

--Problem 9.	*Peaks in Rila
USE Geography

SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Mountains AS m
INNER JOIN Peaks AS p
ON m.Id = p.MountainId
WHERE m.MountainRange='Rila'
ORDER BY Elevation DESC






