--CREATE TABLE ExcludedStudents (StudentId INT, StudentName NVARCHAR(MAX))
CREATE TRIGGER tr_DeleteStudent ON Students AFTER DELETE
AS
INSERT INTO ExcludedStudents (StudentId, StudentName)
SELECT Id, CONCAT(FirstName, ' ', LastName) FROM deleted 

--DELETE FROM StudentsExams
--WHERE StudentId = 1

--DELETE FROM StudentsTeachers
--WHERE StudentId = 1

--DELETE FROM StudentsSubjects
--WHERE StudentId = 1

--DELETE FROM Students
--WHERE Id = 1

--SELECT * FROM ExcludedStudents
