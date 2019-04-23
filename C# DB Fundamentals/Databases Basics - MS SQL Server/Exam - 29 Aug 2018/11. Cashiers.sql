SELECT DISTINCT e.Id, FirstName, LastName FROM Employees AS e
	JOIN Orders AS o ON o.EmployeeId = e.Id
	ORDER BY e.Id