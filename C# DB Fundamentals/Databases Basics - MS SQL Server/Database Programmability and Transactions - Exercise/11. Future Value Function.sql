CREATE FUNCTION ufn_CalculateFutureValue (@sum decimal(18, 4), @yearlyInterestRate FLOAT, @numberOfYyears INT)
RETURNS DECIMAL(18, 4)
BEGIN
	DECLARE @result DECIMAL(18, 4)
	SET @result = @sum * POWER((1 + @yearlyInterestRate), @numberOfYyears)
	RETURN @result
END

--SELECT dbo.ufn_CalculateFutureValue (1000, 0.1, 5)