using CSharp_DotNetBasics.Cars;
using CSharp_DotNetBasics.Enumerable;
using CSharp_DotNetBasics.Planes;

var car = new Car(
    make: "Toyota",
    model: "Corolla",
    topSpeed: 180,
    horsePower: 132);
car.Accelerate(50);
Console.WriteLine(car.GetInfo());
Console.WriteLine(car.StartEngine());
car.FullStop();

Console.WriteLine();

var hybridCar = new Hybrid(
    make: "Tesla",
    model: "Model 3",
    topSpeed: 250,
    horsePower: 283,
    chargingTime: 6)
{
    BatteryLevel = 80
};
hybridCar.Accelerate(100);
Console.WriteLine(hybridCar.GetInfo());
Console.WriteLine(hybridCar.StartEngine());

Console.WriteLine();

var sportsCar = new SportsCar(
    make: "Ferrari",
    model: "488 GTB",
    topSpeed: 330,
    horsePower: 661,
    torque: 760,
    zeroToSixty: 3.0)
{
    IsInSportsMode = true
};
sportsCar.Accelerate(50);
Console.WriteLine(sportsCar.GetInfo());
Console.WriteLine(sportsCar.StartEngine());

Console.WriteLine();

var plane = new CommercialPlane(
    make: "Boeing",
    model: "747",
    topSpeed: 900,
    wingspan: 60,
    maxAltitude: 35000,
    engineCount: 4,
    range: 8000,
    passengerCapacity: 400,
    hasAutopilot: true,
    airline: "Delta",
    numberOfCabins: 3);
Console.WriteLine(plane.GetInfo());
Console.WriteLine(plane.StartEngine());
Console.WriteLine(plane.ServeMeals());
Console.WriteLine(plane.BoardPassengers(150));
Console.WriteLine(plane.DeboardPassengers(50));
Console.WriteLine($"Occupancy rate: {plane.GetOccupancyRate():0.0}%");

if (hybridCar.IsFullyCharged == false)
{
    Console.WriteLine("The Hybrid car is charging... Please wait.");
}
else
{
    Console.WriteLine("The Hybrid car is fully charged and ready to go!");
}

// IEnumerable
var customCollection = new CustomCollection(["first word", "second word", "third word"]);

foreach (var item in customCollection)
{
    Console.WriteLine(item);
}