namespace CSharp_DotNetBasics.Planes;

using static System.Environment;

public class Plane : Vehicle
{
    public Plane(
        string make,
        string model,
        int topSpeed,
        int wingspan,
        int maxAltitude,
        int engineCount,
        double range,
        int passengerCapacity,
        bool hasAutopilot)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(make);
        ArgumentException.ThrowIfNullOrWhiteSpace(model);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(topSpeed);
        Make = make;
        Model = model;
        TopSpeed = topSpeed;
        Wingspan = wingspan;
        MaxAltitude = maxAltitude;
        EngineCount = engineCount;
        Range = range;
        PassengerCapacity = passengerCapacity;
        HasAutopilot = hasAutopilot;
    }

    public int Wingspan { get; init; }

    public int MaxAltitude { get; init; }

    public int EngineCount { get; init; }

    public double Range { get; init; }

    public int PassengerCapacity { get; init; }

    public bool HasAutopilot { get; init; } = false;

    public override string StartEngine()
        => $"Plane {Make} {Model} is starting it's engine...";

    public override string GetInfo()
    {
        return base.GetInfo()
            + $"{NewLine}{nameof(Wingspan)}: {Wingspan}"
            + $"{NewLine}{nameof(MaxAltitude)}: {MaxAltitude}"
            + $"{NewLine}{nameof(EngineCount)}: {EngineCount}"
            + $"{NewLine}{nameof(Range)}: {Range}"
            + $"{NewLine}{nameof(PassengerCapacity)}: {PassengerCapacity}"
            + $"{NewLine}{nameof(HasAutopilot)}: {HasAutopilot}";
    }
}
