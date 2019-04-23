SELECT CONCAT(t.FirstName, ' ', t.LastName) AS [Teacher Name], sub.Name, CONCAT(s.FirstName, ' ', s.LastName)AS [Student Name],
ROW_NUMBER() OVER(PARTITION BY t.FirstName, t.LastName ORDER BY FORMAT(AVG(se.Grade), 'N2')) AS [Rank]
 FROM Teachers AS t
	JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
	JOIN Students AS s ON s.Id = st.StudentId
	JOIN StudentsExams AS se ON se.StudentId = s.Id
	JOIN Subjects AS sub ON sub.Id = t.SubjectId
	GROUP BY t.FirstName, t.LastName,  sub.Name, s.FirstName, s.LastName