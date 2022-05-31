using FilmesApi.Models;

namespace FilmesApi.Data.DTOs
{
    public class ReadCinemaDTO 
    {
        
       public string Nome { get; set; }
       public Endereco Endereco { get; set; }
       public Gerente Gerente { get; set; }
       public List<Sessao> Sessoes { get; set; }

    }
}
