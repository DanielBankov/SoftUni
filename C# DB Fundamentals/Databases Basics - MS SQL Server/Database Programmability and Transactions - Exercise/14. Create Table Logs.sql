--CREATE TABLE Logs
--(	
--	LogId INT PRIMARY KEY IDENTITY, 
--	AccountID INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL, 
--	OldSum DECIMAL(16,2) NOT NULL, 
--	NewSum DECIMAL(16,2) NOT NULL, 
--)

CREATE TRIGGER tr_UpdateBalance ON Accounts AFTER UPDATE 
AS 
DECLARE @newSum DECIMAL(15, 2) = (SELECT Balance FROM inserted)
DECLARE @oldSum DECIMAL(15, 2) = (SELECT Balance FROM deleted)
DECLARE @Id INT = (SELECT Id FROM inserted)

INSERT INTO Logs(AccountID, OldSum, NewSum) VALUES
(@Id, @oldSum, @newSum)
