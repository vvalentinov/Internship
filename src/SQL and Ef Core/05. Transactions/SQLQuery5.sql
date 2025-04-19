USE AdventureWorks2019;

-- Update Product ListPrice and Log the Change

BEGIN TRANSACTION;

DECLARE @OldPrice MONEY;

SELECT @OldPrice = ListPrice
FROM Production.Product
WHERE ProductID = 707;

UPDATE Production.Product
SET ListPrice = ListPrice + 20
WHERE ProductID = 707;

INSERT INTO Production.ProductDocument (ProductID, DocumentNode, ModifiedDate)
VALUES (707, hierarchyid::GetRoot(), GETDATE());

COMMIT TRANSACTION;
