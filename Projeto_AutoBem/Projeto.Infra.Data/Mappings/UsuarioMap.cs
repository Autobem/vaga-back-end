using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Aggregates.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(u => u.IdUsuario);

            builder.Property(u => u.IdUsuario)
                .HasColumnName("IdUsuario");

            builder.Property(u => u.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("Email")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasColumnName("Senha")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.DataCriacao)
                .HasColumnName("DataCriacao")
                .IsRequired();
        }
    }
}
