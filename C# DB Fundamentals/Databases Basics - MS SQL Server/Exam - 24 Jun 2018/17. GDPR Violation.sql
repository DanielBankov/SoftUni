SELECT t.Id,
    CONCAT(a.FirstName, ' ', ISNULL(a.MiddleName + ' ', ''), a.LastName) AS [Full Name],
	c.[Name] AS [From],
	ch.[Name] AS [To],
	CASE
	WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
	ELSE CAST(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS VARCHAR) + ' days'
	END
FROM Accounts AS a
	JOIN AccountsTrips AS act ON act.AccountId = a.Id
	JOIN Trips AS t ON t.Id = act.TripId
	JOIN Cities AS c ON c.Id = a.CityId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS ch ON ch.Id = h.CityId
ORDER BY [Full Name], t.Id