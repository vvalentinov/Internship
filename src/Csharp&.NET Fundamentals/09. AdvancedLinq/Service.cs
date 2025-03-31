using AdvancedLinq.DTOs;
using AdvancedLinq.Models;
using AdvancedLinq.Comparers;

namespace AdvancedLinq;

public class Service
{
    private static readonly DepartmentComparer _departmentComparer = new();
    private static readonly AddressComparer _addressComparer = new();
    private static readonly EmployeeComparer _employeeComparer = new();

    private readonly IDatabase _db;

    public Service(IDatabase database)
    {
        _db = database;
    }

    public IEnumerable<EmployeeDepartmentDto> JoinEmployeeWithDepartment()
    {
        var result = _db.Employees.Join(
            _db.Departments,
            employee => employee.Department.Id,
            department => department.Id,
            (employee, department) => new EmployeeDepartmentDto
            {
                EmployeeId = employee.Id,
                EmployeeName = employee.Name,
                DepartmentName = department.Name,
            });

        return result;
    }

    public IEnumerable<DepartmentEmployeesDto> GroupJoinDepartmentsWithEmployees()
    {
        var departmentGroups = _db.Departments.GroupJoin(
            _db.Employees,
            department => department.Id,
            employee => employee.Department.Id,
            (department, empGroup) => new DepartmentEmployeesDto
            {
                DepartmentName = department.Name,
                EmployeesNames = [.. empGroup.Select(e => e.Name)]
            });

        return departmentGroups;
    }

    public IEnumerable<string> GetEmployeeStreetInfo()
    {
        var result = _db.Employees.Zip(
            _db.Addresses,
            (employee, address)
                => $"{employee.Name} lives at {address.Street}.");

        return result;
    }

    public IEnumerable<AddressEmployeesDto> EmployeesGroupByAddresses()
    {
        var result = _db.Employees
            .GroupBy(employee => employee.Address)
            .Select(group => new AddressEmployeesDto
            {
                Street = group.Key.Street,
                EmployeesNames = [.. group.Select(employee => employee.Name)],
            });

        return result;
    }

    public IEnumerable<Department> ConcatDepartments()
    {
        var otherDepartments = new List<Department>
        {
            new() {Id = 1, Name = "Administration"},
            new() {Id = 2, Name = "Customer Service"},
            new() {Id = 4, Name = "Logistics"},
            new() {Id = 9, Name = "Finance"},
        };

        var result = _db.Departments.Concat(otherDepartments);

        return result;
    }

    public IEnumerable<Address> IntersectAddresses()
    {
        var otherAdresses = new List<Address>
        {
            new() {Id = 1, Street = "150 Main St"},
            new() {Id = 2, Street = "456 Tech Ave"},
            new() {Id = 3, Street = "790 Money Blvd"},
            new() {Id = 4, Street = "321 Market St"},
        };

        var result = _db.Addresses.Intersect(
            otherAdresses,
            _addressComparer);

        return result;
    }

    public IEnumerable<Department> UnionDepartments()
    {
        var otherDepartments = new List<Department>
        {
            new() {Id = 1, Name = "Administration"},
            new() {Id = 2, Name = "Human Resources"},
            new() {Id = 3, Name = "IT"},
            new() {Id = 4, Name = "Logistics"},
        };

        var result = _db.Departments.Union(
            otherDepartments,
            _departmentComparer);

        return result;
    }

    public IEnumerable<Employee> Except()
    {
        var otherEmployees = new List<Employee>
        {
            new()
            {
                Id = 1,
                Name = "Alice Johnson",
                Department = _db.Departments[0],
                Address = _db.Addresses[0],
            },
            new()
            {
                Id = 2,
                Name = "Bob Smith",
                Department = _db.Departments[0],
                Address = _db.Addresses[1]
            },
            new()
            {
                Id = 15,
                Name = "Charlie Day",
                Department = _db.Departments[1],
                Address = _db.Addresses[2]
            },
            new()
            {
                Id = 47,
                Name = "Diana Peters",
                Department = _db.Departments[2],
                Address = _db.Addresses[2]
            }
        };

        var result = _db.Employees.Except(
            otherEmployees,
            _employeeComparer);

        return result;
    }

    public int CountEmployeeNamesWithNameLengthLessThan(int length)
    {
        return _db.Employees.Count(employee => employee.Name.Length < length);
    }

    public long CountEmployeeNamesWithNameBiggerOrEqualTo(int length)
    {
        return _db.Employees.LongCount(employee => employee.Name.Length >= length);
    }

    public int GetSmallestNameLengthOfAnEmployee()
    {
        return _db.Employees.Min(employee => employee.Name.Length);
    }

    public int GetBiggestNameLengthOfAnEmployee()
    {
        return _db.Employees.Max(employee => employee.Name.Length);
    }

    public double GetTotalSumOfEmployeesSalary()
    {
        return _db.Employees.Sum(employee => employee.Salary);
    }

    public double GetAverageEmployeeSalary()
    {
        return _db.Employees.Average(employee => employee.Salary);
    }

    public string Aggregate()
    {
        var result = _db.Employees
            .Aggregate(
            "Salaries/Salaries After Tax: ",
            (result, employee)
                => result += $"{employee.Salary}/{employee.Salary * 0.2:f2}, ")
            .TrimEnd(',', ' ');

        return result;
    }

    public bool ContainsEmployee()
    {
        var employee = new Employee
        {
            Id = 1,
            Name = "Alice Johnson",
            Department = _db.Departments[0],
            Address = _db.Addresses[0],
            Salary = 1500.00,
        };

        var result = _db.Employees.Contains(employee, _employeeComparer);

        return result;
    }

    public bool AnyAddressThatEndsWith(string input)
    {
        var result = _db.Addresses.Any(a => a.Street.EndsWith(input));
        return result;
    }

    public bool AllAddressesHaveAValidId()
    {
        var result = _db.Addresses.All(a => a.Id > 0);
        return result;
    }

    public bool SequencesEqualExample()
    {
        var otherDepartments = new List<Department>
        {
            new() {Id = 1, Name = "Marketing"},
            new() {Id = 2, Name = "Human Resources"},
            new() {Id = 3, Name = "IT"},
            new() {Id = 4, Name = "Finance"},
        };

        var result = _db.Departments.SequenceEqual(
            otherDepartments,
            _departmentComparer);

        return result;

    }
}
