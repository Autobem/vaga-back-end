using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.InfraData.Mapping
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
                builder.HasIndex(e => e.Ano)
                    .HasName("ID01_Veiculo");

                builder.HasIndex(e => e.Modelo)
                    .HasName("ID03_Veiculo");

                builder.HasIndex(e => e.Placa)
                    .HasName("ID02_Veiculo");

                builder.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                builder.Property(e => e.Ano).HasColumnName("ano");

                builder.Property(e => e.Atualizacao)
                    .HasColumnName("atualizacao")
                    .HasColumnType("datetime");

                builder.Property(e => e.Cambio)
                    .HasColumnName("cambio")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                builder.Property(e => e.Criacao)
                    .HasColumnName("criacao")
                    .HasColumnType("datetime");

                builder.Property(e => e.Km).HasColumnName("km");

                builder.Property(e => e.Modelo).HasColumnName("modelo");

                builder.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.PessoaId).HasColumnName("pessoaId");

                builder.Property(e => e.Placa)
                    .IsRequired()
                    .HasColumnName("placa")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                builder.Property(e => e.Portas).HasColumnName("portas");

                //Relacionamento
                builder.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Veiculo)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Veiculo_Pessoa");
        }
    }
}