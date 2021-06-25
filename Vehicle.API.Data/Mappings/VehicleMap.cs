using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.API.Domain.Entities;

namespace Vehicles.API.Data.Mappings
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");

            builder.HasKey(p => p.Id);

            builder.Property(u => u.Model)
                .IsRequired()
                .HasMaxLength(60);

            builder.HasIndex(p => p.Plate)
                .IsUnique();

            builder.Property(u => u.Plate)
                .IsRequired()
                .HasMaxLength(7);            
        }
    }
}
