namespace ClassesInCsharp;

public class Mammal : Animal
{
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
}
