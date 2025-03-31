namespace DelegatesAndLinq;

public static class MovieListExtensions
{
    public static Movie? GetMovieByTitle(this IList<Movie> movies, string title)
        => movies.FirstOrDefault(movie => movie.Title == title);

    public static IList<Movie> GetMoviesByDirectorName(
        this IList<Movie> movies,
        string directorName)
        => [.. movies.Where(movie => movie.Director.Name == directorName)];

    public static void WriteMovieTitlesToConsole(this IList<Movie> movies)
    {
        foreach (var movie in movies)
        {
            Console.WriteLine(movie.Title);
        }
    }

    public static void WriteMovieDirectorNameToConsole(this IList<Movie> movies)
    {
        foreach (var movie in movies)
        {
            Console.WriteLine(movie.Director.Name);
        }
    }
}
