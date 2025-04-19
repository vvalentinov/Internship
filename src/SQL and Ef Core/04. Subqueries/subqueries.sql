USE AdventureWorks2019;

-- List customer's id's who have placed an order where the total due exceeds the average order total.
SELECT
	c.CustomerID,
	soh.TotalDue
FROM Sales.Customer as c
JOIN Sales.SalesOrderHeader as soh ON soh.CustomerID = c.CustomerID
WHERE soh.TotalDue > (SELECT AVG(TotalDue) FROM Sales.SalesOrderHeader)

-- get the product id for the product, with product number equls to the product with name 'Thin-Jam Hex Nut 6'
SELECT
	ProductID
FROM Production.[Product]
WHERE ProductNumber =
	(
		SELECT
			ProductNumber
		FROM Production.[Product]
		WHERE [Name] = 'Thin-Jam Hex Nut 6'
	);


-- select the people whose address type is shipping
SELECT
	BusinessEntityID,
	FirstName,
	LastName
FROM Person.Person
WHERE BusinessEntityID IN (
	SELECT
		BusinessEntityID
	FROM Person.BusinessEntityAddress
	WHERE AddressTypeID = 5
)

-- get products that have been ordered
SELECT
	ProductID,
	[Name] 
FROM Production.[Product]
WHERE ProductID IN (SELECT ProductID FROM Sales.SalesOrderDetail);

-- find customers from a specific state
SELECT
	BusinessEntityID,
	FirstName,
	LastName  
FROM Person.Person  
WHERE BusinessEntityID IN (  
    SELECT
		BusinessEntityID
	FROM Person.BusinessEntityAddress  
    WHERE AddressID IN (  
        SELECT
			AddressID
		FROM Person.[Address]
		WHERE StateProvinceID = 79
    )  
);

-- get employees working in the Sales department
SELECT
	BusinessEntityID,
	JobTitle
FROM HumanResources.Employee  
WHERE BusinessEntityID IN (  
    SELECT
		BusinessEntityID
	FROM HumanResources.EmployeeDepartmentHistory  
    WHERE DepartmentID = (
        SELECT DepartmentID FROM HumanResources.Department WHERE [Name] = 'Sales'
	)  
);

-- find the most expensive product sold
SELECT
	ProductID,
	[Name],
	ListPrice
FROM Production.[Product]
WHERE ListPrice = (SELECT MAX(ListPrice) FROM Production.[Product]);

-- get customers who placed at least one order
SELECT
	CustomerID,
	PersonID
FROM Sales.Customer
WHERE CustomerID IN (SELECT CustomerID FROM Sales.SalesOrderHeader);


SELECT
	SalesOrderID,
	OrderDate,
	TotalDue  
FROM Sales.SalesOrderHeader  
WHERE OrderDate >= (  
    SELECT MAX(OrderDate) - 30 FROM Sales.SalesOrderHeader  
);