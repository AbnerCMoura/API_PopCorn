using Microsoft.AspNetCore.Mvc;
using PopCornAndCritics.Models;
using PopCornAndCritics.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace PopCornAndCritics.Controllers;

public class MovieController : ControllerBase
{
    public readonly Context _context;

    public MovieController(Context context)
    {
        _context = context;
    }

    /// <summary>
    /// Cadastrar novo filme Temporário
    /// </summary>
    //Register movie // Temporario
    [HttpPost("movie/register")]
    public async Task<ActionResult<Movie>> MovieResgister([FromBody] Movie movie)
    {
        await _context.Movie.AddAsync(movie);
        await _context.SaveChangesAsync();

        return Ok(movie);
    }

    /// <summary>
    /// Recebe todos os filmes
    /// </summary>
    [HttpGet("movie/getall")]
    public async Task<List<Movie>> GetAll()
    {
        var movie = await _context.Movie.ToListAsync();
        return movie;
    }

    /// <summary>
    /// Recebe filmes por id
    /// </summary>
    //Take movie by id
    [HttpGet("movie/get/{id}")]
    public async Task<ActionResult<Movie>> GetMovie(int id)
    {
        var movie = await _context.Movie.FirstOrDefaultAsync(x => x.Id == id);

        if(movie == null)
        {
            return NotFound("Filme não encontrado no banco de dados");
        }

        return Ok(movie);
    }

    /// <summary>
    /// Recebe filmes por Gênero
    /// </summary>
    //Take movie by genre
    [HttpGet("movie/get/genre/{genre}")]
    public ActionResult<Movie> MovieGenre(string genre)
    {
        var movies =  _context.Movie.Where(m => m.Genre == genre).ToList();

        if(movies == null)
        {
            return NotFound("Nenhum filme encontrado");
        }

        return Ok(movies);
    }

    // atualizar filme //temporario
    [HttpPatch("/movie/update/{id}")]
    public async Task<ActionResult> Update (int id, string genre)
    {
        var movie = _context.Movie.FirstOrDefault(x => x.Id == id);

        movie.Genre = genre;
        await _context.SaveChangesAsync();

        return Ok(movie);
    }
}
