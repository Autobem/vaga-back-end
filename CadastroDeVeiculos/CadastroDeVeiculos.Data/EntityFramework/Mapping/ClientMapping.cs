using CadastroDeVeiculos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDeVeiculos.Data.EntityFramework.Mapping
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c => c.Id).HasName("Pk_Client");

            builder.Property(c => c.PhoneNumber).HasColumnType("varchar(11)").IsUnicode()
                .HasColumnName("Client_Phone").IsRequired();

            builder.Property(c => c.Email).HasColumnType("varchar(150)").IsUnicode()
                .HasColumnName("Client_Email").IsRequired();

            builder.HasIndex(c => c.Document).IsUnique();
            builder.Property(c => c.Document).HasColumnType("varchar(11)").IsUnicode()
                .HasColumnName("Client_Document").IsRequired();

            //Config value Object

            builder.OwnsOne(c => c.Name, config =>
            {
                config.Property(n => n.FirstName).HasColumnType("varchar(80)").IsUnicode()
                .HasColumnName("First_Name").IsRequired();

                config.Property(n => n.Lastname).HasColumnType("varchar(80)").IsUnicode()
                .HasColumnName("Lastname").IsRequired();
            });
                
        }
    }
}
