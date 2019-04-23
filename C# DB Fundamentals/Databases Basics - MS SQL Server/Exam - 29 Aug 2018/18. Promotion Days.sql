CREATE FUNCTION udf_GetPromotedProducts(@CurrentDate DATETIME, @StartDate DATETIME, @EndDate DATETIME, @Discount DECIMAL(15, 2), @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
RETURNS NVARCHAR(MAX)
BEGIN 
	DECLARE @firstName VARCHAR(50) = (SELECT [Name] FROM Items WHERE @FirstItemId = Id)
	DECLARE @SecondName VARCHAR(50) = (SELECT [Name] FROM Items WHERE @SecondItemId = Id)
	DECLARE @ThirdName VARCHAR(50) = (SELECT [Name] FROM Items WHERE @ThirdItemId = Id)

	IF(@firstName IS NULL OR @SecondName IS NULL OR @ThirdName IS NULL)
	BEGIN
		RETURN 'One of the items does not exists!'
	END

	IF(@CurrentDate NOT BETWEEN @StartDate AND @EndDate)
	BEGIN
		RETURN 'The current date is not within the promotion dates!'
	END

	DECLARE @firstItemPrice DECIMAL(15, 2) = (SELECT Price FROM Items WHERE @FirstItemId = Id)
	DECLARE @secondItemPrice DECIMAL(15, 2) = (SELECT Price FROM Items WHERE @SecondItemId = Id)
	DECLARE @thirdItemPrice DECIMAL(15, 2) = (SELECT Price FROM Items WHERE @ThirdItemId = Id)

	SET @firstItemPrice -= @firstItemPrice * (@Discount / 100)
	SET @secondItemPrice -= @secondItemPrice * (@Discount / 100)
	SET @thirdItemPrice -= @thirdItemPrice * (@Discount / 100)

	RETURN @firstName + ' price: ' + CAST(@firstItemPrice AS VARCHAR(20)) + ' <-> ' + 
		   @SecondName + ' price: ' + CAST(@secondItemPrice AS VARCHAR(20)) + ' <-> ' + 
		   @ThirdName + ' price: ' + CAST(@thirdItemPrice AS VARCHAR(20))
END

--SELECT dbo.udf_GetPromotedProducts('2018-08-02', '2018-08-01', '2018-08-03',13, 3,4,5)

--SELECT dbo.udf_GetPromotedProducts('2018-08-01', '2018-08-02', '2018-08-03',13,3 ,4,5)