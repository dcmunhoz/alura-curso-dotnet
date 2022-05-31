using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FilmesApi.Data;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {

        private OracleDbContext _context;
        private IMapper _mapper;

        public CinemaController(IMapper mapper, OracleDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult NovoCinema([FromBody] CreateCinemaDTO cinemaDto)
        {

            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarCinema), new { Id = cinema.Id }, cinema);

        }

        [HttpGet]
        public IActionResult RecuperarTodos([FromQuery] string? filme)
        {

            List<Cinema> cinemas = _context.Cinemas.ToList();

            if (!String.IsNullOrEmpty(filme))
            {
                var quey = from cinema in cinemas
                           where cinema.Sessoes.All(c => c.Filme.Descricao == filme)
                           select cinema;

                cinemas = quey.ToList();
            }

            if (cinemas == null)
            {
                return NoContent();
            }

            List<ReadCinemaDTO> dto = _mapper.Map<List<ReadCinemaDTO>>(cinemas);

            return Ok(dto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault<Cinema>(cinema => cinema.Id == id);

            ////Utilizando Join
            //Cinema cinema = new Cinema();
            //var quey = from c in _context.Cinemas
            //                join e in _context.Enderecos on c.EnderecoId equals e.Id
            //                where c.Id == id
            //                select new Cinema()
            //                {
            //                    Id = c.Id,
            //                    Nome = c.Nome,
            //                    Endereco = e,
            //                    EnderecoId = e.Id
            //                };

            //foreach ( Cinema c in quey )
            //{
            //    cinema = c;
            //}

            if (cinema == null) return NotFound();

            var cinemaDto = _mapper.Map<ReadCinemaDTO>(cinema);

            return Ok(cinemaDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDTO cinemaDto)
        {

            Cinema cinema = _context.Cinemas.FirstOrDefault<Cinema>(cinema => cinema.Id == id);

            if (cinema == null) return NotFound();

            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();

            return Ok(cinema);

        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {

            Cinema cinema = _context.Cinemas.FirstOrDefault<Cinema>(cinema => cinema.Id == id);

            if (cinema == null) return NotFound();

            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();

            return Ok();

        }
    }
}
