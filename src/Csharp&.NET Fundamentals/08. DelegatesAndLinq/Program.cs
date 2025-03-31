using DelegatesAndLinq;

var db = new MovieDb();
var movies = db.Movies;

var moviesService = new MoviesService();

// Extension Methods
var pulpFictionMovie = movies.GetMovieByTitle("Pulp Fiction");
if (pulpFictionMovie is not null)
{
    Console.WriteLine("Searched Movie:");
    Console.WriteLine(pulpFictionMovie.Title);

    // add actor to movie
    moviesService.AddActorToMovie(
        pulpFictionMovie,
        new Actor() { Name = "Valentin" });

    var actor = pulpFictionMovie.Actors.FirstOrDefault(x => x.Name == "Valentin");
    Console.WriteLine(actor?.Name);
}

Console.WriteLine();

Console.WriteLine("Christopher Nolan Movies: ");
var moviesWithDirector = movies.GetMoviesByDirectorName("Christopher Nolan");
moviesWithDirector.WriteMovieTitlesToConsole();

Console.WriteLine();

Console.WriteLine("Updated Movie Titles and Director Names: ");
moviesService.AddStringToMovieTitle(movies, "Movie Title: ");
movies.WriteMovieTitlesToConsole();
moviesService.AddStringToDirectorName(movies, "Director: ");
movies.WriteMovieDirectorNameToConsole();

Console.WriteLine();
Console.WriteLine("Movies With Rating Bigger Than 7.9");
var moviesWithBiggerRating = moviesService.GetMoviesWithAboveRating(movies, 7.9);
moviesWithBiggerRating.WriteMovieTitlesToConsole();

moviesService.AddSuffixToTitles(movies, " Best Movie Ever!");
movies.WriteMovieTitlesToConsole();
