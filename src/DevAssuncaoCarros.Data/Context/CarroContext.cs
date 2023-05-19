﻿using DevAssuncaoCarros.Business.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevAssuncaoCarros.Data.Context
{
    public class CarroContext : IdentityDbContext
    {
        public CarroContext(DbContextOptions<CarroContext> options) : base(options) { }

        public DbSet<Endereco>? Enderecos { get; set; }
        public DbSet<Proprietario>? Proprietarios { get; set;}
        public DbSet<Carro>? Carros { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarroContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

