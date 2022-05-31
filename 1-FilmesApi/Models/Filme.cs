using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FilmesApi.Models
{
    [Table("FILMES")]
    public class Filme
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("TITULO")]
        public string Titulo { get; set; }
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
        [Required]
        [Column("DIRETOR")]
        public string Diretor { get; set; }
        [Required]
        [Range(1, 999)]
        [Column("DURACAO")]
        public int Duracao { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }


    }
}
