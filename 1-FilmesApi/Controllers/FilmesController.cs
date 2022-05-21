using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;
using FilmesApi.Data;
using FilmesApi.Data.DTOs;

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
            List<ReadFilmeDto> filmesDto = new();

            var filmes = _context.Filmes.ToList<Filme>();

            foreach (Filme filme in filmes)
            {
                filmesDto.Add( new ReadFilmeDto()
                {
                    Titulo = filme.Titulo,
                    Descricao = filme.Descricao,
                    Diretor = filme.Diretor,
                    Duracao = filme.Duracao,
                    DataConsulta = DateTime.Now
                });
            }

            return Ok(filmesDto);
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = new()
            {
               Titulo = filmeDto.Titulo,
               Descricao = filmeDto.Descricao,
               Diretor = filmeDto.Diretor,
               Duracao = filmeDto.Duracao,  
            };

            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarFilme), new { Id = filme.Id }, filme);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null) return NotFound(); 

            ReadFilmeDto filmeDto = new ReadFilmeDto()
            {
                Titulo = filme.Titulo,
                Descricao = filme.Descricao,
                Diretor = filme.Diretor,
                Duracao = filme.Duracao,
                DataConsulta = DateTime.Now
            };

            return Ok(filmeDto);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarFilme(int id, [FromBody] UpdateFilmeDto novoFilme)
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
