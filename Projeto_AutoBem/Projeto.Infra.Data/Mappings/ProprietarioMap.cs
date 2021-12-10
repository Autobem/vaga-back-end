using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Aggregates.Veiculos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class ProprietarioMap : IEntityTypeConfiguration<Proprietario>
    {
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            builder.ToTable("Proprietario");

            builder.HasKey(c => c.IdProprietario);

            builder.Property(c => c.IdProprietario)
                .HasColumnName("IdProprietario");

            builder.Property(c => c.CPF)
                .HasColumnName("CPF")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(c => c.Nome)
              .HasColumnName("Nome")
              .HasMaxLength(100)
              .IsRequired();
        }
    }
}
