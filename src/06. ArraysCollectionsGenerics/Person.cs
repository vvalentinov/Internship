namespace ArraysCollectionsGenerics;

using static System.Environment;

public class Person : IEntity
{
    public Person(
        int id,
        string name,
        int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public int Id { get; init; }

    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }

    public override string ToString()
        => $"{nameof(Id)}: {Id}{NewLine}{nameof(Name)}: {Name}{NewLine}{nameof(Age)}: {Age}";
}
