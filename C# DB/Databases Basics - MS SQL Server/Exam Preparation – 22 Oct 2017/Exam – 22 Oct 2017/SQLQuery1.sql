--MS SQL Exam – 22 Oct 2017

--1.	Database design

CREATE DATABASE ReportService
USE ReportService

CREATE TABLE Users(
Id INT IDENTITY PRIMARY KEY,
Username NVARCHAR(30) NOT NULL UNIQUE,
Password NVARCHAR(50) NOT NULL,
Name NVARCHAR(50),
Gender CHAR,
Birthdate DATE,
Age INT,
Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(25),
LastName NVARCHAR(25),
Gender CHAR,
BirthDate DATE,
Age INT,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Status(
Id INT PRIMARY KEY IDENTITY,
Label NVARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
Id INT PRIMARY KEY IDENTITY,
CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
StatusId INT NOT NULL FOREIGN KEY REFERENCES Status(Id),
OpenDate DATE NOT NULL,
CloseDate DATE,
Description NVARCHAR(200),
UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--2.	Insert
INSERT INTO Employees(FirstName, LastName, Gender, BirthDate, DepartmentId) VALUES
('Marlo', 'O’Malley','M', '9/21/1958', 1),
('Niki', 'Stanaghan','F', '11/26/1969', 4),
('Ayrton', 'Senna','M', '03/21/1960', 9),
('Ronnie', 'Peterson','M', '02/14/1944', 9),
('Giovanna', 'Amati','F', '07/20/1959', 5)

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, Description, UserId, EmployeeId) VALUES
(1, 1,'04/13/2017', NULL, 'Stuck Road on Str.133', 6, 2),
(6, 3,'09/05/2015', '12/06/2015', 'Charity trail running', 3, 5),
(14, 2,'09/07/2015', NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3,'07/03/2017', '07/06/2017', 'Cut off streetlight on Str.11', 1, 1)

--3.	Update

UPDATE Reports
SET StatusId = 2
WHERE CategoryId = 4

--4.	Delete

DELETE FROM Reports
WHERE StatusId = 4

--5.	Users by Age

SELECT Username, Age 
FROM Users
ORDER BY Age, Username DESC

--6.	Unassigned Reports

SELECT Description, 
	   OpenDate 
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate, Description

--7.	Employees & Reports

SELECT e.FirstName, e.LastName, r.Description, FORMAT(r.OpenDate,'yyyy-MM-dd')
FROM Reports AS r
INNER JOIN Employees AS e
ON r.EmployeeId = e.Id
ORDER BY e.Id, r.OpenDate, r.Id

--8.	Most reported Category

SELECT c.Name, Count(*) AS ReportsNumber
FROM Reports AS r
INNER JOIN Categories AS c
ON c.Id = r.CategoryId
GROUP BY c.Name
ORDER BY Count(*) DESC, c.Name

--9.	Employees in Category

SELECT c.Name, COUNT(e.Id) AS [Employees Number]
FROM Employees AS e
INNER JOIN Departments AS d
ON d.Id = e.DepartmentId
INNER JOIN Categories AS c
ON c.DepartmentId = d.Id
GROUP BY c.Name
ORDER BY c.Name

--10.	Users per Employee 

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS Name, COUNT(r.Id) AS [Users Number]
FROM Employees AS e
LEFT OUTER JOIN Reports AS r
ON r.EmployeeId = e.Id
GROUP BY e.FirstName, e.LastName
ORDER BY [Users Number] DESC, e.FirstName ASC

--11.	Emergency Patrol

SELECT CONVERT(datetime,r.OpenDate,101), r.Description, u.Email
FROM Reports AS r
INNER JOIN Categories AS c
ON c.Id = r.CategoryId
INNER JOIN Users AS u
ON r.UserId = u.Id
WHERE CloseDate IS NULL
AND LEN(Description) > 20
AND LOWER(Description) LIKE '%str%'
AND c.DepartmentId IN (1, 4, 5)
ORDER BY r.OpenDate, u.Email, r.Id

--12.	Birthday Report

SELECT C.Name
FROM Categories AS c
FULL JOIN Reports AS r
ON r.CategoryId = c.Id
FULL JOIN Users AS u
ON u.Id = r.UserId
WHERE MONTH(u.Birthdate) = MONTH(r.OpenDate)
AND DAY(u.Birthdate) = DAY(r.OpenDate)
GROUP BY c.Name
ORDER BY c.Name

--13.	Numbers Coincidence

SELECT DISTINCT u.Username
FROM Users AS u
FULL JOIN Reports AS r
ON r.UserId = u.Id
WHERE LEFT(u.Username, 1) LIKE '[0-9]'
AND CAST(LEFT(u.Username, 1) AS INT) = r.CategoryId
OR RIGHT(u.Username, 1) LIKE '[0-9]'
AND CAST(RIGHT(u.Username, 1) AS INT) = r.CategoryId
ORDER BY Username

--14.	Open/Closed Statistics

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Name],
       CAST(COUNT(r.CloseDate) AS VARCHAR(20)) + '/' + CAST(COUNT(r.OpenDate) AS VARCHAR(20))
FROM Employees AS e
JOIN Reports AS r ON r.EmployeeId = e.Id
WHERE YEAR(r.OpenDate) = 2016 OR YEAR(r.CloseDate) = 2016
GROUP BY e.FirstName, e.LastName, e.Id
ORDER BY Name, e.Id

