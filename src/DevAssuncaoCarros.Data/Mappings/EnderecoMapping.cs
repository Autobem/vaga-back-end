using DevAssuncaoCarros.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevAssuncaoCarros.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Numero)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(x => x.Cep)
                .IsRequired()
                .HasColumnType("varchar(8)");


            builder.Property(x => x.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");


            builder.Property(x => x.Cidade)
                .IsRequired()
                .HasColumnType("varchar(100)");


            builder.Property(x => x.Estado)
                .IsRequired()
                .HasColumnType("varchar(100)");


            builder.Property(x => x.UF)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.ToTable("Enderecos");

        }
    }
}
