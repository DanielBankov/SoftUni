CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15, 2))
RETURNS NVARCHAR(MAX)
BEGIN 
	DECLARE @validateStudentId INT = (SELECT Id FROM Students
									  WHERE @studentId = Id)
	IF(@validateStudentId IS NULL)
	BEGIN
		RETURN 'The student with provided id does not exist in the school!'
	END
 
	IF(@grade > 6.00)
	BEGIN
		RETURN 'Grade cannot be above 6.00!'
	END

	DECLARE @countOfGrades INT = (SELECT COUNT(Grade) FROM Students AS s
								  JOIN StudentsExams AS se ON se.StudentId = s.Id
								  WHERE s.Id = @studentId AND Grade >= @grade AND Grade <= (@grade + 0.50))

	DECLARE @studentName NVARCHAR(30) = (SELECT FirstName FROM Students
										 WHERE @studentId = Id)
	
	RETURN CONCAT('You have to update ', CAST(@countOfGrades AS NVARCHAR(10)), ' grades for the student ', @studentName)
END

--SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)

--SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)

--SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)


--SELECT * FROM Students AS s
--	 JOIN StudentsExams AS se ON se.StudentId = s.Id
--	 --JOIN Exams AS e ON e.Id = se.ExamId
--	 WHERE s.Id = 12 AND Grade >= 5.50 AND Grade < (5.50 + 0.50)
--	 --GROUP BY s.FirstName, s.Id
