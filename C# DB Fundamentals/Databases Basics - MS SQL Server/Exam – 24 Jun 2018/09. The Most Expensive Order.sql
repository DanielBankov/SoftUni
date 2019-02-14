SELECT TOP(1) OrderId, SUM(oi.Quantity * i.Price) AS [TotalPrice] FROM Orders AS o
	JOIN OrderItems AS oi ON oi.OrderId = o.Id
	JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY OrderId
ORDER BY SUM(oi.Quantity * i.Price) DESC