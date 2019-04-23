SELECT i.[Name], c.[Name], SUM(oi.Quantity) AS [TotalPrice], SUM(oi.Quantity * i.Price) AS [Count] FROM Items AS i
	LEFT JOIN OrderItems AS oi ON oi.ItemId = i.Id
	JOIN Categories AS c ON c.Id = i.CategoryId
GROUP BY i.[Name], c.[Name]
ORDER BY [Count] DESC, [TotalPrice] DESC