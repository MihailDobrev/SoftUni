--Database Basics MS SQL Exam – 3 Jan 2018

--1.	Database design

CREATE DATABASE RentACar
USE RentACar


CREATE TABLE Clients(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Gender CHAR,
BirthDate DATE,
CreditCard NVARCHAR(30) NOT NULL,
CardValidity DATE,
Email NVARCHAR(50) NOT NULL,
)

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Offices(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(40),
ParkingPlaces INT,
TownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Models(
Id INT PRIMARY KEY IDENTITY,
Manufacturer NVARCHAR(50) NOT NULL,
Model NVARCHAR(50) NOT NULL,
ProductionYear DATE,
Seats INT,
Class NVARCHAR(10), 
Consumption DECIMAL(14,2)
)

CREATE TABLE Vehicles(
Id INT PRIMARY KEY IDENTITY,
ModelId INT NOT NULL FOREIGN KEY REFERENCES Models(Id),
OfficeId INT NOT NULL FOREIGN KEY REFERENCES Offices(Id),
Mileage INT
)

CREATE TABLE Orders(
Id INT PRIMARY KEY IDENTITY,
ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(Id),
TownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id),
VehicleId INT NOT NULL FOREIGN KEY REFERENCES Vehicles(Id),
CollectionDate DATE NOT NULL,
CollectionOfficeId INT NOT NULL FOREIGN KEY REFERENCES Offices(Id),
ReturnDate DATE,
ReturnOfficeId INT FOREIGN KEY REFERENCES Offices(Id),
Bill DECIMAL(14, 2),
TotalMileage INT
)

--2.	Insert

INSERT INTO Models (Manufacturer, Model, ProductionYear, Seats, Class, Consumption) VALUES 
('Chevrolet', 'Astro', '2005-07-27', 4, 'Economy', 12.6),
('Toyota', 'Solara', '2009-10-15', 7, 'Family', 13.8),
('Volvo', 'S40', '2010-10-12', 3, 'Average', 11.3),
('Suzuki', 'Swift', '2000-02-03', 7, 'Economy', 16.2)

INSERT INTO Orders (ClientId, TownId, VehicleId, CollectionDate, CollectionOfficeId, ReturnDate, ReturnOfficeId, Bill, TotalMileage) VALUES
( 17, 2, 52, '2017-08-08',30, '2017-09-04', 42, 2360.00, 7434),
( 78, 17, 50, '2017-04-22',10, '2017-05-09', 12, 2326.00, 7326),
( 27, 13, 28, '2017-04-25',21, '2017-05-09', 34, 597.00, 1880)

--3.	Update

UPDATE Models
SET Class = 'Luxury'
WHERE Consumption > 20

--4.	Delete

DELETE FROM Orders
WHERE ReturnDate IS NULL

--5.	Showroom

SELECT Manufacturer, Model 
FROM Models
ORDER BY Manufacturer,Id DESC

--6.	Y Generation

SELECT FirstName, LastName
FROM Clients
WHERE DATEPART(YEAR, BirthDate) BETWEEN 1977 AND 1994
ORDER BY FirstName, LastName, Id

--7.	Spacious Office

SELECT t.Name, o.Name, o.ParkingPlaces
FROM Offices AS o
INNER JOIN Towns AS t ON t.Id = o.TownId
WHERE ParkingPlaces > 25
ORDER BY t.Name, o.Id

--8.	Available Vehicles

SELECT m.Model, m.Seats, v.Mileage FROM
(
	SELECT temp.Id,
		  MAX(temp.IsNull) AS IsNotAvailable
	FROM
	(
		SELECT v.Id, m.Model, v.Mileage, "IsNull"=
			CASE
			 WHEN ReturnDate IS NULL AND CollectionDate IS NOT NULL THEN 1
			 ELSE 0
			END
			FROM Vehicles AS v 
		LEFT OUTER JOIN Orders AS o ON v.Id = o.VehicleId
		INNER JOIN Models AS m ON m.Id = v.ModelId
	) AS temp
	GROUP BY temp.Id
) AS q
INNER JOIN Vehicles AS v ON v.Id = q.Id
INNER JOIN Models AS m ON m.Id = v.ModelId
WHERE q.IsNotAvailable = 0
ORDER BY v.Mileage, m.Seats DESC, v.ModelId

--9.	Offices per Town

SELECT t.Name AS TownName, COUNT(*) AS OfficesNumber 
FROM Offices AS o
INNER JOIN Towns AS t ON t.Id = o.TownId 
GROUP BY t.Name
ORDER BY COUNT(*) DESC, t.Name 

--10.	Buyers Best Choice 

