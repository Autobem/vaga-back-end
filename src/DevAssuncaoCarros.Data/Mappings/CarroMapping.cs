using DevAssuncaoCarros.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevAssuncaoCarros.Data.Mappings
{
    public class CarroMapping : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {

            builder.Property(x => x.Fabricante)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.ModeloCarro)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(x => x.ModeloCarro)
                .IsRequired()
                .HasColumnType("varchar(30)");


            builder.Property(x => x.AnoModelo)
                .IsRequired()
                .HasColumnType("int")
                .HasMaxLength(5);


            builder.Property(x => x.Categoria)
                .IsRequired()
                .HasColumnType("varchar(100)");


            builder.Property(x => x.Cor)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("Carros");
        }
    }
}
