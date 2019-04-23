SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name] FROM Students AS s
	FULL JOIN StudentsExams AS se ON se.StudentId = s.Id
	WHERE Grade IS NULL
	ORDER BY [Full Name]