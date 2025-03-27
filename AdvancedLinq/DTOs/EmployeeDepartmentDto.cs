namespace AdvancedLinq.DTOs;

using static System.Environment;

public class EmployeeDepartmentDto
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = string.Empty;

    public string DepartmentName { get; set; } = string.Empty;

    public override string ToString()
        => $"{nameof(EmployeeId)}: {EmployeeId}{NewLine}{nameof(EmployeeName)}: {EmployeeName}{NewLine}{nameof(DepartmentName)}: {DepartmentName}";
}
