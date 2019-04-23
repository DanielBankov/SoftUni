SELECT a.Id, CONCAT(FirstName, ' ', LastName) AS [FullName], 
	MAX(DATEDIFF(DAY,t.ArrivalDate, t.ReturnDate)) AS [LongestTrip],
	MIN(DATEDIFF(DAY,t.ArrivalDate, t.ReturnDate)) AS [ShortestTrip]
	FROM Accounts AS a
		JOIN AccountsTrips AS act ON act.AccountId = a.Id
		JOIN Trips AS t ON t.Id = act.TripId
WHERE MiddleName IS NULL AND CancelDate IS NULL
GROUP BY a.Id, a.FirstName, a.LastName
ORDER BY [LongestTrip] DESC, a.Id