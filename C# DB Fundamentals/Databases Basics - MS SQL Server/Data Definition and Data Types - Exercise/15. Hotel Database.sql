CREATE TABLE Employees
(
	Id INT IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Title NVARCHAR(30),
	Notes NVARCHAR(MAX),
	CONSTRAINT PK_Employees_Id PRIMARY KEY(Id)
)

INSERT INTO Employees VALUES
('Ivan', 'Ivanov', 'DJ', NULL),
('Dragan', 'Draganov', NULL, NULL),
('Iliq', 'Iliev', 'Chef', NULL)

CREATE TABLE Customers 
(
	AccountNumber INT IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	PhoneNumber NVARCHAR(15) NOT NULL,
	EmergencyName NVARCHAR(20),
	EmergencyNumber NVARCHAR(20),
	Notes NVARCHAR(500),
	CONSTRAINT PK_Customers_AccountNumber PRIMARY KEY(AccountNumber)
)

INSERT INTO Customers VALUES
('Gosho', 'Iliev', '0879937721', NULL, NULL, NULL), 
('Kiro', 'Kirov', '0894875386', '0879937724', NULL, NULL),
('Svetla', 'Bojanksa', '088881238', NULL, NULL, NULL)

CREATE TABLE RoomStatus 
(
	RoomStatus NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX),
	CONSTRAINT PK_RoomStatus PRIMARY KEY(RoomStatus)
)

INSERT INTO RoomStatus VALUES
('On-Change', NULL),
('Sleep-out', NULL),
('Skipper', NULL)

CREATE TABLE RoomTypes 
(
	RoomType NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_RoomType PRIMARY KEY(RoomType)
)

INSERT INTO RoomTypes VALUES
('Single', NULL),
('Double', NULL),
('Queen', NULL)

CREATE TABLE BedTypes
(
	BedType NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_BedType PRIMARY KEY(BedType)
)

INSERT INTO BedTypes VALUES
('Folding', NULL),
('Trundle', NULL),
('Standard', NULL)

CREATE TABLE Rooms 
(
	RoomNumber INT NOT NULL,
	RoomType NVARCHAR(20) NOT NULL,
	BedType NVARCHAR(20) NOT NULL,
	Rate DECIMAL(3,1) NOT NULL,
	RoomStatus BIT NOT NULL,
	Notes NVARCHAR(MAX),
	CONSTRAINT PK_Rooms_RoomNumber PRIMARY KEY(RoomNumber),
	CONSTRAINT FK_Rooms_RoomType FOREIGN KEY(RoomType) REFERENCES RoomTypes(RoomType),
	CONSTRAINT FK_Rooms_BedType FOREIGN KEY(BedType) REFERENCES BedTypes(BedType)
)

INSERT INTO Rooms VALUES
(105, 'Single', 'Trundle', 60.2, 1, NULL),
(213, 'Double', 'Standard', 55.5, 1, NULL),
(404, 'Queen', 'Folding', 99.8, 0, NULL)

CREATE TABLE Payments 
(
	Id INT IDENTITY,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATETIME NOT NULL,
	LastDateOccupied DATETIME NOT NULL,
	TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
	AmountCharged DECIMAL(15, 2) NOT NULL,
	TaxRate DECIMAL(15, 2) NOT NULL,
	TaxAmount AS AmountCharged * TaxRate,
	PaymentTotal AS AmountCharged + AmountCharged * TaxRate,
	Notes NVARCHAR(MAX),
	CONSTRAINT PK_Payments_Id PRIMARY KEY(Id),
	CONSTRAINT FK_Payments_EmpolyeeId FOREIGN KEY(EmployeeId) REFERENCES Employees(Id),
	CONSTRAINT FK_Payments_AccountNumber FOREIGN KEY(AccountNumber) REFERENCES Customers(AccountNumber)
)

INSERT INTO Payments VALUES
(1, '2003-01-13', 2, '2013-03-20', '2013-04-04', 50.0, 0.20, NULL),
(3, '2011-06-03', 3, '2017-12-06', '2018-01-02', 250.0, 0.20, NULL),
(2, '2016-02-25', 1, '2006-08-17', '2006-10-01', 550.0, 0.20, NULL)

CREATE TABLE Occupancies 
(
	Id INT IDENTITY,
	EmployeeId INT NOT NULL,
	DateOccupied DATE NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied DECIMAL(15, 2) NOT NULL,
	PhoneCharge NVARCHAR(10) ,
	Notes NVARCHAR(MAX),
	CONSTRAINT PK_Occupancies_Id PRIMARY KEY(Id),
	CONSTRAINT FK_Occupancies_EmpolyeeId FOREIGN KEY(EmployeeId) REFERENCES Employees(Id),
	CONSTRAINT FK_Occupancies_AccountNumber FOREIGN KEY(AccountNumber) REFERENCES Customers(AccountNumber),
	CONSTRAINT FK_Occupancies_RoomNumber FOREIGN KEY(RoomNumber) REFERENCES Rooms(RoomNumber)
)

INSERT INTO Occupancies VALUES
(2, '2016-12-05', 1, 404, 80.32, 'USB', NULL),
(3, '2003-11-07', 1, 105, 55.13, 'MICRO', NULL),
(3, '1999-10-06', 3, 213, 99.94, 'TYPE-C', NULL)