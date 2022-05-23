using Microsoft.EntityFrameworkCore;
using FilmesApi.Models;

namespace FilmesApi.Data
{
    public class OracleDbContext : DbContext
    {

        public OracleDbContext(DbContextOptions opt) : base(opt) { }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

    }
}
