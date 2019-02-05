CREATE TABLE Students
(
	StudentID INT,
	[Name] VARCHAR(25) 
)

CREATE TABLE Exams
(
	ExamID INT,
	[Name] VARCHAR(25) 
)

CREATE TABLE StudentsExams
(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL
)

ALTER TABLE Students
ALTER COLUMN StudentID INT NOT NULL

ALTER TABLE Students
ADD CONSTRAINT PK_Students PRIMARY KEY(StudentID)

ALTER TABLE Exams
ALTER COLUMN ExamID INT NOT NULL

ALTER TABLE Exams
ADD CONSTRAINT PK_Exams PRIMARY KEY(ExamID)

ALTER TABLE StudentsExams
ADD CONSTRAINT PK_StudentExams PRIMARY KEY(StudentID, ExamID)

ALTER TABLE StudentsExams 
ADD CONSTRAINT FK_StudentExam_Student FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    CONSTRAINT FK_StudentExam_Exam FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)

--INSERT INTO Students (StudentID, [Name]) VALUES
--(1, 'Mila'),                                   
--(2,	'Toni'),
--(3,	'Ron')

--INSERT INTO Exams(ExamID, [Name]) VALUES
--(101, 'SpringMVC'),
--(102, 'Neo4j'),
--(103, 'Oracle 11g')

--INSERT INTO StudentExams(StudentID, ExamID) VALUES
--(1,	101),
--(1,	102),
--(2,	101),
--(3,	103),
--(2,	102),
--(2,	103)
