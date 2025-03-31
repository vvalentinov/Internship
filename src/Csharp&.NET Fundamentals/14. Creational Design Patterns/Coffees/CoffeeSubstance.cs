namespace _14._Creational_Design_Patterns.Coffees;

public class CoffeeSubstance
{
    private static CoffeeSubstance _instance = null!;

    private static readonly object _lock = new();

    private CoffeeSubstance() { }

    public static CoffeeSubstance GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                _instance ??= new CoffeeSubstance();
            }
        }

        return _instance;
    }
}
