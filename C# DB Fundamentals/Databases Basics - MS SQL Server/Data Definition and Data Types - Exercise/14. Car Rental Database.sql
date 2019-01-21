CREATE TABLE Categories
(
	Id INT IDENTITY,
	CategoryName NVARCHAR(20),
	DailyRate DECIMAL(2,1) DEFAULT 0,
	WeeklyRate DECIMAL(2,1) DEFAULT 0,
	MonthlyRate DECIMAL(2,1) DEFAULT 0,
	WeekendRate DECIMAL(2,1) DEFAULT 0,
	CONSTRAINT PK_Categoies_Id PRIMARY KEY(Id)
)

INSERT INTO Categories VALUES
('Sport', 2, 4, 5, 1),
('Offroad', 1, 1, 3, 0),
('Comfort', 5, 5, 5, 4)

CREATE TABLE Cars
(
	Id INT IDENTITY,
	PlateNumber NVARCHAR(10) NOT NULL,
	Manufacturer NVARCHAR(50) NOT NULL,
	Model NVARCHAR(20) NOT NULL,
	CarYear SMALLINT NOT NULL,
	CategoryId INT NOT NULL,
	Doors SMALLINT NOT NULL,
	Picture VARBINARY,
	Condition NVARCHAR(50),
	Available NVARCHAR(3),
	CONSTRAINT PK_Cars_Id PRIMARY KEY (Id),
	CONSTRAINT FK_Cars_CategoryId FOREIGN KEY(CategoryId) REFERENCES Categories(Id),
	CONSTRAINT CHK_Cars_Picture CHECK (DATALENGTH(Picture) <= 2097152),
	CONSTRAINT CHK_Cars_Doors CHECK (Doors = 2 OR Doors = 4),
	CONSTRAINT CHK_Cars_Available CHECK (Available = 'yes' OR Available = 'no')
)

INSERT INTO Cars VALUES
('153251VA', 'Audi', 'A3', 2009, 1, 2, NULL, 'Good', 'yes'),
('UK2145KMV', 'Tesla', 'Model S', 2017, 3, 4, NULL, 'Excellent', 'yes'),
('CA5262BA', 'BMW', 'E60', 2006, 1, 2, NULL, 'Bad', 'no')

CREATE TABLE Employees
(
	Id INT IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX),
	CONSTRAINT PK_Employees_Id PRIMARY KEY(Id)
)

INSERT INTO Employees VALUES
('Ivan', 'Kolev', 'Bank Manager', NULL),
('Drago', 'Ivanov', 'Professional Driver', NULL),
('Petko', 'Kirov', 'Officer', NULL)

CREATE TABLE Customers
(
	Id INT IDENTITY,
	DriveLicenceNumber INT NOT NULL,
	FullName NVARCHAR(200) NOT NULL,
	[Address] NVARCHAR(200) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	ZIPCode INT NOT NULL,
	Notes NVARCHAR(MAX),
	CONSTRAINT PK_Customers_Id PRIMARY KEY(Id)
)

INSERT INTO Customers VALUES
(346346231, 'Ivan Ivanov Ivanov', '53 Aspen Rd.', 'Hickory', 28601, NULL),
(526981002, 'Stamat Stamatov Stamatov', '377 Bohemia Street', 'Mahwah', 07430, NULL),
(589095292, 'Kolio Kolev Kolev', '9796 Hill St.', 'Oakwand', 94603, NULL)

CREATE TABLE RentalOrders 
(
	Id INT IDENTITY,
	EmployeeId INT NOT NULL, 
    CustomerId INT NOT NULL, 
    CarId INT NOT NULL, 
    TankLevel INT NOT NULL, 
    KilometrageStart FLOAT NOT NULL,
    KilometrageEnd FLOAT NOT NULL, 
    TotalKilometrage AS KilometrageEnd - KilometrageStart, 
    StartDate DATE NOT NULL, 
    EndDate DATE NOT NULL, 
    TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
    RateApplied DECIMAL NOT NULL,
    TaxRate DECIMAL NOT NULL, 
    OrderStatus BIT NOT NULL,
    Notes NVARCHAR(MAX),
	CONSTRAINT PK_RentalOrders_Id PRIMARY KEY(Id),
	CONSTRAINT FK_RentalOrders_EmployeesId FOREIGN KEY(EmployeeId) REFERENCES Employees(Id),
	CONSTRAINT FK_RentalOrders_CustomerId FOREIGN KEY(CustomerId) REFERENCES Customers(Id),
	CONSTRAINT FK_RentalOrders_CarsId FOREIGN KEY(CarId) REFERENCES Cars(Id)
)

INSERT INTO RentalOrders VALUES
(1, 2, 1, 50, 250000, 320000, '2004-09-11', '2004-11-02', 190, 20, 1, NULL),
(2, 3, 2, 100, 460000, 690000, '2018-12-14', '2019-02-22', 150, 20, 0, NULL),
(1, 2, 3, 90, 153663, 160099, '2009-04-24', '2009-5-02', 100, 20, 1, NULL)