--Database Programmability and Transactions

--Section I. Functions and Procedures

CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
	SELECT FirstName, LastName 
	FROM Employees
	WHERE Salary > 35000
--Test
EXEC usp_GetEmployeesSalaryAbove35000

GO
--Problem 2. Employees with Salary Above Number


CREATE PROC usp_GetEmployeesSalaryAboveNumber @Number DECIMAL(18,4)
AS
	SELECT FirstName, LastName 
	FROM Employees
	WHERE Salary >= @Number
--Test
EXEC usp_GetEmployeesSalaryAboveNumber 48100

GO
--Problem 3. Town Names Starting With

CREATE PROC usp_GetTownsStartingWith @StartingText VARCHAR(50)
AS
	SELECT Name AS Town 
	FROM Towns
	WHERE LEFT(Name, LEN(@StartingText)) = @StartingText
--Test
EXEC usp_GetTownsStartingWith 'b'

GO
--Problem 4. Employees from Town

CREATE PROC usp_GetEmployeesFromTown @Town NVARCHAR(50)
AS
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	INNER JOIN Addresses AS a
	ON e.AddressID = a.AddressID
	INNER JOIN Towns AS t
	ON a.TownID = t.TownID
	WHERE t.Name = @Town
--Test
EXEC usp_GetEmployeesFromTown 'Sofia'

GO
--Problem 5. Salary Level Function

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(7)
AS
BEGIN
	DECLARE @level NVARCHAR(7)
	SET @level=
	CASE
		WHEN @salary <30000 THEN 'Low'
		WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
		ELSE 'High'
	END
	RETURN @level
END

GO
--Test
SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel FROM Employees

GO
--Problem 6. Employees by Salary Level

CREATE PROC usp_EmployeesBySalaryLevel @SalaryLevel NVARCHAR(7)
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel
--Test
EXEC usp_EmployeesBySalaryLevel 'High'

GO
--Problem 7. Define Function

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50))
RETURNS BIT
BEGIN
	DECLARE @letter NVARCHAR(1)
	DECLARE @position INT = 1
	DECLARE @isWordComprised BIT = 1
	DECLARE @wordLength INT = LEN(@word)
	DECLARE @wordCopy NVARCHAR(50) = LOWER(@word)
	DECLARE @setOfLettersCopy NVARCHAR(50)= LOWER(@setOfLetters)

	WHILE(@wordLength >= @position)
	BEGIN
		SET @letter = SUBSTRING(@wordCopy, @position, 1)
		IF(CHARINDEX(@letter,@setOfLettersCopy)= 0)
		BEGIN
		    SET @isWordComprised = 0
			RETURN @isWordComprised
		END
		SET @position +=1
	END
	RETURN @isWordComprised
END 

GO
--Problem 8. * Delete Employees and Departments

CREATE PROC usp_DeleteEmployeesFromDepartment @departmentId INT
AS
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL

	ALTER TABLE Employees
	ALTER COLUMN ManagerID INT NULL

	ALTER TABLE Employees
	ALTER COLUMN DepartmentID INT NULL

	UPDATE Employees
	SET ManagerID = NULL, DepartmentID = NULL
	WHERE Employees.DepartmentID = @departmentId

	UPDATE Departments
	SET ManagerID = NULL
	WHERE Departments.DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE Departments.DepartmentID = @departmentId

	DELETE FROM Employees
	WHERE Employees.DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId

--Test
EXEC usp_DeleteEmployeesFromDepartment 1

--Problem 9. Find Full Name
GO

CREATE PROC usp_GetHoldersFullName 
AS
	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM AccountHolders

--Test
EXEC usp_GetHoldersFullName

GO
--Problem 10. People with Balance Higher Than

CREATE PROC usp_GetHoldersWithBalanceHigherThan @numToCheck DECIMAL(15,2)
AS
	SELECT FirstName, LastName
	FROM AccountHolders AS ah
	INNER JOIN Accounts AS a
	ON a.AccountHolderId = ah.Id
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @numToCheck

GO
--  Problem 11. Future Value Function

