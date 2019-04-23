SELECT t.Id, h.[Name], r.[Type], 
CASE
WHEN t.CancelDate IS NOT NULL THEN 0.00
ELSE SUM(h.BaseRate + r.Price)
END
AS [Revenue] FROM Trips AS t
	JOIN Rooms AS r ON r.Id = t.RoomId
    JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN AccountsTrips AS act ON act.TripId = t.Id
GROUP BY t.Id, h.[Name], r.[Type],  t.CancelDate
ORDER BY r.[Type], t.Id