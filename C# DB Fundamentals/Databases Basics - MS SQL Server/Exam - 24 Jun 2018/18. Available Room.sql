CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
BEGIN

	DECLARE @roomInHotel NVARCHAR(MAX) =
	(SELECT TOP(1) CONCAT('Room ', r.Id, ': ', r.[Type], ' (', r.Beds, ' beds) - $', (h.BaseRate + r.Price) * @People) FROM Trips AS t
	 JOIN Rooms AS r ON r.Id = t.RoomId
	 JOIN Hotels AS h ON h.Id = r.HotelId
	 WHERE @HotelId = h.Id 
	 AND r.Beds > @People
	 AND @Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate 
	 AND t.CancelDate IS NULL
	 ORDER BY r.Price DESC)
	
	IF @roomInHotel IS NULL
	BEGIN 
		RETURN 'No rooms available'
	END

	RETURN @roomInHotel
END
