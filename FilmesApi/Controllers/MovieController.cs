using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private static List<Movie> movieList = [];

    [HttpPost]
    public void AddMovie([FromBody] Movie movie)
    {
        movieList.Add(movie);
        Console.WriteLine("--------Filme--------");
        Console.WriteLine($"Titulo: {movie.Title}");
        Console.WriteLine($"Genero: {movie.Genre}");
        Console.WriteLine($"Duracao: {movie.Duration}");

    }
}
