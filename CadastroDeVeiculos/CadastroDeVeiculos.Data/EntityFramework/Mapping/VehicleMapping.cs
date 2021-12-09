using CadastroDeVeiculos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDeVeiculos.Data.EntityFramework.Mapping
{
    public class VehicleMapping : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");
            builder.HasKey(v => v.Id).HasName("Pk_Vehicle");

            builder.Property(v => v.ModelName).HasColumnType("varchar(50)").IsUnicode()
                .HasColumnName("Vehicle_Model").IsRequired();

            builder.Property(v => v.Manufacturer).HasColumnType("varchar(70)").IsUnicode()
                .HasColumnName("Vehicle_Manufacture").IsRequired();
            
            builder.Property(v => v.PlateTheVehicle).HasColumnType("varchar(7)").IsUnicode()
                .HasColumnName("Vehicle_Plate").IsRequired();

            builder.Property(v => v.YearOfManufacturer).HasColumnName("Vehicle_Year")
                .HasMaxLength(4).IsRequired();



            builder.HasOne(v => v.Client).WithMany(c => c.Vehicles).HasForeignKey(v => v.ClientId);

        }
    }
}
