namespace DelegatesAndLinq;

public class MovieDb
{
    private readonly IList<Movie> _movies;

    public MovieDb()
    {
        _movies = GenerateMovies();
    }

    public IList<Movie> Movies { get { return _movies; } }

    static List<Movie> GenerateMovies()
    {
        var movies = new List<Movie>
        {
            new()
            {
                Title = "Inception",
                Director = new Director { Name = "Christopher Nolan" },
                Rating = 8.0,
                Actors =
                [
                    new() { Name = "Leonardo DiCaprio" },
                    new() { Name = "Joseph Gordon-Levitt" },
                    new() { Name = "Elliot Page" },
                    new() { Name = "Tom Hardy" },
                    new() { Name = "Ken Watanabe" }
                ]
            },
            new()
            {
                Title = "Interstellar",
                Rating = 9.0,
                Director = new Director { Name = "Christopher Nolan" },
                Actors =
                [
                    new() { Name = "Matthew McConaughey" },
                    new() { Name = "Anne Hathaway" },
                    new() { Name = "Jessica Chastain" },
                    new() { Name = "Bill Irwin" },
                    new() { Name = "Michael Caine" }
                ]
            },
            new()
            {
                Title = "The Dark Knight",
                Rating = 9.0,
                Director = new Director { Name = "Christopher Nolan" },
                Actors =
                [
                    new() { Name = "Christian Bale" },
                    new() { Name = "Heath Ledger" },
                    new() { Name = "Aaron Eckhart" },
                    new() { Name = "Gary Oldman" },
                    new() { Name = "Michael Caine" }
                ]
            },
            new()
            {
                Title = "The Godfather",
                Rating = 7.9,
                Director = new Director { Name = "Francis Ford Coppola" },
                Actors =
                [
                    new() { Name = "Marlon Brando" },
                    new() { Name = "Al Pacino" },
                    new() { Name = "James Caan" },
                    new() { Name = "Robert Duvall" },
                    new() { Name = "Diane Keaton" }
                ]
            },
            new()
            {
                Title = "Pulp Fiction",
                Rating = 7.5,
                Director = new Director { Name = "Quentin Tarantino" },
                Actors =
                [
                    new() { Name = "John Travolta" },
                    new() { Name = "Samuel L. Jackson" },
                    new() { Name = "Uma Thurman" },
                    new() { Name = "Bruce Willis" },
                    new() { Name = "Ving Rhames" }
                ]
            },
            new()
            {
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Rating = 7.8,
                Director = new Director { Name = "Peter Jackson" },
                Actors =
                [
                    new() { Name = "Elijah Wood" },
                    new() { Name = "Ian McKellen" },
                    new() { Name = "Viggo Mortensen" },
                    new() { Name = "Orlando Bloom" },
                    new() { Name = "Sean Astin" }
                ]
            }
        };

        return movies;
    }
}
