namespace ClassesInCsharp;

public class Herbivore : Mammal
{
    public Herbivore(
        string name,
        int age,
        string furColor,
        string healthStatus = "Healthy")
        : base(name, age, furColor, healthStatus)
    {
    }

    public override string Eat() => $"{Name} is eating plants.";
}
