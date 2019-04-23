CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
DECLARE @targetStudent INT = (SELECT Id FROM Students WHERE @StudentId = Id)

IF(@targetStudent IS NULL)
BEGIN
	RAISERROR('This school has no student with the provided id!', 16, 1)
	RETURN
END

DELETE FROM StudentsTeachers
WHERE StudentId = @StudentId

DELETE FROM StudentsSubjects
WHERE StudentId = @StudentId

DELETE FROM StudentsExams
WHERE StudentId = @StudentId

DELETE FROM Students
WHERE Id = @StudentId

GO

DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
EXEC usp_ExcludeFromSchool 301
END TRY

BEGIN CATCH
SET @err_msg = ERROR_MESSAGE();
SELECT @err_msg
END CATCH
