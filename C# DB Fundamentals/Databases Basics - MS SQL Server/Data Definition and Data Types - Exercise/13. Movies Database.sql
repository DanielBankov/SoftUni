CREATE TABLE Directors
(
	Id INT IDENTITY,
	DirectorName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX),
	CONSTRAINT PK_Directors_Id PRIMARY KEY (Id)
)

CREATE TABLE Genres
(
	Id INT IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX),
	CONSTRAINT PK_Genres_Id PRIMARY KEY(Id)
)

CREATE TABLE Categories
(
	Id INT IDENTITY,
	CategoryName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_Category_Id PRIMARY KEY(Id)
)

CREATE TABLE Movies
(
	Id INT IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear SMALLINT NOT NULL,
	[Length] SMALLINT NOT NULL,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating DECIMAL(2, 1) DEFAULT 0,
	Notes NVARCHAR(MAX),
	CONSTRAINT PK_Movies_Id PRIMARY KEY(Id),
	CONSTRAINT FK_Director_Id FOREIGN KEY(DirectorId) REFERENCES Directors(Id),
	CONSTRAINT FK_Genre_Id FOREIGN KEY(GenreId) REFERENCES Genres(Id),
	CONSTRAINT FK_Category_Id FOREIGN KEY(CategoryId) REFERENCES Categories(Id),
)
 
INSERT INTO Directors VALUES
('Xavier Gens', 'Some title'),
('Jerry Zucker', 'Some title'),
('Clint Eastwood', 'Some title'),
('Martin Scorsese', NULL),
('Brad Silberling', NULL)

INSERT INTO Genres VALUES
('Action, Drama', 'so many fire shots'),
('Comedy', 'laughter to tears'),
('Fentasy, Adventure', NULL),
('Thriller', NULL),
('Action', NULL)

INSERT INTO Categories VALUES
('Action Films', NULL),
('Action/Adventure Films', NULL),
('Adventure Films', NULL),
('Comedy Films', NULL),
('Crime Film', NULL)

INSERT INTO Movies VALUES
('Nqkoisi', 1, 2007, 100, 5, 1, 6.2, NULL),
('Gran Torino', 3, 2008, 116, 1, 1, 8.1, NULL),
('Rat Race', 2, 2001, 112, 2, 4, 6.4, NULL),
('A Series of Unfortunate Events', 5, 2004, 108, 3, 3, 6.8, NULL),
('The Divide', 1, 2011, 112, 5, 5, 5.8, 'Scary movie')

SELECT * FROM Directors

SELECT * FROM Genres

SELECT * FROM Categories

SELECT * FROM Movies