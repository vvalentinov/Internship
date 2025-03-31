namespace CSharp_DotNetBasics.Cars;

public class SportsCar : Car
{
    public SportsCar(
        string make,
        string model,
        int topSpeed,
        int horsePower,
        int torque,
        double zeroToSixty)
        : base(make, model, topSpeed, horsePower)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(torque);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(zeroToSixty);
        Torque = torque;
        ZeroToSixty = zeroToSixty;
    }

    public int Torque { get; init; }

    public double ZeroToSixty { get; init; }

    public bool IsInSportsMode { get; set; }

    public override void Accelerate(int speed)
    {
        if (CurrentSpeed + speed > TopSpeed)
        {
            throw new InvalidOperationException($"Cannot accelerate beyond {TopSpeed} speed.");
        }

        CurrentSpeed += IsInSportsMode ? (speed + 20) : speed;
    }
}
