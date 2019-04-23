SELECT CONCAT(FirstName, ' ', ISNULL(MiddleName + ' ', ''), LastName), YEAR(BirthDate) FROM Accounts
WHERE DATEPART(YEAR, BirthDate) > 1991
ORDER BY YEAR(BirthDate) DESC, FirstName