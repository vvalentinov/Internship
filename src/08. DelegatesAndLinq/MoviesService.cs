namespace DelegatesAndLinq;

public delegate void MovieAction(IList<Movie> movies, string suffix);

public class MoviesService
{
    public MovieAction AddSuffixToTitles = (movies, suffix) =>
    {
        for (var i = 0; i < movies.Count; i++)
        {
            movies[i].Title = $"{movies[i].Title}{suffix}";
        }
    };

    public Action<IList<Movie>, string> AddStringToMovieTitle = (movies, input) =>
    {
        for (int i = 0; i < movies.Count; i++)
        {
            movies[i].Title = $"{input}{movies[i].Title}";
        }
    };

    public Func<IList<Movie>, string, IList<Movie>> AddStringToDirectorName = (movies, input) =>
    {
        for (int i = 0; i < movies.Count; i++)
        {
            movies[i].Director.Name = $"{input}{movies[i].Director.Name}";
        }

        return movies;
    };

    public Action<Movie, Actor> AddActorToMovie = (movie, actor) =>
    {
        if (movie.Actors.Select(x => x.Name).Contains(actor.Name) == false)
        {
            movie.Actors.Add(actor);
        }
    };

    public Func<IList<Movie>, double, IList<Movie>> GetMoviesWithAboveRating = delegate (
        IList<Movie> movies,
        double ratingThreshold)
    {
        return [.. movies.Where(movie => movie.Rating > ratingThreshold)];
    };
}
