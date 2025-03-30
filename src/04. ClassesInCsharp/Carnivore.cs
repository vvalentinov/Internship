namespace ClassesInCsharp;

public class Carnivore : Mammal
{
    public Carnivore(
        string name,
        int age,
        string furColor,
        string healthStatus = "Healthy")
        : base(name, age, furColor, healthStatus)
    {
    }

    public override string Eat() => $"{Name} is eating meat.";
}
