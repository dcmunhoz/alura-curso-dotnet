using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Filme
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        [Required]
        public string Diretor { get; set; }
        [Required]
        [Range(1, 999)]
        public int Duracao { get; set; }


    }
}
