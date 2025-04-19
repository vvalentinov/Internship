USE AdventureWorks2019;

-- How Many Employees In The Departments
SELECT
	d.[Name] as [Department Name],
	COUNT(edh.BusinessEntityID) as [People Count]
FROM HumanResources.Department as d
JOIN HumanResources.EmployeeDepartmentHistory as edh on edh.DepartmentID = d.DepartmentID
GROUP BY d.[Name]
ORDER BY d.[Name]

-- Get the department with the most employees
SELECT TOP 1
	d.[Name] as [Department Name],
	COUNT(edh.BusinessEntityID) as [People Count]
FROM HumanResources.Department as d
JOIN HumanResources.EmployeeDepartmentHistory as edh on edh.DepartmentID = d.DepartmentID
GROUP BY d.[Name]
ORDER BY COUNT(edh.BusinessEntityID) DESC

-- Get the department with the smallest number of employees
SELECT TOP 1
	d.[Name] as [Department Name],
	COUNT(edh.BusinessEntityID) as [People Count]
FROM HumanResources.Department as d
JOIN HumanResources.EmployeeDepartmentHistory as edh on edh.DepartmentID = d.DepartmentID
GROUP BY d.[Name]
ORDER BY COUNT(edh.BusinessEntityID) ASC

-- get employees who are in sales
SELECT
	BusinessEntityID,
	NationalIDNumber,
	JobTitle
FROM HumanResources.Employee
WHERE JobTitle like '%sales%'

-- get the sales territory with the biggest sales last year
SELECT TOP 1
	[Name],
	MAX(SalesLastYear) as [Biggest Sales]
FROM [Sales].[SalesTerritory]
GROUP BY [Name]
ORDER BY MAX(SalesLastYear) DESC

-- get the sales person with the biggest bonus
SELECT TOP 1
	BusinessEntityID,
	MAX(Bonus) as Bonus
FROM [AdventureWorks2019].[Sales].[SalesPerson]
GROUP BY BusinessEntityID
ORDER BY MAX(Bonus) DESC

-- get the count of products for the safety stock levels, that are bigger than 60
SELECT
	SafetyStockLevel,
	COUNT(*) as [Count of Products]
FROM [AdventureWorks2019].[Production].[Product]
GROUP BY SafetyStockLevel
HAVING SafetyStockLevel > 60


-- get the average cost for each product, sorted from biggest to smallest
SELECT
	 ProductID,
	 AVG(StandardCost) as [Average Cost]
FROM [Production].[Product]
GROUP BY ProductID
ORDER BY avg(StandardCost) DESC