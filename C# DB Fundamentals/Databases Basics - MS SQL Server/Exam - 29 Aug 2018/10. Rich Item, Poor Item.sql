SELECT TOP(10) OrderId, MAX(i.Price) AS [ExpensivePrice], MIN(i.Price) AS [CheapPrice] FROM Orders AS o
	JOIN OrderItems AS oi ON oi.OrderId = o.Id
	JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY OrderId
ORDER BY MAX(i.Price) DESC, OrderId