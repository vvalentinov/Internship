namespace _14._Creational_Design_Patterns.Coffees;

public class Espresso : Coffee
{
    public Espresso()
    {
        BlackCoffees = [CoffeeSubstance.GetInstance()];
    }
}
