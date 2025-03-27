namespace AdvancedLinq.DTOs;

public class AddressEmployeesDto
{
    public string Street { get; set; } = string.Empty;

    public IEnumerable<string> EmployeesNames { get; set; } = [];
}
