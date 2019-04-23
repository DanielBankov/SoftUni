SELECT DAY(o.[Datetime]) AS [Day], FORMAT(AVG(i.Price * oi.Quantity), 'N2') AS [Total profit] FROM Orders AS o
	JOIN OrderItems AS oi ON oi.OrderId = o.Id
	JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY DAY(o.[Datetime])
ORDER BY [Day] 