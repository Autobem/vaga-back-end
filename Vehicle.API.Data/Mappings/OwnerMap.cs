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
    public class OwnerMap : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owners");

            builder.HasKey(p => p.Id);            

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(u => u.CpfCnpj)
                .IsRequired()
                .HasMaxLength(18);
        }       
    }
}