SELECT m.Manufacturer, m.Model, COUNT(o.Id) AS TimesOrdered
FROM Models AS m
FULL JOIN Vehicles AS v ON v.ModelId = m.Id
FULL JOIN Orders AS o ON o.VehicleId = v.Id
GROUP BY m.Manufacturer, m.Model
ORDER BY COUNT(o.Id) DESC, m.Manufacturer DESC, m.Model

--11.	Kinda Person

SELECT q2.Names, q2.Class FROM 
(
	SELECT  q.Names , 
			q.Class,
		   DENSE_RANK() OVER (PARTITION BY q.Names ORDER BY q.ClassCount DESC) AS Rank
	FROM
		(
			SELECT CONCAT(c.FirstName, ' ', c.LastName) AS Names,
				 m.Class AS Class,
				 COUNT(m.Class) AS ClassCount
			FROM Clients AS c
			INNER JOIN Orders AS o ON o.ClientId = c.Id
			INNER JOIN Vehicles AS v ON v.Id = o.VehicleId
			INNER JOIN Models AS m ON m.Id = v.ModelId
			GROUP BY c.FirstName, c.LastName, m.Class
		)AS q
)AS q2
WHERE q2.Rank = 1
ORDER BY q2.Names

--12. Age Groups Revenue

SELECT 'AgeGroup'=
	CASE
		WHEN DATEPART(YEAR,c.BirthDate) BETWEEN 1970 AND 1979 THEN '70''s'
		WHEN DATEPART(YEAR,c.BirthDate) BETWEEN 1980 AND 1989 THEN '80''s'
		WHEN DATEPART(YEAR,c.BirthDate) BETWEEN 1990 AND 1999 THEN '90''s'
		ELSE 'Others'
	END,
	SUM(o.Bill) AS Revenue,
	AVG(o.TotalMileage) AS AverageMileage
FROM Clients AS c
INNER JOIN Orders AS o ON o.ClientId = c.Id
GROUP BY CASE
		WHEN DATEPART(YEAR,c.BirthDate) BETWEEN 1970 AND 1979 THEN '70''s'
		WHEN DATEPART(YEAR,c.BirthDate) BETWEEN 1980 AND 1989 THEN '80''s'
		WHEN DATEPART(YEAR,c.BirthDate) BETWEEN 1990 AND 1999 THEN '90''s'
		ELSE 'Others'
	END
ORDER BY
	CASE
		WHEN DATEPART(YEAR,c.BirthDate) BETWEEN 1970 AND 1979 THEN '70''s'
		WHEN DATEPART(YEAR,c.BirthDate) BETWEEN 1980 AND 1989 THEN '80''s'
		WHEN DATEPART(YEAR,c.BirthDate) BETWEEN 1990 AND 1999 THEN '90''s'
		ELSE 'Others'
	END

--13.	Consumption in Mind

SELECT
  m.Manufacturer     AS [Manufacturer],
  AVG(m.Consumption) AS [AverageConsumption]
FROM
  (SELECT TOP 7
     m.Id,
     COUNT(o.VehicleId) AS [OrdersCount]
   FROM Orders o
     JOIN Vehicles v
       ON o.VehicleId = v.Id
     JOIN Models m 
       ON v.ModelId = m.Id
   GROUP BY m.Id
   ORDER BY COUNT(o.VehicleId) DESC
  ) AS mostOrdered
  JOIN Models m
    ON m.Id = mostordered.Id
GROUP BY m.Manufacturer
HAVING AVG(m.Consumption) BETWEEN 5 AND 15

--14.	Debt Hunter

SELECT temp.Name,
	   temp.Email,
	   temp.Bill,
	   temp.Town FROM
(
	SELECT  
			CONCAT(c.FirstName,' ', c.LastName) AS Name,
			c.Email,
			o.Bill, 
			t.Name AS Town,
			DENSE_RANK() OVER( PARTITION BY t.Name ORDER BY o.Bill DESC) AS BillRank
	FROM Orders as o
	INNER JOIN Clients AS c ON c.Id = o.ClientId
	INNER JOIN Towns AS t ON t.Id = o.TownId
	WHERE CardValidity < CollectionDate
) AS temp
WHERE temp.BillRank <= 2 AND temp.Bill IS NOT NULL
ORDER BY temp.Town, temp.Bill

--15.	Town Statistics

SELECT temp.Name AS TownName, "MalePercent"=
	   CASE 
		WHEN CAST(CAST(temp.TotalMale AS DECIMAL) / CAST(TotalGenders AS DECIMAL) * 100 AS INT) = 0 THEN NULL
		ELSE CAST(CAST(temp.TotalMale AS DECIMAL) / CAST(TotalGenders AS DECIMAL) * 100 AS INT)  
	   END,
	      CASE 
		WHEN CAST(CAST(temp.TotalFemale AS DECIMAL)/ CAST(TotalGenders AS DECIMAL)* 100 AS INT) = 0 THEN NULL
		ELSE CAST(CAST(temp.TotalFemale AS DECIMAL)/ CAST(TotalGenders AS DECIMAL)* 100 AS INT)  
	   END
	    AS FemalePercent
