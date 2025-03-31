using _14._Creational_Design_Patterns.MilkTypes;

namespace _14._Creational_Design_Patterns.Coffees;

public class FlatWhite : Coffee
{
    public FlatWhite(Milk milk)
    {
        MilkTypes = [milk];
        BlackCoffees = [
            CoffeeSubstance.GetInstance(),
            CoffeeSubstance.GetInstance(),
        ];
    }
}
