USE AdventureWorks2019;

-- Update Employee Salaries in a Transaction
BEGIN TRANSACTION;

UPDATE HumanResources.EmployeePayHistory
SET Rate = Rate * 1.10
FROM HumanResources.EmployeePayHistory AS eph
INNER JOIN HumanResources.Employee AS e
    ON eph.BusinessEntityID = e.BusinessEntityID
WHERE e.JobTitle = 'Production Technician - WC60';

COMMIT TRANSACTION;

