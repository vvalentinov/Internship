USE AdventureWorks2019;

-- Insert a New Customer and Associate an Address

BEGIN TRANSACTION;

-- Step 1: Create a new BusinessEntity
INSERT INTO Person.BusinessEntity (rowguid, ModifiedDate)
VALUES (NEWID(), GETDATE());

DECLARE @BusinessEntityID INT = SCOPE_IDENTITY();

-- Step 2: Insert into Person.Person
INSERT INTO Person.Person (BusinessEntityID, PersonType, NameStyle, FirstName, LastName, EmailPromotion)
VALUES (@BusinessEntityID, 'IN', 0, 'John', 'Doe', 0);

-- Step 3: Insert into Sales.Customer using the new PersonID
INSERT INTO Sales.Customer (PersonID, StoreID, TerritoryID)
VALUES (@BusinessEntityID, NULL, 1);

-- Step 4: Associate with existing address (assume AddressID = 1, AddressTypeID = 2)
INSERT INTO Person.BusinessEntityAddress (BusinessEntityID, AddressID, AddressTypeID)
VALUES (@BusinessEntityID, 1, 2);

COMMIT TRANSACTION;
