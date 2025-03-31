using ArraysCollectionsGenerics;

var peopleRepository = new Repository<Person>();

var alice = new Person(1, "Alice", 30);
var bob = new Person(2, "Bob", 25);

Console.WriteLine("Adding Alice and Bob...");
peopleRepository.Add(alice);
peopleRepository.Add(bob);

Console.WriteLine("Added People:");
var allPeople = peopleRepository.GetAll();
foreach (var person in allPeople)
{
    Console.WriteLine(person.ToString());
}

Console.WriteLine($"Current Alice's age: {alice.Age}");
Console.WriteLine("Updating Alice's age...");
alice.Age = 31;
peopleRepository.Update(alice);

var retrievedPerson = peopleRepository.GetById(alice.Id);
if (retrievedPerson is not null)
{
    Console.WriteLine("\nUpdated Person:");
    Console.WriteLine(retrievedPerson.ToString());
}

Console.WriteLine("Deleting Bob...");
peopleRepository.Delete(bob);

Console.WriteLine("\nPeople after removal:");
var allPeopleAfterRemoval = peopleRepository.GetAll();
foreach (var person in allPeopleAfterRemoval)
{
    Console.WriteLine(person.ToString());
}