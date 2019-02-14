CREATE PROC usp_GetHoldersWithBalanceHigherThan @Number DECIMAL(14, 2) AS
SELECT k.FirstName, k.LastName FROM (	
	SELECT ah.Id, ah.FirstName, ah.LastName
		FROM Accounts AS a
		JOIN AccountHolders AS ah ON ah.Id = a.AccountHolderId
		GROUP BY ah.Id, ah.FirstName, ah.LastName
		HAVING SUM(a.Balance) > @Number) AS k
	ORDER BY k.FirstName, k.LastName