FROM
(
	SELECT 
		q.Name,
		SUM(q.Male) AS TotalMale,
		SUM(q.Female) AS TotalFemale,
		AVG(q.Total) AS TotalGenders
	 FROM
			(
				SELECT t.Name, 'Male' =
					CASE
						WHEN c.Gender = 'M' THEN 1
						ELSE 0
					END,
					'Female' =
					CASE
						WHEN c.Gender = 'F' THEN 1
						ELSE 0
					END,
					COUNT(*) OVER(PARTITION BY t.Name) AS Total
				FROM Orders AS o
				INNER JOIN Clients AS c ON c.Id = o.ClientId
				INNER JOIN Towns AS t ON t.Id = o.TownId
			) AS q
	GROUP BY q.Name
) AS temp
ORDER BY temp.Name

--16.	Home Sweet Home

WITH CTE_Ranks AS (
SELECT ReturnOfficeId, OfficeId, Id, Manufacturer, Model
FROM(
	SELECT DENSE_RANK() OVER(PARTITION BY v.Id ORDER BY o.CollectionDate DESC) AS LatestRentCars,
		   o.ReturnOfficeId,
		   v.OfficeId,
		   v.Id,
		   m.Manufacturer,
		   m.Model
	FROM Orders AS o
	RIGHT JOIN Vehicles AS v ON v.Id = o.VehicleId
	JOIN Models AS m ON m.Id = v.ModelId) AS RankedByDateDesc
WHERE LatestRentCars = 1 )

SELECT CONCAT(Manufacturer,' - ', Model) AS Vehicle,
	   Location =
		   CASE
			WHEN (
					SELECT COUNT(*)
					FROM Orders AS o
					WHERE o.VehicleId = CTE_Ranks.Id
					) = 0
			THEN 'home'
			WHEN (ReturnOfficeId IS NULL ) THEN 'on a rent'
			WHEN OfficeId <> ReturnOfficeId THEN (
												   SELECT CONCAT(t.Name,' - ',o.Name)
												   FROM Towns AS t
												   JOIN Offices AS o ON o.TownId = t.Id
												   WHERE o.Id = ReturnOfficeId
												   )
				

		   END
FROM CTE_Ranks
ORDER BY Vehicle, Id

--17.	Find My Ride
GO

CREATE FUNCTION udf_CheckForVehicle(@townName NVARCHAR(50), @seatsNumber INT) 
RETURNS NVARCHAR(500)
BEGIN
	DECLARE @querryResult NVARCHAR(500) = (
	SELECT TOP 1 
		CONCAT(o.Name,' - ' , m.Model)
	FROM Vehicles AS v
	INNER JOIN Models AS m ON m.Id = v.ModelId
	INNER JOIN Offices AS o ON o.Id = v.OfficeId
	INNER JOIN Towns AS t ON t.Id = o.TownId
	WHERE t.Name = @townName AND m.Seats = @seatsNumber
	ORDER BY o.Name)

	IF(@querryResult IS NULL)
	BEGIN 
		SET @querryResult = 'NO SUCH VEHICLE FOUND'
	END
	RETURN @querryResult
END

--18.	Move a Vehicle
GO

CREATE PROC usp_MoveVehicle(@vehicleId INT, @officeId INT) 
AS
	BEGIN TRANSACTION

	DECLARE @searchedOfficeParkingPlaces INT= 
	( 
		SELECT o.ParkingPlaces
		FROM Offices AS o
		WHERE o.Id = @officeId
	)

	
	DECLARE @totalVehiclesInThisOffice INT =
	(
		SELECT COUNT(*)
		FROM Vehicles AS v
		WHERE v.OfficeId = @officeId
	)

	IF(@totalVehiclesInThisOffice + 1 > @searchedOfficeParkingPlaces)
	BEGIN
		RAISERROR('Not enough room in this office!',16,1)
		ROLLBACK
	END

	UPDATE Vehicles
	SET OfficeId = @officeId
	WHERE Id = @vehicleId

	COMMIT

--Test
DROP PROC usp_MoveVehicle
EXEC usp_MoveVehicle 7, 32;
SELECT OfficeId FROM Vehicles WHERE Id = 7


--19.	Move the Tally
GO

CREATE TRIGGER tr_OrdersInsert ON Orders AFTER UPDATE
AS
	DECLARE @mileage int = (SELECT TOP 1 i.TotalMileage FROM inserted AS i)

	DECLARE @vehicleId int= 
	(SELECT TOP 1 i.VehicleId FROM inserted AS i)

	UPDATE Vehicles
	SET Mileage +=@mileage
	WHERE Id = @vehicleId