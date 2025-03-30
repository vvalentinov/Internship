namespace ClassesInCsharp;

public class Omnivore : Mammal
{
    public Omnivore(
        string name,
        int age,
        string furColor,
        string healthStatus = "Healthy")
        : base(name, age, furColor, healthStatus)
    {
    }

    public override string Eat() => $"{Name} is eating both plants and meat.";
}
