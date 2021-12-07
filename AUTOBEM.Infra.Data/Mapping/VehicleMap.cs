using AUTOBEM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUTOBEM.Infra.Data.Mapping
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicle");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Marca)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Marca")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Modelo)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("Modelo")
               .HasColumnType("varchar(100)");

            builder.Property(prop => prop.AnoFabricacao)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("AnoFabricacao")
                .HasColumnType("varchar(4)");

            builder.Property(prop => prop.Cor)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Cor")
                .HasColumnType("varchar(15)");
        }
    }
}
