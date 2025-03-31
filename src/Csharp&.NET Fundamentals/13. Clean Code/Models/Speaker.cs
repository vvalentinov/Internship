namespace _13._Clean_Code.Models;

using static System.Environment;

public class Speaker
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int Experience { get; set; }

    public bool HasBlog { get; set; }

    public string BlogURL { get; set; } = string.Empty;

    public WebBrowser Browser { get; set; } = new();

    public List<string> Certifications { get; set; } = [];

    public string Employer { get; set; } = string.Empty;

    public int RegistrationFee { get; set; }

    public List<Session> Sessions { get; set; } = [];

    public override string ToString()
        => $"{nameof(Id)}: {Id}{NewLine}{nameof(FirstName)}: {FirstName}{NewLine}{nameof(LastName)}: {LastName}";
}
