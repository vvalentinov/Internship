USE AdventureWorks2019

-- FIRST TASK
SELECT
	FirstName,
	LastName,
	BusinessEntityID as [Employee_id]
FROM Person.[Person]
ORDER BY LastName ASC

-- SECOND TASK
SELECT
	person.BusinessEntityID AS [Employee_Id],
	person.FirstName,
	person.LastName,
	person_phone.PhoneNumber
FROM Person.Person as person
JOIN Person.PersonPhone as person_phone on person.BusinessEntityID = person_phone.BusinessEntityID
WHERE person.LastName like 'L%'
ORDER BY person.FirstName, person.LastName

-- THIRD TASK
SELECT
	PostalCode,
	person.FirstName,
	person.LastName,
	sale_person.SalesYTD,
	ROW_NUMBER() OVER (ORDER BY sale_person.SalesYTD DESC) AS RowNum
FROM [Person].[Address]
JOIN [Sales].[SalesPerson] as sale_person on sale_person.TerritoryID = AddressID
JOIN [Person].[Person] as person on person.BusinessEntityID = sale_person.BusinessEntityID
WHERE sale_person.TerritoryID IS NOT NULL AND sale_person.SalesYTD > 0
ORDER BY SalesYTD DESC, PostalCode ASC;

-- FOURTH TASK
SELECT
	SalesOrderID,
	SUM(LineTotal) as [Total Cost]
FROM Sales.SalesOrderDetail
GROUP BY SalesOrderID
HAVING SUM(LineTotal) > 100000
