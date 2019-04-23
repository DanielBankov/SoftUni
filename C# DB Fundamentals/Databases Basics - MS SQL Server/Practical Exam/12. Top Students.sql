SELECT TOP(10) FirstName, LastName, FORMAT(AVG(Grade), 'N2') AS [Grade] FROM Students AS s
	JOIN StudentsExams AS se ON se.StudentId = s.Id
	GROUP BY FirstName, LastName
	ORDER BY [Grade] DESC, FirstName, LastName

	--student sub, sub