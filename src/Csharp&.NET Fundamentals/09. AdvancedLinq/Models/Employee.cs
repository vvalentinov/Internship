namespace AdvancedLinq.Models;

using static System.Environment;

public class Employee : BaseModel
{
    public string Name { get; set; } = string.Empty;

    public double Salary { get; set; }

    public Department Department { get; set; } = new();

    public Address Address { get; set; } = new();

    public override string ToString()
        => $"{nameof(Id)}: {Id}{NewLine}{nameof(Name)}: {Name}{NewLine}{nameof(Department)}: {Department.Name}{NewLine}{nameof(Address)}: {Address.Street}";
}
