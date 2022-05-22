using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOs
{
    public class UpdateCinemaDTO
    {
        [Required(ErrorMessage = "O campo 'Nome' deve ser preenchido")]
        public string Nome { get; set; }

    }
}
