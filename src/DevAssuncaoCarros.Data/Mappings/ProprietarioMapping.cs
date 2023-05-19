using DevAssuncaoCarros.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DevAssuncaoCarros.Data.Mappings
{
    public class ProprietarioMapping : IEntityTypeConfiguration<Proprietario>
    {
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(x => x.CNH)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.HasOne(x => x.Endereco)
                .WithOne(x => x.Proprietario)
                .HasForeignKey<Endereco>(x => x.ProprietarioId);


            builder.HasMany(x => x.Carros)
                .WithOne(x => x.Proprietario)
                .HasForeignKey(x => x.ProprietarioId);

            builder.ToTable("Proprietarios");
        }
    }
}
