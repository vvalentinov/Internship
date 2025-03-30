using ClassesInCsharp;

Animal myMammal = new Mammal(name: "Lion", age: 12, furColor: "Reddish");
Animal myBird = new Bird(name: "Eagle");

AnimalAction(myMammal, times: 3);
AnimalAction(myBird, isHungry: false, times: 2);

static void AnimalAction(
    Animal animal,
    bool isHungry = true,
    int times = 1)
{
    // The "is" operator
    if (animal is Mammal mammal)
    {
        Console.WriteLine($"{mammal.Name} is a mammal.");
    }

    // The "as" operator
    var bird = animal as Bird;
    if (bird is not null)
    {
        Console.WriteLine($"{bird.Name} is a bird.");
    }

    if (isHungry)
    {
        for (int i = 0; i < times; i++)
        {
            animal.Eat();
        }
    }
    else
    {
        Console.WriteLine($"{animal.Name} is not hungry.");
    }
}