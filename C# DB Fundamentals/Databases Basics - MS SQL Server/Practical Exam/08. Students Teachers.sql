SELECT s.FirstName, s.LastName, COUNT(t.Id) FROM Students AS s
	JOIN StudentsTeachers AS st ON st.StudentId = s.Id
	JOIN Teachers AS t ON t.Id = st.TeacherId
GROUP BY s.FirstName, s.LastName