CREATE FUNCTION ufn_CalculateFutureValue(@initialSum DECIMAL(20,10), @yearlyInterestRate DECIMAL(10, 2), @numberOfYears INT)
RETURNS DECIMAL(25,4)
BEGIN
	DECLARE @futureValue DECIMAL(25,10) = 1 + @yearlyInterestRate
	SET @futureValue = POWER(@futureValue, @numberOfYears)
	SET @futureValue = @initialSum * @futureValue
	RETURN ROUND(@futureValue,4)
END

GO
--Test 
SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

GO
--Problem 12. Calculating Interest

CREATE PROC usp_CalculateFutureValueForAccount @accountId INT, @interestRate FLOAT
AS
	SELECT ah.Id AS [Account Id], ah.FirstName AS [First Name], ah.LastName AS [Last Name], a.Balance AS [Current Balance], dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	INNER JOIN Accounts AS a
	ON a.AccountHolderId = ah.Id
	WHERE a.Id = @accountId

--Test
EXEC usp_CalculateFutureValueForAccount 1, 0.1

GO
--Problem 13. *Scalar Function: Cash in User Games Odd Rows

CREATE FUNCTION dbo.ufn_CashInUsersGames (@GameName NVARCHAR(30))
RETURNS TABLE
AS
RETURN
(
	SELECT SUM(Cash) AS [SumCash]
      FROM 
		   (
		   SELECT *,
		   		  ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS [Row]
		   	 FROM UsersGames AS ug
		   	WHERE ug.GameId IN ((SELECT g.Id FROM Games AS g WHERE [Name] = @GameName))
		   ) AS TempTable
	 WHERE [Row] % 2 = 1
)

GO
--Problem 14. Create Table Logs

USE Bank

CREATE TABLE Logs(
LogId INT PRIMARY KEY IDENTITY,
AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
OldSum DECIMAL(15,2),
NewSum DECIMAL(15,2)
)

GO

CREATE TRIGGER tr_AccountsUpdate ON Accounts AFTER UPDATE
AS
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT inserted.Id,
			deleted.Balance,
			inserted.Balance
		FROM inserted
		INNER JOIN deleted
	    ON inserted.Id = deleted.Id

--Test
UPDATE Accounts
SET Balance = 123.12
WHERE Id = 1

--Problem 15. Create Table Emails

CREATE TABLE NotificationEmails(
Id INT PRIMARY KEY IDENTITY,
Recipient INT, 
Subject NVARCHAR(50),
Body NVARCHAR(100),
)
GO

CREATE TRIGGER tr_LogsInsert ON Logs AFTER INSERT
AS
	INSERT INTO NotificationEmails(Recipient, [Subject], Body)
	SELECT  i.AccountId,
		  CONCAT('Balance change for account: ', i.AccountId),
		  CONCAT('On ', GETDATE(),' your balance was changed from ', i.OldSum, ' to ', i.NewSum, '.')
	FROM inserted as i

GO
--Problem 16. Deposit Money

CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(15,4))
AS
	BEGIN TRANSACTION

		IF(@MoneyAmount < 0)
		BEGIN
			RAISERROR('Value can not be negative',16,1)
			ROLLBACK
			RETURN
		END

		UPDATE Accounts
		SET Balance += @MoneyAmount
		WHERE Id = @AccountId

		IF(@@ROWCOUNT<>1)
		BEGIN
			ROLLBACK
			RETURN
		END
	COMMIT

--Test
EXEC usp_DepositMoney 1,10

GO
--Problem 17. Withdraw Money

CREATE PROC usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(15,4))
AS
	BEGIN TRANSACTION

		IF(@moneyAmount<0)
		BEGIN
			ROLLBACK
			RETURN
		END

		DECLARE @MoneyInAccount DECIMAL(15,4) = (SELECT a.Balance FROM Accounts AS a WHERE Id = @accountId)
		IF(@MoneyInAccount - @moneyAmount < 0 )
		BEGIN
			ROLLBACK
			RETURN
		END

		UPDATE Accounts
		SET Balance-=@moneyAmount
		WHERE Id = @accountId

		IF(@@ROWCOUNT<>1)
		BEGIN
			ROLLBACK
			RETURN
		END

	COMMIT

