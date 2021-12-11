using CadastroDeVeiculos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDeVeiculos.Data.EntityFramework.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id).HasName("Pk_User");

            builder.HasIndex(u => u.LoginData).IsUnique();
            builder.Property(u => u.LoginData).HasColumnType("varchar(20)")
                .HasColumnName("User_Login").IsRequired();

            builder.Property(u => u.Password).HasColumnType("varchar(12)").IsUnicode()
                .HasColumnName("User_Password").IsRequired();

            builder.Property(u => u.Email).HasColumnType("varchar(100)").IsUnicode()
                .HasColumnName("User_Email").IsRequired();

            builder.Property(u => u.Role).HasColumnName("User_Role")
                .IsRequired();

        }
    }
}
