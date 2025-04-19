USE AdventureWorks2019;

-- Rollback on Stock Transfer if Product Not Found

BEGIN TRANSACTION;

BEGIN TRY
    UPDATE Production.ProductInventory
    SET Quantity = Quantity - 5
    WHERE ProductID = 9999 AND LocationID = 1;

    IF @@ROWCOUNT = 0
        THROW 51000, 'Product not found', 1;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT ERROR_MESSAGE();
END CATCH;
