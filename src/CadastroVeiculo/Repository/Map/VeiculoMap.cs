using Domain.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repository.Map
{
    internal class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public VeiculoMap()
        {
            
        }
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculos");

            builder.HasKey(u => u.VeiculoId);

            builder.HasIndex(u => u.Renavam)
                   .IsUnique();

            builder.Property(u => u.Ano)
                .IsRequired();

            builder.Property(u => u.Cor)
                .IsRequired();

            builder.Property(c => c.Montadora)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(c => c.Modelo)
                .IsRequired()
                .HasMaxLength(60);
        }
    }
}
