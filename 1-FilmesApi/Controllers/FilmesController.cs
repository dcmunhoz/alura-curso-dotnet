using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;
using FilmesApi.Data;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController: ControllerBase
    {

        public static List<Filme> filmes = new();
        public static int count = 0;

        private OracleDbContext _context; 

        public FilmesController(OracleDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListaFilmes()
        {
            return Ok(_context.Filmes.ToList<Filme>());
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarFilme), new { Id = filme.Id }, filme);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            return filme == null ? NotFound() : Ok(filme);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarFilme(int id, [FromBody] Filme novoFilme)
        {

            Filme filme = await _context.Filmes.FirstOrDefaultAsync(filme => filme.Id == id);

            if (filme == null) return NotFound();

            filme.Titulo = novoFilme.Titulo;
            filme.Descricao = novoFilme.Descricao;
            filme.Diretor = novoFilme.Diretor;
            filme.Duracao = novoFilme.Duracao;

            _context.SaveChanges();

            return Ok(filme);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarFilme(int id)
        {
            Filme filme = await _context.Filmes.FirstOrDefaultAsync<Filme>(filme => filme.Id == id);

            if (filme == null) return NotFound();

            _context.Filmes.Remove(filme);
            _context.SaveChanges();

            return Ok();

        }

    }
}
