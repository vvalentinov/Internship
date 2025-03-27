namespace DelegatesAndLinq;

public class Movie
{
    public string Title { get; set; } = string.Empty;

    public int ReleaseYear { get; set; }

    public string Genre { get; set; } = string.Empty;

    public double Rating { get; set; }

    public TimeSpan Duration { get; set; }

    public IList<Actor> Actors { get; set; } = [];

    public Director Director { get; set; } = new();
}
