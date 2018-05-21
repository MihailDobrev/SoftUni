--Built-in Functions Exercises

--Problem 1.	Find Names of All Employees by First Name

USE SoftUni

SELECT FirstName, LastName 
FROM Employees
WHERE LEFT(FirstName,2)='SA'

--Problem 2.	  Find Names of All employees by Last Name 

SELECT FirstName, LastName 
FROM Employees
WHERE LastName LIKE '%ei%'

--Problem 3.	Find First Names of All Employees

SELECT FirstName
FROM Employees
WHERE DepartmentID IN(3, 10)
AND YEAR(HireDate) BETWEEN 1995 AND 2005

--Problem 4.	Find All Employees Except Engineers

SELECT FirstName, LastName
FROM Employees
WHERE LOWER(JobTitle) NOT LIKE '%engineer%'

--Problem 5.	Find Towns with Name Length

SELECT Name FROM Towns
WHERE LEN(Name) = 5 OR LEN(Name) = 6
ORDER BY Name

--Problem 6.	 Find Towns Starting With

SELECT * FROM Towns
WHERE LEFT(Name,1) = 'M' 
	OR LEFT(Name,1) = 'K' 
	OR LEFT(Name,1) = 'B' 
	OR LEFT(Name,1) = 'E' 
ORDER BY Name

--Problem 7.	 Find Towns Not Starting With

SELECT * FROM Towns
WHERE NOT (LEFT(Name,1) = 'R'
	OR LEFT(Name,1) = 'B' 
	OR LEFT(Name,1) = 'D') 
ORDER BY Name

--Problem 8.	Create View Employees Hired After 2000 Year
GO
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
WHERE YEAR(HireDate)>2000

--Problem 9.	Length of Last Name
GO
SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5

--Problem 10.	Countries Holding ‘A’ 3 or More Times

USE Geography
SELECT CountryName, IsoCode FROM Countries
WHERE LOWER(CountryName) LIKE '%a%a%a%'
ORDER BY IsoCode

--Problem 11.	 Mix of Peak and River Names

SELECT PeakName, RiverName, CONCAT(LOWER(PeakName), '', SUBSTRING(LOWER(RiverName),2,200)) AS Mix FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix;

--Problem 12.	Games from 2011 and 2012 year

USE Diablo

SELECT TOP 50 Name, CONVERT(varchar(10),Start,120) AS Start FROM Games 
WHERE YEAR(Start) = 2011 OR YEAR(Start) = 2012
ORDER BY Start ASC,
	 Name ASC

--Problem 13.	 User Email Providers

SELECT UserName, SUBSTRING(Email, CHARINDEX('@', Email, 1) + 1, 200) AS EmailProvider FROM Users
ORDER BY EmailProvider ASC,
		UserName ASC

--Problem 14.	 Get Users with IPAdress Like Pattern

SELECT UserName, IpAddress AS [Ip Address] FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--Problem 15.	 Show All Games with Duration and Part of the Day

SELECT Name AS Game, "Part Of The Day"=
	CASE 
		WHEN DATEPART(hour,Start) >= 0 AND DATEPART(hour,Start) < 12 THEN 'Morning' 
		WHEN DATEPART(hour,Start) >= 12 AND DATEPART(hour,Start) < 18 THEN 'Afternoon' 
		WHEN DATEPART(hour,Start) >= 18 AND DATEPART(hour,Start) < 24 THEN 'Evening' 
	END,
	"Duration"=
	CASE 
		WHEN Duration <=3 THEN 'Extra Short'
		WHEN Duration >=4 AND Duration <=6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	END
FROM Games
ORDER BY Name, Duration, [Part Of The Day]

--Problem 16.	 Orders Table

SELECT ProductName, OrderDate, DATEADD(DAY, 3, OrderDate) AS [Pay Due], DATEADD(MONTH, 1, OrderDate) AS [Delivery Due] 
FROM Orders

--Problem 17.	 People Table

CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50),
Birthdate DATE
)

INSERT INTO People([Name], Birthdate) VALUES
('Victor', '2000-12-07 00:00:00.000'),
('Steven', '1992-09-10 00:00:00.000'),
('Stephen', '1910-09-19 00:00:00.000'),
('John', '2010-01-06 00:00:00.000')

SELECT [Name], DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years] , 
DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People


