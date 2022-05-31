using FilmesApi.Models;

namespace FilmesApi.Data.DTOs
{
    public class ReadSessaoDTO
    {
        public int Id { get; set; }
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
        public DateTime HoraDeEncerramento { get; set; }
        public DateTime HoraDeInicio { get; set; }

    }
}
