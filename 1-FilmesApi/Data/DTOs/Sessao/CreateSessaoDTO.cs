namespace FilmesApi.Data.DTOs
{
    public class CreateSessaoDTO
    {
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
        public DateTime HoraDeEncerramento { get; set; }
    }
}
