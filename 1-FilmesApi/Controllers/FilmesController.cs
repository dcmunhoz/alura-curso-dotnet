using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController: ControllerBase
    {

        public static List<Filme> filmes = new();
        public static int count = 0;

        [HttpGet]
        public IActionResult ListaFilmes()
        {
            return filmes.Count > 0 ? Ok(filmes) : NoContent();
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
            count++;
            filme.Id = count; 
            filmes.Add(filme);

            return CreatedAtAction(nameof(BuscarFilme), new { Id = filme.Id }, filme);

        }

        [HttpGet("{id}")]
        public IActionResult BuscarFilme(int id)
        {
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);

            return filme == null ? NotFound() : Ok(filme);

        }

    }
}
