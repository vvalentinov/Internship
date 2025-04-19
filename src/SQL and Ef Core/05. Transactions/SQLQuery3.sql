USE AdventureWorks2019;

-- Transfer Stock Between Locations
BEGIN TRANSACTION;

-- Subtract from source location
UPDATE Production.ProductInventory
SET Quantity = Quantity - 10
WHERE ProductID = 776 AND LocationID = 1;

-- Add to destination location
UPDATE Production.ProductInventory
SET Quantity = Quantity + 10
WHERE ProductID = 776 AND LocationID = 6;

COMMIT TRANSACTION;
