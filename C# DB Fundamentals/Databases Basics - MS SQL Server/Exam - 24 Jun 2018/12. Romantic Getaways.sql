SELECT a.Id, Email, c.[Name], COUNT(a.Id) AS [Trips] FROM Accounts AS a
	 JOIN AccountsTrips AS act ON act.AccountId = a.Id
	 JOIN Trips AS t ON t.Id = act.TripId
	 JOIN Rooms AS r ON r.Id = t.RoomId
	 JOIN Hotels AS h ON h.Id = r.HotelId
	 JOIN Cities AS c ON c.Id = a.CityId
WHERE a.CityId = h.CityId
GROUP BY a.Id, Email, c.[Name]
ORDER BY [Trips] DESC, a.Id
