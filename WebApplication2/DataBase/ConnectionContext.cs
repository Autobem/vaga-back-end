using Car.Domain.Model.CarAggregate;
using Car.Domain.Model.PersonAggregate;
using Microsoft.EntityFrameworkCore;


namespace Car.DataBase
{
    public class ConnectionContext: DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Vehicle> Car { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=auto_bem;" +
                "User Id=postgres;" +
                "Password=postgres;")
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}
