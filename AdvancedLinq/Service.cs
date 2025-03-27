using AdvancedLinq.DTOs;
using AdvancedLinq.Models;
using AdvancedLinq.Comparers;

namespace AdvancedLinq;

public class Service
{
    private static readonly DepartmentComparer _departmentComparer = new();
    private static readonly AddressComparer _addressComparer = new();
    private static readonly EmployeeComparer _employeeComparer = new();

    public static IEnumerable<EmployeeDepartmentDto> JoinEmployeeWithDepartment(
        IEnumerable<Employee> employees,
        IEnumerable<Department> departments)
    {
        var result = employees.Join(
            departments,
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

    public static IEnumerable<DepartmentEmployeesDto> GroupJoinDepartmentsWithEmployees(
        IEnumerable<Employee> employees,
        IEnumerable<Department> departments)
    {
        var departmentGroups = departments.GroupJoin(
            employees,
            department => department.Id,
            employee => employee.Department.Id,
            (department, empGroup) => new DepartmentEmployeesDto
            {
                DepartmentName = department.Name,
                EmployeesNames = [.. empGroup.Select(e => e.Name)]
            });

        return departmentGroups;
    }

    public static IEnumerable<string> GetEmployeeStreetInfo(
        IEnumerable<Employee> employees,
        IEnumerable<Address> addresses)
    {
        var result = employees.Zip(
            addresses,
            (employee, address)
                => $"{employee.Name} lives at {address.Street}.");

        return result;
    }

    public static IEnumerable<AddressEmployeesDto> EmployeesGroupByAddresses(
        IEnumerable<Employee> employees)
    {
        var result = employees
            .GroupBy(employee => employee.Address)
            .Select(group => new AddressEmployeesDto
            {
                Street = group.Key.Street,
                EmployeesNames = [.. group.Select(employee => employee.Name)],
            });

        return result;
    }

    public static IEnumerable<Department> ConcatDepartments(IEnumerable<Department> departments)
    {
        var otherDepartments = new List<Department>
        {
            new() {Id = 1, Name = "Administration"},
            new() {Id = 2, Name = "Customer Service"},
            new() {Id = 4, Name = "Logistics"},
            new() {Id = 9, Name = "Finance"},
        };

        var result = departments.Concat(otherDepartments);

        return result;
    }

    public static IEnumerable<Address> IntersectAddresses(IEnumerable<Address> addresses)
    {
        var otherAdresses = new List<Address>
        {
            new() {Id = 1, Street = "150 Main St"},
            new() {Id = 2, Street = "456 Tech Ave"},
            new() {Id = 3, Street = "790 Money Blvd"},
            new() {Id = 4, Street = "321 Market St"},
        };

        var result = addresses.Intersect(
            otherAdresses,
            _addressComparer);

        return result;
    }

    public static IEnumerable<Department> UnionDepartments(IEnumerable<Department> departments)
    {
        var otherDepartments = new List<Department>
        {
            new() {Id = 1, Name = "Administration"},
            new() {Id = 2, Name = "Human Resources"},
            new() {Id = 3, Name = "IT"},
            new() {Id = 4, Name = "Logistics"},
        };

        var result = departments.Union(
            otherDepartments,
            _departmentComparer);

        return result;
    }

    public static IEnumerable<Employee> Except(
        IEnumerable<Employee> employees,
        IList<Department> departments,
        IList<Address> addresses)
    {
        var otherEmployees = new List<Employee>
        {
            new()
            {
                Id = 1,
                Name = "Alice Johnson",
                Department = departments[0],
                Address = addresses[0],
            },
            new()
            {
                Id = 2,
                Name = "Bob Smith",
                Department = departments[0],
                Address = addresses[1]
            },
            new()
            {
                Id = 15,
                Name = "Charlie Day",
                Department = departments[1],
                Address = addresses[2]
            },
            new()
            {
                Id = 47,
                Name = "Diana Peters",
                Department = departments[2],
                Address = addresses[2]
            }
        };

        var result = employees.Except(
            otherEmployees,
            _employeeComparer);

        return result;
    }

    public static int CountEmployeeNamesWithNameLengthLessThan(
        IEnumerable<Employee> employees,
        int length)
    {
        return employees.Count(employee => employee.Name.Length < length);
    }

    public static long CountEmployeeNamesWithNameBiggerOrEqualTo(
        IEnumerable<Employee> employees,
        int length)
    {
        return employees.LongCount(employee => employee.Name.Length >= length);
    }

    public static int GetSmallestNameLengthOfAnEmployee(IEnumerable<Employee> employees)
    {
        return employees.Min(employee => employee.Name.Length);
    }

    public static int GetBiggestNameLengthOfAnEmployee(IEnumerable<Employee> employees)
    {
        return employees.Max(employee => employee.Name.Length);
    }

    public static double GetTotalSumOfEmployeesSalary(IEnumerable<Employee> employees)
    {
        return employees.Sum(employee => employee.Salary);
    }

    public static double GetAverageEmployeeSalary(IEnumerable<Employee> employees)
    {
        return employees.Average(employee => employee.Salary);
    }

    public static string Aggregate(IEnumerable<Employee> employees)
    {
        var result = employees
            .Aggregate(
            "Salaries/Salaries After Tax: ",
            (result, employee)
                => result += $"{employee.Salary}/{employee.Salary * 0.2:f2}, ")
            .TrimEnd(',', ' ');

        return result;
    }

    public static bool ContainsEmployee(
        IEnumerable<Employee> employees,
        IList<Department> departments,
        IList<Address> addresses)
    {
        var employee = new Employee
        {
            Id = 1,
            Name = "Alice Johnson",
            Department = departments[0],
            Address = addresses[0],
            Salary = 1500.00,
        };

        var result = employees.Contains(employee, _employeeComparer);

        return result;
    }

    public static bool AnyAddressThatEndsWith(
        IEnumerable<Address> addresses,
        string input)
    {
        var result = addresses.Any(a => a.Street.EndsWith(input));
        return result;
    }

    public static bool AllAddressesHaveAValidId(IEnumerable<Address> addresses)
    {
        var result = addresses.All(a => a.Id > 0);
        return result;
    }

    public static bool SequencesEqualExample(IEnumerable<Department> departments)
    {
        var otherDepartments = new List<Department>
        {
            new() {Id = 1, Name = "Marketing"},
            new() {Id = 2, Name = "Human Resources"},
            new() {Id = 3, Name = "IT"},
            new() {Id = 4, Name = "Finance"},
        };

        var result = departments.SequenceEqual(otherDepartments, _departmentComparer);
        return result;

    }
}
