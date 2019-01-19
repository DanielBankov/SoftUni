CREATE PROC p_AddAccount @ClientId INT, @AccountTypeId INT AS
INSERT INTO Accounts(ClientId, AccountTypeId)
VALUES (@ClientId, @AccountTypeId)

p_AddAccount 2, 2

SELECT * FROM Accounts

CREATE PROC p_Deposit @AccountId INT, @Ammount DECIMAL(15, 2) AS
UPDATE Accounts
SET Balance += @Ammount
Where Id = @AccountId

CREATE PROC p_Withdraw @AccountId INT, @Ammount DECIMAL(15, 2) AS
BEGIN
	DECLARE @OldBalance DECIMAL(15, 2)
	SELECT @OldBalance = Balance FROM Accounts WHERE Id = @AccountId
	IF (@OldBalance - @Ammount >= 0)
	BEGIN
		UPDATE Accounts
		SET Balance -= @Ammount
		WHERE Id = @AccountId
	END
	ELSE
	BEGIN
		RAISERROR('Insufficient funds', 10, 1)
	END
END