SELECT k.FullName, k.Lessons, COUNT(st.StudentId) AS [Students] FROM 
   (SELECT CONCAT(t.FirstName, ' ' ,t.LastName) AS [FullName],
    CONCAT(s.[Name], '-', (s.Lessons)) AS [Lessons],
    t.id AS id
    FROM Teachers AS t
		JOIN Subjects AS s ON s.Id = t.SubjectId
	GROUP BY t.FirstName, t.LastName, s.[Name], s.Lessons, t.Id) AS K
  JOIN StudentsTeachers AS st ON st.TeacherId = k.id	
GROUP BY k.FullName, k.Lessons
ORDER BY COUNT(st.StudentId) DESC, k.FullName, k.Lessons
		

