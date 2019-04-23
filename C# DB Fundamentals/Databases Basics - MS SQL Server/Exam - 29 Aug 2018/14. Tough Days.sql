SELECT CONCAT(FirstName, ' ', LastName), DATENAME(DW, s.CheckIn) FROM Employees AS e
	LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
		 JOIN Shifts AS s ON s.EmployeeId = e.Id
WHERE o.[Datetime] IS NULL AND DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12
ORDER BY e.Id