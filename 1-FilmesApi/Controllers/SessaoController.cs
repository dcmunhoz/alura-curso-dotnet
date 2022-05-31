using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;
using FilmesApi.Data;
using FilmesApi.Data.DTOs;
using AutoMapper;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private OracleDbContext _context;
        private IMapper _mapper;

        public SessaoController(OracleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDTO Dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(Dto);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return Ok(sessao);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarSessao(int id)
        {
            Sessao? sessao = _context.Sessoes.FirstOrDefault(s => s.Id == id);

            if (sessao == null) return NoContent();

            ReadSessaoDTO dto = _mapper.Map<ReadSessaoDTO>(sessao);

            return Ok(dto);
        }


    }
}
