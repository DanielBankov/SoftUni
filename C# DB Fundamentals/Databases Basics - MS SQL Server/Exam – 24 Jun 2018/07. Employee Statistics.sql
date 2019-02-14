SELECT FirstName, LastName, COUNT(o.Id) AS [Count] FROM Employees AS e
	JOIN Orders AS o ON o.EmployeeId = e.Id
GROUP BY FirstName, LastName
ORDER BY [Count] DESC, FirstName