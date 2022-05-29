using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOs
{
    public class AdicionarGerenteDTO
    {

        [Required(ErrorMessage = "Campo 'Nome' precisa ser informado!")]
        public string Nome { get; set; }

    }
}
