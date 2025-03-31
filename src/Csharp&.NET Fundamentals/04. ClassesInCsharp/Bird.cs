namespace ClassesInCsharp;

public class Bird : Animal
{
    public Bird(string name)
    {
        Name = name;
    }

    public override string Eat() => $"{Name} is eating like a bird.";
}
