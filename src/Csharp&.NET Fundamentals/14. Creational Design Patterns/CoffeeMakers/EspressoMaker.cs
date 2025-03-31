using _14._Creational_Design_Patterns.Coffees;

namespace _14._Creational_Design_Patterns.CoffeeMakers;

public class EspressoMaker : CoffeeMaker
{
    public override Coffee MakeCoffee() => new Espresso();
}
