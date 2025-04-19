USE AdventureWorks2019;

-- Adjust Employee Vacation Hours and Log History

BEGIN TRANSACTION;

UPDATE HumanResources.Employee
SET VacationHours = VacationHours + 8
WHERE BusinessEntityID = 1;

INSERT INTO HumanResources.EmployeeDepartmentHistory (BusinessEntityID, DepartmentID, ShiftID, StartDate)
VALUES (1, 1, 1, GETDATE());

COMMIT TRANSACTION;
