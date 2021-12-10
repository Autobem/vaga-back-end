using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Aggregates.Veiculos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder) 
        {
            builder.ToTable("Veiculo");

            builder.HasKey(p => p.IdVeiculo);

            builder.Property(p => p.IdVeiculo)
                .HasColumnName("IdVeiculo");

            builder.Property(p => p.IdProprietario)
              .HasColumnName("IdProprietario")
              .IsRequired();

            builder.Property(p => p.Renavam)
               .HasColumnName("Renavam")
               .HasMaxLength(15)
               .IsRequired();

            builder.Property(p => p.Placa)
               .HasColumnName("Placa")
               .HasMaxLength(10)
               .IsRequired();

            builder.Property(p => p.Ano)
              .HasColumnName("Ano")
              .HasMaxLength(4)
              .IsRequired();

            builder.Property(p => p.Modelo)
             .HasColumnName("Modelo")
             .HasMaxLength(50)
             .IsRequired();

            builder.Property(p => p.Tipo)
            .HasColumnName("Tipo")
            .HasMaxLength(30)
            .IsRequired();

            #region Mapeamento de Relacionamentos

            builder.HasOne(p => p.Proprietario)
                .WithMany(c => c.Veiculos)
                .HasForeignKey(p => p.IdProprietario);          

            #endregion
        }
    }
}
