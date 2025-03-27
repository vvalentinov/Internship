namespace DelegatesAndLinq;

public class Director
{
    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }

    public string Nationality { get; set; } = string.Empty;

    public IList<string> Awards { get; set; } = [];
}
