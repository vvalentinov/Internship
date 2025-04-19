USE AdventureWorks2019;

-- Insert Order Header and Details Together

USE AdventureWorks2019;
GO

BEGIN TRANSACTION;

DECLARE @SalesOrderID INT;

-- Insert into SalesOrderHeader
INSERT INTO Sales.SalesOrderHeader (
    RevisionNumber,
    OrderDate,
    DueDate,
    ShipDate,
    Status,
    OnlineOrderFlag,
    PurchaseOrderNumber,
    AccountNumber,
    CustomerID,
    SalesPersonID,
    TerritoryID,
    BillToAddressID,
    ShipToAddressID,
    ShipMethodID,
    CreditCardID,
    CreditCardApprovalCode,
    SubTotal,
    TaxAmt,
    Freight,
    Comment,
    rowguid,
    ModifiedDate
)
VALUES (
    1,
    GETDATE(),
    DATEADD(DAY, 7, GETDATE()),
    GETDATE(),
    1,
    1,
    'PO123456',
    '10-4020-000676',
    11000,
    279,
    1,
    1098,
    1098,
    5,
    11545,
    'APPROVED',
    100.00,
    8.00,
    5.00,
    'Test order',
    NEWID(),
    GETDATE()
);

-- Get the new SalesOrderID
SET @SalesOrderID = SCOPE_IDENTITY();

-- Insert into SalesOrderDetail
INSERT INTO Sales.SalesOrderDetail (
    SalesOrderID,
    OrderQty,
    ProductID,
    SpecialOfferID,
    UnitPrice,
    UnitPriceDiscount,
    rowguid,
    ModifiedDate
)
VALUES (
    @SalesOrderID,
    2,
    776,
    1,
    202.64,
    0.0,
    NEWID(),
    GETDATE()
);

COMMIT TRANSACTION;
