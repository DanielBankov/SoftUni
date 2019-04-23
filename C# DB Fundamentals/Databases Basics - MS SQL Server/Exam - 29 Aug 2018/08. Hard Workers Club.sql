SELECT FirstName, LastName, AVG(DATEDIFF(HOUR, CheckIn, CheckOut)) AS [Work Hours] FROM Employees AS e
	JOIN Shifts AS s ON s.EmployeeId = e.Id
GROUP BY FirstName, LastName, e.Id
HAVING AVG(DATEDIFF(HOUR, CheckIn, CheckOut)) > 7
ORDER BY [Work Hours] DESC, e.Id