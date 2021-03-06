SELECT TOP(10) FirstName, LastName, COUNT(st.StudentId) AS [Count] FROM Teachers AS t
	JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
	GROUP BY FirstName, LastName
	ORDER BY [Count] DESC, FirstName, LastName