--15.	Average Closing Time

SELECT q.[Department Name],
       ISNULL(CAST(q.[Average Duration] AS VARCHAR(10)), 'no info') AS [Average Duration]
FROM 
(
	SELECT d.Name AS [Department Name],
		   AVG(DATEDIFF(DAY, r.OpenDate, r.CloseDate)) AS [Average Duration]
	FROM Departments AS d
	JOIN Categories AS c ON c.DepartmentId = d.Id
	JOIN Reports AS r ON r.CategoryId = c.Id
	GROUP BY d.Name
) AS q
ORDER BY [Department Name]

--16.	Favorite Categories

SELECT q.[Department Name], q.[Category Name], q.Percentage FROM
(
	SELECT d.Name AS [Department Name],
		   c.Name AS [Category Name],
		   CAST(ROUND(CAST(COUNT(*) OVER(PARTITION BY c.Name) AS DECIMAL(15,2))/ CAST(COUNT(*) OVER(PARTITION BY d.Name)AS DECIMAL(15,2)) * 100,0) AS INT) AS "Percentage"  
	FROM Departments AS d
	INNER JOIN Categories AS c ON c.DepartmentId = d.Id
	INNER JOIN Reports AS r ON r.CategoryId = c.Id
) AS q
GROUP BY q.[Department Name], q.[Category Name],q.Percentage
ORDER BY q.[Department Name], q.[Category Name]

--17.	Employee’s Load
GO

CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT) 
RETURNS INT
BEGIN
	DECLARE @reportsCount INT = (SELECT COUNT(*) FROM Reports
		WHERE EmployeeId = @employeeId
		AND StatusId = @statusId)
	RETURN @reportsCount
END

--18.	Assign Employee
GO

CREATE PROC usp_AssignEmployeeToReport(@employeeId INT, @reportId INT)
AS
	BEGIN TRANSACTION
	DECLARE @employeeDepartment INT = (SELECT DepartmentId FROM Employees WHERE Id = @employeeId)
	DECLARE @reportDepartment INT = 
	  (
	      SELECT c.DepartmentId FROM Reports AS r
		  INNER JOIN Categories AS c
		  ON c.Id = r.CategoryId
		  WHERE r.Id = @reportId
	  )
	  IF(@employeeDepartment <> @reportDepartment)
	  BEGIN
	   RAISERROR('Employee doesn''t belong to the appropriate department!',16,1)
	   ROLLBACK
	  END

	UPDATE Reports
	SET EmployeeId = @employeeId
	WHERE Id = @reportId
	  
	COMMIT


--19.	Close Reports
GO

CREATE TRIGGER tr_ReportsUPDATE ON Reports AFTER UPDATE
AS
	DECLARE @CloseDate DATETIME2;
	SET @CloseDate = (SELECT TOP 1 CloseDate FROM inserted)

	IF(@CloseDate IS NOT NULL)
	BEGIN
		UPDATE Reports
		SET StatusId = 3
		WHERE Id = (SELECT TOP 1 Id FROM inserted)
	END

--20.	Categories Revision

SELECT aggr.Name AS [Category Name], aggr.TotalStatusCount AS [Reports Number], "Main Status"=
CASE
	WHEN aggr.ProgressStatusCount > AGGR.WaitingStatusCount THEN 'in progress'
	WHEN aggr.ProgressStatusCount < AGGR.WaitingStatusCount THEN 'waiting'
    ELSE 'equal'
END
 FROM
(
	SELECT temp.Name, 
		SUM(temp.IsProgress) AS ProgressStatusCount, 
		SUM(temp.IsWaiting) AS WaitingStatusCount, 
		MAX(temp.TotalReportsPerCategory) AS TotalStatusCount
	FROM
	(
		SELECT c.Name,"IsProgress"=
		 CASE
			WHEN S.Label = 'in progress' THEN 1
			ELSE 0
		 END, "IsWaiting"=
		 CASE
			WHEN S.Label = 'waiting' THEN 1
			ELSE 0
		 END,
		COUNT(*) OVER(PARTITION BY c.Name) AS TotalReportsPerCategory
		FROM Reports AS r
		INNER JOIN Categories AS c ON c.Id = r.CategoryId
		INNER JOIN Status AS s ON s.Id = r.StatusId
		WHERE s.Label IN('waiting', 'in progress')
	) AS temp
	GROUP BY temp.Name
) as aggr
ORDER BY aggr.Name ASC 




































SELECT [Category Name],
       Waitings + InProgress AS [Reports Number],
	   CASE
	   WHEN Waitings > InProgress
	   THEN 'waiting'
	   WHEN Waitings < InProgress
	   THEN 'in progress'
	   ELSE 'equal'
	   END AS [Main Status]
  FROM
(SELECT c.[Name] AS [Category Name], 
       COUNT(CASE WHEN StatusId = 1 THEN 1 ELSE NULL END) AS [Waitings],
       COUNT(CASE WHEN StatusId = 2 THEN 1 ELSE NULL END) AS [InProgress]
  FROM Reports AS r
JOIN Categories AS c
ON c.Id = r.CategoryId
WHERE StatusId IN (
	SELECT Id 
	  FROM [Status] 
	 WHERE Label IN ('waiting', 'in progress')
)
GROUP BY r.CategoryId, c.[Name]) AS Temp
ORDER BY [Category Name], [Reports Number], [Main Status]
