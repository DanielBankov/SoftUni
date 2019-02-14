SELECT CountryCode, MountainRange, PeakName, Elevation FROM MountainsCountries AS mc
	JOIN Mountains AS m ON m.Id = mc.MountainId
	JOIN Peaks AS p ON p.MountainId = m.Id
WHERE CountryCode = 'BG' AND Elevation > 2835
ORDER BY Elevation DESC