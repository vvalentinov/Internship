namespace CSharp_DotNetBasics.Cars;

using System;
using System.Text.Json;
using static Environment;

public class Hybrid : Car, ICloneable
{
    private int _batteryLevel;

    public Hybrid(
        string make,
        string model,
        int topSpeed,
        int horsePower,
        int chargingTime)
        : base(make, model, topSpeed, horsePower)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(chargingTime);
        ChargingTime = chargingTime;
    }

    public int ChargingTime { get; init; }

    public int BatteryLevel
    {
        get { return _batteryLevel; }
        set
        {
            if (value < 0)
            {
                throw new InvalidOperationException("The battery level percentage cannot be a negative number!");
            }

            if (value > 100)
            {
                throw new InvalidOperationException("The battery level percetange cannot exceed 100!");
            }

            _batteryLevel = value;
        }
    }

    public bool IsFullyCharged { get { return BatteryLevel == 100; } }

    public new object Clone()
    {
        var serializedObject = JsonSerializer.Serialize(this);
        return JsonSerializer.Deserialize<Hybrid>(serializedObject);
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $"{NewLine}{nameof(ChargingTime)}: {ChargingTime}{NewLine}{nameof(BatteryLevel)}: {BatteryLevel}{NewLine}{nameof(IsFullyCharged)}: {IsFullyCharged}";
    }
}
