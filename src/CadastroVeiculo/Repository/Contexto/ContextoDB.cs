using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Repository.Map;

namespace Repository.Contexto
{
    public class ContextoDB : DbContext
    {
        public ContextoDB(DbContextOptions<ContextoDB> options) : base(options) { }
        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Proprietario>(new ProprietarioMap().Configure);
            modelBuilder.Entity<Veiculo>(new VeiculoMap().Configure);
        }
    }
}
