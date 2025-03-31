// make cappuccino
using _14._Creational_Design_Patterns.CoffeeMakers;
using _14._Creational_Design_Patterns.Coffees;
using _14._Creational_Design_Patterns.MilkTypes;

CoffeeMaker cappuccinoMaker = new CappuccinoMaker(new SoyMilk());

var cappucino = cappuccinoMaker.MakeCoffee();

// add some more milk(Regular) and two sugars
cappucino.MilkTypes.Add(new RegularMilk());
cappucino.Sugars = [Sugar.GetInstance(), Sugar.GetInstance()];

// Write Some Info to Console
Console.WriteLine(cappucino);

Console.WriteLine();

// make espresso
CoffeeMaker esspressoMaker = new EspressoMaker();

var espresso = esspressoMaker.MakeCoffee();

// add some more milk(Regular) and two sugars
espresso.MilkTypes.Add(new SoyMilk());
espresso.MilkTypes.Add(new OatMilk());
espresso.Sugars = [
    Sugar.GetInstance(),
    Sugar.GetInstance(),
    Sugar.GetInstance(),
    Sugar.GetInstance()
];

// Write Some Info to Console
Console.WriteLine(espresso);

// Make FlatWhite coffee

var flatWhiteCoffeeMaker = new FlatWhiteMaker(new OatMilk());

var flatWhite = flatWhiteCoffeeMaker.MakeCoffee();

flatWhite.MilkTypes.Add(new RegularMilk());
flatWhite.MilkTypes.Add(new SoyMilk());

flatWhite.Sugars.Add(Sugar.GetInstance());
flatWhite.Sugars.Add(Sugar.GetInstance());
flatWhite.Sugars.Add(Sugar.GetInstance());

Console.WriteLine(flatWhite);
