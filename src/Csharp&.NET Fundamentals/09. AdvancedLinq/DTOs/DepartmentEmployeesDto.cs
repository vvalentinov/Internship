using System.Text;

namespace AdvancedLinq.DTOs;

public class DepartmentEmployeesDto
{
    public string DepartmentName { get; set; } = string.Empty;

    public List<string> EmployeesNames { get; set; } = [];

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine(DepartmentName);

        foreach (var employeeName in EmployeesNames)
        {
            builder.AppendLine(employeeName);
        }

        return builder.ToString();
    }
}
