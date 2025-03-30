namespace ClassesInCsharp;

public class Mammal : Animal
{
    private string _favoriteFood = "Unknown";

    public Mammal(
        string name,
        int age,
        string furColor,
        string healthStatus = "Healthy")
    {
        Age = age;
        Name = name;
        FurColor = furColor;
        HealthStatus = healthStatus;
    }

    public string FurColor { get; set; } = string.Empty;

    public string HealthStatus { get; set; }

    public string FavoriteFood
    {
        get { return _favoriteFood; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _favoriteFood = "Unknown";
            }
            else
            {
                _favoriteFood = value;
            }
        }
    }
}
