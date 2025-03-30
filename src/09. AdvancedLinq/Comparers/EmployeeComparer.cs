using AdvancedLinq.Models;
using System.Diagnostics.CodeAnalysis;

namespace AdvancedLinq.Comparers;

public class EmployeeComparer : IEqualityComparer<Employee>
{
    public bool Equals(Employee? first, Employee? second)
        => first?.Id == second?.Id &&
           first?.Name == second?.Name &&
           first?.Department?.Name == second?.Department?.Name &&
           first?.Address?.Street == second?.Address?.Street;

    public int GetHashCode([DisallowNull] Employee obj)
    {
        return HashCode.Combine(
            obj.Id,
            obj.Name,
            obj.Department?.Name ?? string.Empty,
            obj.Address?.Street ?? string.Empty
        );
    }
}
