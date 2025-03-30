namespace CSharp_DotNetBasics.Planes;

using static Environment;

public class CommercialPlane : Plane
{
    public CommercialPlane(
        string make,
        string model,
        int topSpeed,
        int wingspan,
        int maxAltitude,
        int engineCount,
        double range,
        int passengerCapacity,
        bool hasAutopilot,
        string airline,
        int numberOfCabins)
        : base(make, model, topSpeed, wingspan, maxAltitude, engineCount, range, passengerCapacity, hasAutopilot)
    {
        Airline = airline;
        NumberOfCabins = numberOfCabins;
    }

    public string Airline { get; init; }

    public int NumberOfCabins { get; init; }

    public int CurrentPassengers { get; private set; }

    public string ServeMeals()
        => $"Meals are being served on {Airline}'s {Model}.";

    public string BoardPassengers(int numberOfPassengers)
    {
        if (CurrentPassengers + numberOfPassengers > PassengerCapacity)
        {
            return $"Cannot board {numberOfPassengers} passengers. Only {PassengerCapacity - CurrentPassengers} seats left.";
        }

        CurrentPassengers += numberOfPassengers;
        return $"{numberOfPassengers} passengers boarded. Total onboard: {CurrentPassengers}.";
    }

    public string DeboardPassengers(int numberOfPassengers)
    {
        if (numberOfPassengers > CurrentPassengers)
        {
            return $"Cannot deboard {numberOfPassengers} passengers. Only {CurrentPassengers} onboard.";
        }

        CurrentPassengers -= numberOfPassengers;
        return $"{numberOfPassengers} passengers deboarded. Remaining onboard: {CurrentPassengers}.";
    }

    public double GetOccupancyRate()
    {
        return (double)CurrentPassengers / PassengerCapacity * 100;
    }

    public override string GetInfo()
    {
        return base.GetInfo() +
               $"{NewLine}{nameof(Airline)}: {Airline}" +
               $"{NewLine}{nameof(NumberOfCabins)}: {NumberOfCabins}" +
               $"{NewLine}{nameof(CurrentPassengers)}: {CurrentPassengers}/{PassengerCapacity}" +
               $"{NewLine}Occupancy Rate: {GetOccupancyRate():0.0}%";
    }
}
