namespace CSharp_DotNetBasics.Cars;

using static System.Environment;

public class Car : Vehicle, ICloneable
{
    public Car(
        string make,
        string model,
        int topSpeed,
        int horsePower)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(make);
        ArgumentException.ThrowIfNullOrWhiteSpace(model);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(topSpeed);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(horsePower);
        Make = make;
        Model = model;
        TopSpeed = topSpeed;
        HorsePower = horsePower;
    }

    public int HorsePower { get; init; }

    public override string StartEngine()
        => $"Car {Make} {Model} is starting it's engine...";

    public override string GetInfo()
    {
        return base.GetInfo() + $"{NewLine}{nameof(HorsePower)}: {HorsePower}";
    }

    public virtual void Accelerate(int speed)
    {
        if (CurrentSpeed + speed > TopSpeed)
        {
            throw new InvalidOperationException($"Cannot accelerate beyond {TopSpeed} speed.");
        }
        else
        {
            CurrentSpeed += speed;
        }
    }

    public virtual void FullStop() => CurrentSpeed = 0;

    public object Clone() => MemberwiseClone();
}
