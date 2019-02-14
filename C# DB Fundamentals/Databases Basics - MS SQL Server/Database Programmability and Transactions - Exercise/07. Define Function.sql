CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50))
RETURNS BIT
BEGIN
	DECLARE @count INT = 1

	WHILE (@count <= LEN(@word))
	BEGIN
		DECLARE @currLetter CHAR(1) = SUBSTRING(@word, @count, 1)
		DECLARE @charIndex INT = CHARINDEX(@currLetter, @setOfLetters)
		IF(@charIndex < 1)
		BEGIN
			RETURN 0
		END
		 
		SET @count += 1
	END
		RETURN 1
END

--GO
--SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')