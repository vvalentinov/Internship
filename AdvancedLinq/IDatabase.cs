using AdvancedLinq.Models;

namespace AdvancedLinq;

public interface IDatabase
{
    public IList<Department> Departments { get; }

    public IList<Address> Addresses { get; }

    public IList<Employee> Employees { get; }
}
