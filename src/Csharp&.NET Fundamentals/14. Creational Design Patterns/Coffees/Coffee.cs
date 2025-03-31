using System.Text;
using _14._Creational_Design_Patterns.MilkTypes;

namespace _14._Creational_Design_Patterns.Coffees;

public abstract class Coffee
{
    public IList<Sugar> Sugars { get; set; } = [];

    public IList<Milk> MilkTypes { get; set; } = [];

    public IList<CoffeeSubstance> BlackCoffees { get; init; } = [];

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine($"Coffee: {GetType().Name}");
        builder.AppendLine($"Sugars: {Sugars.Count}");

        if (MilkTypes.Count > 0)
        {
            builder.AppendLine("Milk Types:");

            foreach (var milkType in MilkTypes)
            {
                builder.AppendLine($"   {milkType.GetType().Name}");
            }
        }

        return builder.ToString();
    }
}
