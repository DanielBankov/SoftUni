CREATE PROC usp_GetTownsStartingWith @Letter NVARCHAR(10) AS
	SELECT [Name] FROM Towns
	WHERE [Name] LIKE @Letter + '%'

--EXEC usp_GetTownsStartingWith @Letter = b