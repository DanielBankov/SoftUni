SELECT k.FullName, DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS	WorkHours, k.TotalPrice FROM

(
	SELECT CONCAT(FirstName, ' ', LastName) AS FullName,
	   SUM(oi.Quantity * i.Price) AS TotalPrice,
	   ROW_NUMBER() OVER(PARTITION BY e.Id ORDER BY SUM(oi.Quantity * i.Price) DESC) AS RowNumber,
	   o.[Datetime] AS dt,
	   e.Id AS id
	   FROM Employees AS e
		 JOIN Orders AS o ON o.EmployeeId = e.Id
		 JOIN OrderItems AS oi ON oi.OrderId = o.Id
		 JOIN Items AS i ON i.Id = oi.ItemId
	   GROUP BY o.Id, FirstName, LastName, o.[Datetime], e.Id
) AS k 

 JOIN Shifts AS s ON s.EmployeeId = k.id
WHERE k.RowNumber = 1  AND k.dt BETWEEN s.CheckIn AND s.CheckOut
ORDER BY k.FullName, WorkHours DESC, k.TotalPrice DESC