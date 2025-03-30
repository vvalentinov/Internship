using System.Diagnostics.CodeAnalysis;
using AdvancedLinq.Models;

namespace AdvancedLinq.Comparers;

public class AddressComparer : IEqualityComparer<Address>
{
    public bool Equals(Address? first, Address? second)
        => first?.Id == second?.Id &&
            first?.Street == second?.Street;

    public int GetHashCode([DisallowNull] Address obj)
        => (obj.Id, obj.Street).GetHashCode();
}
