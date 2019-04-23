SELECT TOP(5) c.Id, c.[Name], c.CountryCode, COUNT(c.Id) AS [Accounts] FROM Cities AS c
	JOIN Accounts AS a ON a.CityId = c.Id
GROUP BY c.Id, c.[Name], c.CountryCode
ORDER BY [Accounts] DESC