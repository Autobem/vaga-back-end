using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Map
{
    public class ProprietarioMap : IEntityTypeConfiguration<Proprietario>
    {
        public ProprietarioMap()
        {
            
        }
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            builder.ToTable("Proprietarios");

            builder.HasKey(u => u.ProprietarioId);

            builder.HasIndex(u => u.Documento)
                   .IsUnique();

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(u => u.DataNascimento)
                .IsRequired();
         
            builder.Property(c => c.TipoDocumento)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(c => c.Documento)
                .IsRequired()
                .HasMaxLength(60);

            builder.HasMany(x => x.Veiculos).WithOne(x => x.Proprietario).HasForeignKey(x => x.ProprietarioId);

        }
    }
}