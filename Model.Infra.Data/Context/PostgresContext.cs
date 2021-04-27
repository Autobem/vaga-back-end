using Microsoft.EntityFrameworkCore;
using Model.Domain.Entities;


namespace Model.Infra.Data.Context
{
    public class PostgresContext: DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=ec2-54-235-108-217.compute-1.amazonaws.com;Port=5432;Pooling=true;DataBase=deic8p78klhgkc;User Id=fedkslqtphvzrc;password=ed3342ec14ea5f3f8c52f2ffe6746789b066640fa1c03e6f80b621495ddbab34;SSL Mode=Require;Trust Server Certificate=true");
    }
}
