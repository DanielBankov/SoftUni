--CREATE TABLE DeletedOrders (OrderId INT, ItemId INT, ItemQuantity INT)

CREATE TRIGGER tr_DeletedOrders ON OrderItems AFTER DELETE
AS
INSERT INTO DeletedOrders (OrderId, ItemId, ItemQuantity)
SELECT OrderId, ItemId, Quantity FROM deleted

DELETE FROM OrderItems
WHERE OrderId = 5

DELETE FROM Orders
WHERE Id = 5 
