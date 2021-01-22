using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Domain.Entities;

namespace Teste.Infrastructure.Data.Configuration
{
    public class ProprietarioConfiguration : IEntityTypeConfiguration<Proprietario>
    {
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            builder.ToTable("Proprietarios");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NomeCompleto).HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Cpf).HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.DataNascimento).IsRequired();
        }
    }
}
