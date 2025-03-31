namespace _14._Creational_Design_Patterns.Coffees;

public class Sugar
{
    private static Sugar _instance = null!;

    private static readonly object _lock = new();

    private Sugar() { }

    public static Sugar GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                _instance ??= new Sugar();
            }
        }

        return _instance;
    }
}
