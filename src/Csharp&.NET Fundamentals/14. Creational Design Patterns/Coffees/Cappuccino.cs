using _14._Creational_Design_Patterns.MilkTypes;

namespace _14._Creational_Design_Patterns.Coffees;

public class Cappuccino : Coffee
{
    public Cappuccino(Milk milk)
    {
        MilkTypes = [milk];
        BlackCoffees = [CoffeeSubstance.GetInstance()];
    }
}
