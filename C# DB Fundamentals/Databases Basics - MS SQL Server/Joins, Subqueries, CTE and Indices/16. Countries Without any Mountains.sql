SELECT COUNT(c.CountryCode) FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
WHERE mc.CountryCode IS NULL