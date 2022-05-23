using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {

        private OracleDbContext _context;
        private IMapper _mapper;

        public EnderecoController(OracleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult AdicionarNovo([FromBody] CreateEnderecoDTO enderecoDTO)
        {

            Endereco endereco = _mapper.Map<Endereco>(enderecoDTO);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RetornarEndereco), new { Id = endereco.Id }, endereco);

        }

        [HttpGet("{id}")]
        public IActionResult RetornarEndereco(int id)
        {

            Endereco endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

            if (endereco == null) return NotFound();

            ReadEnderecoDTO enderecoDTO = _mapper.Map<ReadEnderecoDTO>(endereco);

            return Ok(enderecoDTO);

        }

        [HttpGet]
        public IActionResult RetornarTodos()
        {
            return Ok(_context.Enderecos.ToList());
        }

        [HttpPut("{id}")]
        public IActionResult AlterarEndereco(int id, [FromBody] UpdateEnderecoDTO enderecoNovo)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

            if (endereco == null) return NotFound();

            _mapper.Map(enderecoNovo, endereco);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

            if (endereco == null) return NotFound();

            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();

            return Ok();
        }

    }
}
