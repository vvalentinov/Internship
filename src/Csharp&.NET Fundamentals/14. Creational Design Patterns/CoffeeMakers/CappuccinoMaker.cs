using _14._Creational_Design_Patterns.Coffees;
using _14._Creational_Design_Patterns.MilkTypes;

namespace _14._Creational_Design_Patterns.CoffeeMakers;

public class CappuccinoMaker : CoffeeMaker
{
    private readonly Milk _milk;

    public CappuccinoMaker(Milk milk)
    {
        _milk = milk;
    }

    public override Coffee MakeCoffee() => new Cappuccino(_milk);
}
