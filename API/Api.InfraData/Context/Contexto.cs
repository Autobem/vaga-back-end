using Api.Domain.Entities;
using Api.InfraData.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Api.InfraData.Context
{
    public class Contexto : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        public Contexto(DbContextOptions<Contexto> options):base (options) {}
        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pessoa>(new PessoaMap().Configure);
            modelBuilder.Entity<Veiculo>(new VeiculoMap().Configure);
        }
    }
}