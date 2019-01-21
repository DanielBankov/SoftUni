CREATE TABLE Users
(
	Id INT IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT,
	CONSTRAINT PK_User_Id PRIMARY KEY(Id),
	CONSTRAINT UQ_User_Username UNIQUE(Username),
	CONSTRAINT CHK_User_ProfilePicture CHECK(DATALENGTH(ProfilePicture) <= 921600)
)

INSERT INTO Users VALUES
('User01', 'password', NULL, '13:53', 0),
('User02', 'password', NULL, '16:13', 0),
('User03', 'password', NULL, '11:26', 0),
('User04', 'password', NULL, '05:55', 0),
('User05', 'password', NULL, '22:41', 0)

SELECT * FROM Users