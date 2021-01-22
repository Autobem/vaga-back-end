using Microsoft.EntityFrameworkCore;
using Teste.Domain.Entities;

namespace Teste.Infrastructure.Data.Context
{
    public class TesteBackendContext : DbContext
    {
        public TesteBackendContext()
        {

        }

        public TesteBackendContext(DbContextOptions<TesteBackendContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TesteBackendContext).Assembly);
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Proprietario> Proprietarios { get; set; }
    }
}
