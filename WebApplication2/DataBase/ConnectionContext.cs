using Cars.Domain.Model.PersonAggregate;
using Microsoft.EntityFrameworkCore;

namespace Car.DataBase
{
    public class ConnectionContext: DbContext
    {
        public DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=cars;" +
                "User Id=postgres;" +
                "Password=postgres;")
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}
