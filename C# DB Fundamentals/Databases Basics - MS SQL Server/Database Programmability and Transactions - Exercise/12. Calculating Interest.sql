CREATE PROC usp_CalculateFutureValueForAccount @accountID INT, @interestRate FLOAT AS
	SELECT a.Id, ah.FirstName, ah.LastName, a.Balance,  dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5)
	FROM Accounts AS a
		JOIN AccountHolders AS ah ON ah.Id = a.AccountHolderId 
	WHERE a.Id = @accountID

--EXEC usp_CalculateFutureValueForAccount 1, 0.1