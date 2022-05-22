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
        public IActionResult RecuperarTodos()
        {
            return Ok(_context.Cinemas.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault<Cinema>(cinema => cinema.Id == id);

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
