using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.InfraData.Mapping
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
                builder.HasIndex(e => e.Documento)
                    .HasName("ID01_Pessoa");

                builder.Property(e => e.Id).HasColumnName("id");

                builder.Property(e => e.Atualizacao)
                    .HasColumnName("atualizacao")
                    .HasColumnType("datetime");

                builder.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.Criacao)
                    .HasColumnName("criacao")
                    .HasColumnType("datetime");

                builder.Property(e => e.Documento)
                    .IsRequired()
                    .HasColumnName("documento")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                builder.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                builder.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnName("uf")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
        }
    }
}