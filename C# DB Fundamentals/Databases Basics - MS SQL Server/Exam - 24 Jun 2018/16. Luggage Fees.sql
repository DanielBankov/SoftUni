SELECT t.Id, SUM(act.Luggage) AS [Luggage],
CASE
WHEN SUM(act.Luggage) > 5 THEN CONCAT('$', SUM(act.Luggage) * 5)
ELSE '$0'
END AS [Fee]
FROM Accounts AS a
	JOIN AccountsTrips AS act ON act.AccountId = a.Id
	JOIN Trips AS t ON t.Id = act.TripId
WHERE act.Luggage > 0
GROUP BY t.Id
ORDER BY [Luggage] DESC