--Problem 18. Money Transfer
GO

CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL (15,4)) 
AS
	EXEC usp_WithdrawMoney @SenderId, @Amount
	EXEC usp_DepositMoney @ReceiverId, @Amount

--Problem 20. *Massive Shopping

DECLARE @UserId INT = (
	SELECT Id FROM Users
	 WHERE Username = 'Stamat'
)

DECLARE @GameId INT = (
	SELECT Id FROM Games
	 WHERE [Name] = 'Safflower'
)

DECLARE @UserGameId INT = (
	SELECT Id FROM UsersGames
	 WHERE UserId = @UserId
	   AND GameId = @GameId
)

DECLARE @Cash DECIMAL(15, 2) = (
	SELECT Cash FROM UsersGames
	WHERE Id = @UserGameId
)

BEGIN TRANSACTION
	DECLARE @FirstLevelRangeTotalPrice DECIMAL(15, 2) = (
		SELECT SUM(Price) FROM Items
		WHERE MinLevel BETWEEN 11 AND 12
	)

IF (@Cash - @FirstLevelRangeTotalPrice < 0)
BEGIN
	ROLLBACK
END
ELSE
BEGIN 
	UPDATE UsersGames
	SET Cash -= @FirstLevelRangeTotalPrice
	WHERE Id = @UserGameId

	INSERT INTO UserGameItems
	SELECT Id, @UserGameId FROM Items
	WHERE MinLevel BETWEEN 11 AND 12

	COMMIT
END

BEGIN TRANSACTION
	DECLARE @SecondLevelRangeTotalPrice DECIMAL(15, 2) = (
		SELECT SUM(Price) FROM Items
		WHERE MinLevel BETWEEN 19 AND 21
	)

IF (@Cash - @SecondLevelRangeTotalPrice < 0)
BEGIN
	ROLLBACK
END
ELSE
BEGIN
	UPDATE UsersGames
	SET Cash -= @SecondLevelRangeTotalPrice
	WHERE Id = @UserGameId

	INSERT INTO UserGameItems
	SELECT Id, @UserGameId FROM Items
	WHERE MinLevel BETWEEN 19 AND 21

	COMMIT
END

SELECT i.[Name] AS [Item Name] FROM UserGameItems AS ugi
INNER JOIN Items AS i ON i.Id = ugi.ItemId
INNER JOIN UsersGames AS ug ON ug.Id = ugi.UserGameId
INNER JOIN Games AS g ON g.Id = ug.GameId
WHERE g.Id = @GameId
ORDER BY i.[Name]

GO
--Problem 21. Employees with Three Projects

CREATE PROC usp_AssignProject (@employeeId INT, @projectId INT)
AS
	BEGIN TRANSACTION
	DECLARE @allProjectsThatEmployeeHas INT =
	(
		SELECT COUNT(*) 
		FROM EmployeesProjects
		GROUP BY EmployeeID
		HAVING EmployeeID = @employeeId
	)

	IF(@allProjectsThatEmployeeHas = 3)
	BEGIN
		RAISERROR('The employee has too many projects!', 16, 1)
		ROLLBACK
		RETURN
	END

	INSERT INTO EmployeesProjects VALUES
	(@employeeId,@projectId)

	COMMIT

--Problem 22. Delete Employees

CREATE TABLE Deleted_Employees(
EmployeeId INT PRIMARY KEY,
FirstName NVARCHAR(50),
LastName NVARCHAR(50),
MiddleName NVARCHAR(50),
JobTitle NVARCHAR(50),
DepartmentId INT,
Salary MONEY
)
GO

CREATE TRIGGER tr_EmployeesDelete ON Employees FOR DELETE
AS
	INSERT INTO Deleted_Employees
	SELECT
		d.FirstName,
		d.LastName, 
		d.MiddleName, 
		d.JobTitle, 
		d.DepartmentID, 
		d.Salary 
	FROM deleted AS d

