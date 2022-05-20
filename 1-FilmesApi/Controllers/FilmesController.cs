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
        public List<Filme> ListaFilmes()
        {
            return filmes;
        }

        [HttpPost]
        public Filme AdicionarFilme([FromBody] Filme filme)
        {
            count++;
            filme.Id = count; 
            filmes.Add(filme);

            return filme;

        }

        [HttpGet("{id}")]
        public Filme BuscarFilme(int id)
        {
            return filmes.FirstOrDefault(filme => filme.Id == id);
        }

    }
}
