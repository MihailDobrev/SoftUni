--Joins, Subqueries, CTE and Indices Exercises

--Problem 1.	Employee Address

USE SoftUni

SELECT TOP 5 e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText 
FROM Employees AS e
INNER JOIN Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY AddressID

--Problem 2.	Addresses with Towns

SELECT TOP 50 e.FirstName, e.LastName, t.Name AS Town, a.AddressText
FROM Employees AS e
INNER JOIN Addresses AS a
ON e.AddressID = a.AddressID
INNER JOIN Towns AS t
ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

--Problem 3.	Sales Employee

SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name AS DepartmentName
FROM Employees AS e
INNER JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY EmployeeID

--Problem 4.	Employee Departments

SELECT TOP 5 e.EmployeeID, e.FirstName, e.Salary, d.Name AS DepartmentName
FROM Employees AS e
INNER JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID

--Problem 5.	Employees Without Project

SELECT TOP 3 e.EmployeeID, e.FirstName
FROM Employees as e
FULL JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
LEFT OUTER JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE p.Name IS NULL
ORDER BY e.EmployeeID

--Problem 6.	Employees Hired After

SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DeptName
FROM Employees AS e
INNER JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01' AND d.Name IN('Sales','Finance')
ORDER BY e.HireDate

--Problem 7.	Employees with Project

SELECT TOP 5 e.EmployeeID, e.FirstName, p.Name
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects AS p
ON p.ProjectID = ep.ProjectID
WHERE p.StartDate >'2002-08-13' AND p.EndDate IS NULL
ORDER BY EmployeeID

--Problem 8.	Employee 24

SELECT e.EmployeeID, e.FirstName, "ProjectName"=
	CASE
		WHEN p.StartDate >='2005' THEN NULL
		ELSE p.Name
	END
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects AS p
ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24

--Problem 9.	Employee Manager

SELECT e1.EmployeeID, e1.FirstName, e1.ManagerID, e2.FirstName AS ManagerName
FROM Employees AS e1
INNER JOIN Employees AS e2
ON e1.ManagerID = e2.EmployeeID
WHERE e1.ManagerID IN (3,7)
ORDER BY e1.EmployeeID


--Problem 10.	Employee Summary

SELECT TOP 50
		e1.EmployeeID, 
	   e1.FirstName + ' ' + e1.LastName AS EmployeeName, 
	   e2.FirstName + ' ' + e2.LastName AS ManagerName, 
	   d.Name AS DepartmentName
FROM Employees AS e1
INNER JOIN Employees AS e2
ON e1.ManagerID = e2.EmployeeID
INNER JOIN Departments AS d
ON e1.DepartmentID=d.DepartmentID
ORDER BY EmployeeID

--Problem 11.	Min Average Salary

SELECT MIN(m.AverageDepartmentSalary) AS MinAverageSalary FROM
(
	SELECT e.DepartmentID, AVG(Salary) AS AverageDepartmentSalary
	FROM Employees AS e
	GROUP BY e.DepartmentID
) AS m

--Problem 12.	Highest Peaks in Bulgaria

USE Geography

SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Countries AS c
INNER JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
INNER JOIN Mountains AS m
ON m.Id = mc.MountainId
INNER JOIN Peaks AS p
ON p.MountainId=m.Id
WHERE p.Elevation > 2835 AND c.CountryCode = 'BG'
ORDER BY p.Elevation DESC

--Problem 13.	Count Mountain Ranges

SELECT t.CountryCode, COUNT(t.MountainRange) FROM
(
	SELECT m.MountainRange, c.CountryCode FROM Mountains AS m
	INNER JOIN MountainsCountries AS mc
	ON m.Id = mc.MountainId
	INNER JOIN Countries AS c
	ON c.CountryCode = mc.CountryCode
	WHERE c.CountryCode IN('US', 'RU', 'BG')
) AS t
GROUP BY t.CountryCode

--Problem 14.	Countries with Rivers

SELECT  TOP 5 
	c.CountryName,
	r.RiverName
FROM Countries AS c
LEFT OUTER JOIN CountriesRivers AS cr
ON c.CountryCode = cr.CountryCode
LEFT OUTER JOIN Rivers AS r
ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

--Problem 15.	*Continents and Currencies

SELECT  f.ContinentCode, f.CurrencyCode, f.[Currency Usage] FROM
(
	SELECT  q.ContinentCode, 
			q.CurrencyCode,
			q.[Currency Usage],
			DENSE_RANK() OVER(PARTITION BY q.ContinentCode ORDER BY q.[Currency Usage] DESC) AS Rank
	FROM
	(
		SELECT c.ContinentCode, 
			   c.CurrencyCode, 
			   COUNT(c.CurrencyCode) AS [Currency Usage]
		FROM Countries AS c
		GROUP BY ContinentCode, CurrencyCode
	)AS q
)AS f
WHERE f.Rank = 1 AND f.[Currency Usage] > 1
ORDER BY F.ContinentCode

--Problem 16.	Countries without any Mountains

SELECT COUNT(c.CountryCode) AS CountryCode
FROM Countries AS c
FULL JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
LEFT OUTER JOIN Mountains AS m
ON m.Id = mc.MountainId
WHERE m.MountainRange IS NULL

--Problem 17.	Highest Peak and Longest River by Country

SELECT TOP 5
	  c.CountryName, 
	  MAX(p.Elevation) AS HighestPeakElevation,
	  MAX(r.Length) AS LongestRiverLenght
FROM Countries AS c
FULL JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
FULL JOIN Mountains AS m
ON m.Id = mc.MountainId
FULL JOIN Peaks AS p
ON p.MountainId = m.Id
FULL JOIN CountriesRivers AS cr
ON cr.CountryCode = c.CountryCode
FULL JOIN Rivers AS r
ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLenght DESC, c.CountryName ASC

--Problem 18.	* Highest Peak Name and Elevation by Country

SELECT TOP 5
	q.Country,
	'Highest Peak Name'=
	   CASE
		WHEN q.[Highest Peak Name] IS NULL THEN '(no highest peak)'
		ELSE q.[Highest Peak Name]
	   END,
	  'Highest Peak Elevation'=
	  CASE
		WHEN q.[Highest Peak Elevation] IS NULL THEN 0
		ELSE q.[Highest Peak Elevation]
	  END,
	  'Mountain'=
	  CASE
		WHEN q.Mountain IS NULL THEN '(no mountain)'
		ELSE q.Mountain
	  END
 FROM
(
	 SELECT c.CountryName AS [Country],
			p.PeakName AS [Highest Peak Name],
			p.Elevation AS [Highest Peak Elevation],
			m.MountainRange AS [Mountain],
			DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS [Rank]
	FROM Countries AS c
	LEFT OUTER JOIN MountainsCountries AS mc
	ON mc.CountryCode = C.CountryCode
	LEFT OUTER JOIN Mountains AS m
	ON m.Id = mc.MountainId
	LEFT OUTER JOIN Peaks AS p
	ON p.MountainId = mc.MountainId
) AS q
WHERE RANK = 1
ORDER BY q.Country, q.[Highest Peak Name]

