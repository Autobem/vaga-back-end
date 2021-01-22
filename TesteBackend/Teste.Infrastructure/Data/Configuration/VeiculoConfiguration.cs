using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Domain.Entities;

namespace Teste.Infrastructure.Data.Configuration
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Marca).HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Modelo).HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Cor).HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.HasOne<Proprietario>(v => v.Proprietario).WithMany(p => p.Veiculos).HasForeignKey(v => v.ProprietarioId);
        }
    }
}
