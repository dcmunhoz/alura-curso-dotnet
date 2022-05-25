using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOs
{
    public class CreateCinemaDTO
    {
        [Required(ErrorMessage = "O campo 'Nome' deve ser preenchido.")]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
    }
}
