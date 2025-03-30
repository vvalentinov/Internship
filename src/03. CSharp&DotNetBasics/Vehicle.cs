namespace CSharp_DotNetBasics;

using static System.Environment;

public abstract class Vehicle
{
    public string Make { get; init; } = string.Empty;

    public string Model { get; init; } = string.Empty;

    public int Year { get; init; }

    public int TopSpeed { get; init; }

    public int CurrentSpeed { get; set; }

    public VehicleColor Color { get; set; }

    public abstract string StartEngine();

    public virtual string GetInfo()
        => $"{nameof(Make)}: {Make}{NewLine}{nameof(Model)}: {Model}{NewLine}{nameof(TopSpeed)}: {TopSpeed}";
}
