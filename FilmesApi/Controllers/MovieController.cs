using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private static List<Movie> movieList = [];
    private static int id = 0;

    [HttpPost]
    public IActionResult AddMovie([FromBody] Movie movie)
    {
        movie.Id = id++;
        movieList.Add(movie);
        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovie([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return movieList.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = movieList.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }
}
