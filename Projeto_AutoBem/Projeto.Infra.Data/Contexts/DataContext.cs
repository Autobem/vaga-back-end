using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Aggregates.Usuarios.Models;
using Projeto.Domain.Aggregates.Veiculos.Models;
using Projeto.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Contexts
{
    //REGRA 1) HERDAR DbContext
    public class DataContext : DbContext
    {
        //REGRA 2) Construtor para injeção de dependência
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        //REGRA 3) Declarar um DbSet para cada entidade mapeada
        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProprietarioMap());
            modelBuilder.ApplyConfiguration(new VeiculoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());


            modelBuilder.Entity<Proprietario>(entity =>
            {
                entity.HasIndex(f => f.CPF).IsUnique();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(u => u.Email).IsUnique();
            });
        }
    }
}
