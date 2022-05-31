using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;
using FilmesApi.Data;
using FilmesApi.Data.DTOs;
using AutoMapper;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController: ControllerBase
    {

        public static List<Filme> filmes = new();
        public static int count = 0;

        private OracleDbContext _context;
        private IMapper _mapper;

        public FilmesController(OracleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListaFilmes([FromQuery] int? duracao = null)
        {
            List<ReadFilmeDto> filmesDto = new();

            var filmes = _context.Filmes.ToList<Filme>();

            if (duracao != null)
            {
                filmes = filmes.Where(f => f.Duracao <= duracao).ToList();
            }

            foreach (Filme filme in filmes)
            {
                filmesDto.Add( _mapper.Map<ReadFilmeDto>(filme));
            }

            return Ok(filmesDto);
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarFilme), new { Id = filme.Id }, filme);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null) return NotFound(); 

            ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);

            return Ok(filmeDto);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarFilme(int id, [FromBody] UpdateFilmeDto novoFilme)
        {

            Filme filme = await _context.Filmes.FirstOrDefaultAsync(filme => filme.Id == id);

            if (filme == null) return NotFound();

            _mapper.Map(novoFilme, filme);
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
