using AdvancedLinq.Models;

namespace AdvancedLinq;

public class Database : IDatabase
{
    public IList<Department> Departments
    {
        get
        {
            return [
                new() {Id = 1, Name = "Marketing"},
                new() {Id = 2, Name = "Human Resources"},
                new() {Id = 3, Name = "IT"},
                new() {Id = 4, Name = "Finance"},
            ];
        }
    }

    public IList<Address> Addresses
    {
        get
        {
            return [
                new() {Id = 1, Street = "123 Main St"},
                new() {Id = 2, Street = "456 Tech Ave"},
                new() {Id = 3, Street = "789 Money Blvd"},
                new() {Id = 4, Street = "321 Market St"},
            ];
        }
    }

    public IList<Employee> Employees
    {
        get
        {
            return [
                new()
                {
                    Id = 1,
                    Name = "Alice Johnson",
                    Department = Departments[0],
                    Address = Addresses[0],
                    Salary = 1500.00,
                },
                new()
                {
                    Id = 2,
                    Name = "Bob Smith",
                    Department = Departments[0],
                    Address = Addresses[1],
                    Salary = 2145.00,
                },
                new()
                {
                    Id = 3,
                    Name = "Charlie Davis",
                    Department = Departments[1],
                    Address = Addresses[2],
                    Salary = 3754.12,
                },
                new()
                {
                    Id = 4,
                    Name = "Diana Evans",
                    Department = Departments[2],
                    Address = Addresses[2],
                    Salary = 2010.12,
                }
            ];
        }
    }
}
