using Microsoft.AspNetCore.Mvc;
using FilmesApi.Data.DTOs;
using FilmesApi.Data;
using FilmesApi.Models;
using AutoMapper;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {

        private OracleDbContext _context;
        private IMapper _mapper;

        public GerenteController(OracleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] AdicionarGerenteDTO gerenteDTO)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDTO);

            _context.Gerentes.Add(gerente);
            _context.SaveChanges();


            return Ok(gerente);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarGerente( int id)
        {

            Gerente gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);

            if (gerente == null) return NoContent();

            ReadGerenteDTO gerenteDTO = _mapper.Map<ReadGerenteDTO>(gerente);

            return Ok(gerenteDTO);
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            List<Gerente> gerentes = _context.Gerentes.ToList<Gerente>();

            return gerentes.Count == 0 ? NoContent() : Ok(gerentes);

        }

        [HttpPut("{id}")]
        public IActionResult EditarGerente(int id, [FromBody]EditarGerenteDTO gerenteDTO)
        {

            Gerente gerente = _context.Gerentes.FirstOrDefault<Gerente>(g => g.Id == id);

            if (gerente == null) return NoContent();

            _mapper.Map(gerenteDTO, gerente);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {

            Gerente? gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);

            if (gerente == null) return NoContent();

            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();

            return Ok();

        }


    }
}
