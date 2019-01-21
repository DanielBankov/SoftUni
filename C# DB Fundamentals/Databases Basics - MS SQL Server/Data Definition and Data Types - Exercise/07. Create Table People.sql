CREATE TABLE People
(
	Id INT IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(15, 2),
	[Weight] DECIMAL(15, 2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX),
	CONSTRAINT PK_People_Id PRIMARY KEY (Id),
	CONSTRAINT CHK_People_Picture CHECK (DATALENGTH(Picture) <= 2097152),
	CONSTRAINT CHK_People_Gender CHECK (Gender = 'm' OR Gender = 'f')
)

INSERT INTO People VALUES 
('Drago', NULL, 1.70, 64, 'm', '1982/05/15', 'Some story'),
('Ivan', NULL, 1.89, 85, 'm', '1952/12/05', 'Some story'),
('Veselin', NULL, 1.81, 93, 'm', '1992/10/24', 'Some story'),
('Maria', NULL, 1.59, 55, 'f', '2001/01/06', 'Some story'),
('Petia', NULL, 1.60, 59, 'f', '1995/02/22', 'Some story') 

SELECT * FROM People