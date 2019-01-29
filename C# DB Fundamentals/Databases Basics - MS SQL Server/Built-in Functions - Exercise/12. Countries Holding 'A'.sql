SELECT CountryName, IsoCode FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

--WHERE LEN(CountryName) - LEN(REPLACE(CountyName, 'a', '')) >= 3