namespace ClassesInCsharp;

public abstract class Animal
{
    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }

    public int Weight { get; set; }

    public virtual string Eat() => $"{Name} is eating.";

}
