using System.Diagnostics.CodeAnalysis;
using AdvancedLinq.Models;

namespace AdvancedLinq.Comparers;

public class DepartmentComparer : IEqualityComparer<Department>
{
    public bool Equals(Department? first, Department? second)
         => first?.Id == second?.Id &&
             first?.Name == second?.Name;

    public int GetHashCode([DisallowNull] Department obj)
        => (obj.Id, obj.Name).GetHashCode();
}
