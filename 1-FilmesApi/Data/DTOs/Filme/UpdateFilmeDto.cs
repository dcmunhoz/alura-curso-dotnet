using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmesApi.Data.DTOs
{
    public class UpdateFilmeDto
    {
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
