
--Basic CRUD Exercises

--1.	Examine the Databases
USE SoftUni

--2.	Find All Information About Departments
SELECT DepartmentID,[Name],ManagerID FROM Departments

--3.	Find all Department Names
SELECT [Name] FROM Departments

--4.	Find Salary of Each Employee

SELECT FirstName, LastName, Salary FROM Employees

--5.	Find Full Name of Each Employee

SELECT FirstName, MiddleName, LastName FROM Employees

--6.	Find Email Address of Each Employee

SELECT FirstName + '.' + LastName +'@softuni.bg' AS [Full Email Address] FROM Employees

--7.	Find All Different Employee’s Salaries

SELECT DISTINCT Salary FROM Employees ORDER BY Salary 

--8.	Find all Information About Employees

SELECT * FROM Employees WHERE JobTitle = 'Sales Representative'

--9.	Find Names of All Employees by Salary in Range

SELECT FirstName, LastName, JobTitle FROM Employees WHERE Salary BETWEEN 20000 AND 30000

--10.	 Find Names of All Employees 

SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name] 
FROM Employees 
WHERE Salary IN (25000, 14000, 12500, 23600)

--11.	Find All Employees Without Manager

SELECT FirstName, LastName 
FROM Employees 
WHERE ManagerID IS NULL

--12.	 Find All Employees with Salary More Than 50000

SELECT FirstName, LastName, Salary 
FROM Employees 
WHERE Salary >= 50000
ORDER BY Salary DESC

--13.	Find 5 Best Paid Employees.

SELECT TOP(5) FirstName, LastName 
FROM Employees 
ORDER BY Salary DESC

--14.	Find All Employees Except Marketing

SELECT FirstName, LastName 
FROM Employees
WHERE NOT (DepartmentID = 4)

--15.	Sort Employees Table

SELECT EmployeeID AS ID, FirstName,LastName, MiddleName, JobTitle, DepartmentID AS DeptId, ManagerID as MngrId, HireDate, Salary, AddressID 
FROM Employees
ORDER BY Salary DESC, 
		FirstName ASC,
		LastName DESC,
		MiddleName ASC

--16.	 Create View Employees with Salaries

GO

CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary FROM Employees

GO

SELECT * FROM V_EmployeesSalaries

--17.	Create View Employees with Job Titles

GO

CREATE VIEW V_EmployeeNameJobTitle AS
SELECT FirstName + ' ' + ISNULL(MiddleName,'') + ' ' + LastName AS [Full Name], JobTitle FROM Employees
	
GO

SELECT * FROM V_EmployeeNameJobTitle

--18.	Distinct Job Titles

SELECT DISTINCT JobTitle  FROM Employees

--19.	Find First 10 Started Projects

SELECT TOP(10) ProjectID AS ID, [Name], Description, StartDate, EndDate 
FROM Projects
ORDER BY StartDate ASC,
		[Name] ASC

--20.	 Last 7 Hired Employees

SELECT TOP 7 FirstName, LastName, HireDate 
FROM Employees 
ORDER BY HireDate DESC

--21.	Increase Salaries 1,2,4

UPDATE Employees
SET Salary = Salary * 1.12
WHERE DepartmentID IN (1,2,4,11)

SELECT Salary FROM Employees

--22.	 All Mountain Peaks

USE Geography

SELECT PeakName FROM Peaks ORDER BY PeakName

--23.	 Biggest Countries by Population

SELECT TOP 30 CountryName, Population 
FROM Countries 
WHERE ContinentCode ='EU'
ORDER BY Population DESC,
		 CountryName ASC

--24.	 *Countries and Currency (Euro / Not Euro)

SELECT CountryName, CountryCode, "Currency"=
	CASE 
		WHEN CurrencyCode='EUR' THEN 'Euro'
		ELSE 'Not Euro'
	END
FROM Countries
ORDER BY CountryName

--25.	 All Diablo Characters

USE Diablo

SELECT Name FROM Characters ORDER BY Name