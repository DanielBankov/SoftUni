CREATE PROC usp_CancelOrder(@OrderId INT, @CancelDate DATE)
AS
DECLARE @targetOrder DATETIME = (SELECT [Datetime] FROM Orders WHERE @OrderId = Id)

IF(@targetOrder IS NULL)
BEGIN
	RAISERROR('The order does not exist!', 16, 1)
	RETURN
END

IF(DATEDIFF(DAY, @targetOrder, @CancelDate) > 3)
BEGIN
	RAISERROR('You cannot cancel the order!', 16, 2)
END

DELETE FROM OrderItems
WHERE OrderId = @OrderId

DELETE FROM Orders
WHERE Id = @OrderId