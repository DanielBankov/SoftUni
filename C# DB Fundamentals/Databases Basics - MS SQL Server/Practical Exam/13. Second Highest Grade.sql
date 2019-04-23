SELECT DISTINCT k.FirstName, k.LastName, k.Grade FROM 
(SELECT FirstName, LastName, Grade,
ROW_NUMBER() OVER(PARTITION BY s.FirstName, s.LastName ORDER BY Grade DESC) AS DR
FROM Students AS s
	 JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
	 JOIN Subjects AS sub ON sub.Id = ss.SubjectId) AS K
WHERE k.DR = 2
ORDER BY k.FirstName, K.LastName
