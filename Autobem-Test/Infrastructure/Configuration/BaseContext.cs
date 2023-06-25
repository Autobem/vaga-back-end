using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration;

public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Owner> Owners { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
            base.OnConfiguring(optionsBuilder);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>()
            .HasKey(v => v.Id);
        modelBuilder.Entity<Vehicle>()
            .HasOne(o => o.Owner)
            .WithMany(o => o.Vehicles)
            .HasForeignKey(o => o.OwnerId);
        modelBuilder.Entity<User>()
            .Property(u => u.Status)
            .HasConversion<string>();
    }

    public string GetConnectionString()
    {
        return "Data Source=DESKTOP-3AH0O3V;Initial Catalog=AutobemDB;Integrated Security=False;User ID=thyerry;Password=1234;Connection Timeout=15;Encrypt=False;TrustServerCertificate=False";
    }
}