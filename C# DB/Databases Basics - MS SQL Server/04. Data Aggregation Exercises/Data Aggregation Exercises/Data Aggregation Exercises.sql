--Exercises: Data Aggregation

--Problem 1.	Records’ Count

USE Gringotts

SELECT COUNT(Id) FROM WizzardDeposits

--Problem 2.	Longest Magic Wand

SELECT MAX(MagicWandSize) FROM WizzardDeposits

--Problem 3.	Longest Magic Wand per Deposit Groups

SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

--Problem 4.	* Smallest Deposit Group per Magic Wand Size

SELECT TOP 2 dg2.DepositGroup FROM (
	SELECT dg1.DepositGroup, AVG(dg1.MagicWandSize) AS MagicWandSize
	FROM WizzardDeposits AS dg1
	GROUP BY dg1.DepositGroup )
AS dg2
ORDER BY dg2.MagicWandSize

--Problem 5.	Deposits Sum

SELECT DepositGroup, SUM(DepositAmount) 
FROM WizzardDeposits
GROUP BY DepositGroup

--Problem 6.	Deposits Sum for Ollivander Family

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--Problem 7.	Deposits Filter

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
HAVING MagicWandCreator = 'Ollivander family'
	AND SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--Problem 8.	 Deposit Charge

SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--Problem 9.	Age Groups

SELECT  'Age Groups'=
	CASE
		WHEN Age>=0 AND Age <=10 THEN '[0-10]'
		WHEN Age>=11 AND Age <=20 THEN '[11-20]'
		WHEN Age>=21 AND Age <=30 THEN '[21-30]'
		WHEN Age>=31 AND Age <=40 THEN '[31-40]'
		WHEN Age>=41 AND Age <=50 THEN '[41-50]'
		WHEN Age>=51 AND Age <=60 THEN '[51-60]'
		WHEN Age>=61 THEN '[61+]'
	END,
	COUNT(FirstName) AS WizzardCount
FROM WizzardDeposits
GROUP BY 
	CASE
		WHEN Age>=0 AND Age <=10 THEN '[0-10]'
		WHEN Age>=11 AND Age <=20 THEN '[11-20]'
		WHEN Age>=21 AND Age <=30 THEN '[21-30]'
		WHEN Age>=31 AND Age <=40 THEN '[31-40]'
		WHEN Age>=41 AND Age <=50 THEN '[41-50]'
		WHEN Age>=51 AND Age <=60 THEN '[51-60]'
		WHEN Age>=61 THEN '[61+]'
	END 

--Problem 10.	First Letter

SELECT LEFT(FirstName,1) AS FirstLetter FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY Left(FirstName,1)

--Problem 11.	Average Interest 

SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC

--Problem 12.	* Rich Wizard, Poor Wizard

SELECT SUM(w2.DepositAmount - w1.DepositAmount) AS SumDifference
  FROM WizzardDeposits AS w1, 
       WizzardDeposits AS w2
WHERE w1.Id = w2.Id + 1


--Problem 13.	Departments Total Salaries

USE SoftUni

SELECT DepartmentId, SUM(Salary) AS TotalSalary 
FROM Employees 
GROUP BY DepartmentID

--Problem 14.	Employees Minimum Salaries

SELECT  DepartmentId, MIN(Salary) AS MinimumSalary 
FROM Employees 
WHERE DepartmentID IN(2,5,7)
GROUP BY DepartmentId

--Problem 15.	Employees Average Salaries

SELECT * INTO EmployeesWithSalariesAbove30000 FROM Employees
WHERE Salary>30000

DELETE FROM EmployeesWithSalariesAbove30000
WHERE ManagerID = 42

UPDATE EmployeesWithSalariesAbove30000
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM EmployeesWithSalariesAbove30000
GROUP BY DepartmentId

--Problem 16.	Employees Maximum Salaries

SELECT DepartmentId, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentId
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--Problem 17.	Employees Count Salaries

SELECT COUNT(EmployeeId) AS Count FROM Employees
WHERE ManagerID IS NULL

--Problem 18.	*3rd Highest Salary

SELECT Salaries.DepartmentID, Salaries.Salary FROM
(
	SELECT DepartmentId,
	MAX(Salary) AS Salary,
	DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS Rank
	FROM Employees
	GROUP BY DepartmentID, Salary
)AS Salaries 
WHERE Rank = 3

--Problem 19.	**Salary Challenge
SELECT TOP 10 e1.FirstName, 
       e1.LastName, 
       e1.DepartmentID 
  FROM Employees AS e1, 
        (SELECT DepartmentID, 
	            AVG(Salary) AS AverageSalary 
	       FROM Employees 
	   GROUP BY DepartmentID) AS e2
 WHERE e1.DepartmentID = e2.DepartmentID AND e1.Salary > e2.AverageSalary
ORDER BY e1.DepartmentID
