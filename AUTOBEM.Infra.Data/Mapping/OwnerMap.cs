using AUTOBEM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUTOBEM.Infra.Data.Mapping
{
    public class OwnerMap : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owner");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.DataNascimento)
               .HasConversion(prop => prop, prop => prop)
               .IsRequired()
               .HasColumnName("DataNascimento")
               .HasColumnType("datetime");

            builder.Property(prop => prop.Habilitacao)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Habilitacao")
                .HasColumnType("varchar(15)");

            builder.Property(prop => prop.Rg)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Rg")
                .HasColumnType("varchar(15)");
        }
    }
}
