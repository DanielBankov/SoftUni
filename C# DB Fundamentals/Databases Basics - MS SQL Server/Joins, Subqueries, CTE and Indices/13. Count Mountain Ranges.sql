SELECT CountryCode, COUNT(MountainRange) FROM MountainsCountries AS mc
	JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE CountryCode IN ('BG', 'RU', 'US')
GROUP BY CountryCode
