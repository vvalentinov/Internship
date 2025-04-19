USE AdventureWorks2019;

-- Simulate a Payment with Rollback on Failure

BEGIN TRANSACTION;

BEGIN TRY
    UPDATE Sales.SalesOrderHeader
    SET CreditCardApprovalCode = 'APPROVED123'
    WHERE SalesOrderID = 43659;

    -- Simulate failure
    DECLARE @Err INT = 1 / 0;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'Transaction rolled back due to error.';
END CATCH;
