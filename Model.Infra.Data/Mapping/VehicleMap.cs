using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Infra.Data.Mapping
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicle");

            builder.HasKey(prop => prop.Id);

            builder.HasIndex(prop => prop.OwnerId);

            builder.Property(prop => prop.Plate)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Plate")
                .HasColumnType("varchar(7)");

            builder.Property(prop => prop.UF)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("UF")
                .HasColumnType("varchar(2)");

            builder.Property(prop => prop.City)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("City")
                .HasColumnType("varchar(60)");

            builder.Property(prop => prop.Brand)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Brand")
                .HasColumnType("varchar(60)");

            builder.Property(prop => prop.Color)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("Color")
               .HasColumnType("varchar(60)");

            builder.Property(prop => prop.FabricationYear)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("FabricationYear")
               .HasColumnType("varchar(4)");

            builder.Property(prop => prop.OwnerId)
               .IsRequired()
               .HasColumnName("OwnerId")
               .HasColumnType("int");

            builder.HasOne("Model.Domain.Entities.Owner", "Owners")
                .WithMany()
                .HasForeignKey("OwnerId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
