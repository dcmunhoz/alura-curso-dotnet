using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOs
{
    public class UpdateEnderecoDTO
    {
        [Required(ErrorMessage = "O campo 'Logradouro' deve ser informado.")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "O campo 'Bairro' deve ser informado.")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "O campo 'Numero' deve ser informado.")]
        public string Numero { get; set; }
    }
}
