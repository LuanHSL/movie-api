using FilmesApi.Data;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{

    private MovieContext _movieContext;

    public MovieController(MovieContext movieContext)
    {
        _movieContext = movieContext;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] Movie movie)
    {
        _movieContext.Movie.Add(movie);
        _movieContext.SaveChanges();
        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovie([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _movieContext.Movie.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = _movieContext.Movie.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }
}
