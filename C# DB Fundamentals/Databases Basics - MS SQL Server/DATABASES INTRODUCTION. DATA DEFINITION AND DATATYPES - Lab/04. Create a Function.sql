CREATE FUNCTION F_CalculateTotalBalance (@ClientID INT)
RETURNS DECIMAL(15, 2)
BEGIN 
	DECLARE @result AS DECIMAL(15, 2) =
	(
		SELECT SUM(Balance)
		FROM Bank.dbo.Accounts WHERE ClientId = @ClientID
	)
	RETURN @result
END

SELECT dbo.F_CalculateTotalBalance(3) AS Balance