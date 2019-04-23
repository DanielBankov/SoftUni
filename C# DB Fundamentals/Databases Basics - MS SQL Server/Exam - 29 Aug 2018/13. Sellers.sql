SELECT TOP(10) CONCAT(FirstName, ' ', LastName) AS [Full Name], 
	   SUM(i.Price * oi.Quantity) AS [Total Sum],
	   SUM(oi.Quantity) AS [Items] 
	 FROM Employees AS e
     JOIN Orders AS o ON o.EmployeeId = e.Id
     JOIN OrderItems AS oi ON oi.OrderId = o.Id
     JOIN Items AS i ON i.Id = oi.ItemId
    WHERE o.[Datetime] < '2018-06-15'
 GROUP BY e.FirstName, e.LastName
 ORDER BY  [Total Sum] DESC, [Items] DESC