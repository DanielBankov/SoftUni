SELECT Temp.Id, Temp.Email, Temp.CountryCode, Temp.Trips FROM
(SELECT a.Id, a.Email, c.CountryCode, COUNT(t.Id) AS Trips,
ROW_NUMBER() OVER (PARTITION BY c.CountryCode ORDER BY COUNT(t.Id) DESC) AS [RowOrder]
 FROM Accounts AS a
	JOIN AccountsTrips AS act ON act.AccountId = a.Id
	JOIN Trips AS t ON t.Id = act.TripId
	JOIN Rooms As r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS c ON c.Id = h.CityId
GROUP BY a.Id, a.Email, c.CountryCode) AS Temp
WHERE Temp.RowOrder = 1
ORDER BY Temp.Trips DESC, Temp.Id