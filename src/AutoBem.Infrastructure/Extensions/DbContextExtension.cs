using BuildingBlocks.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AutoBem.Infrastructure.Extensions
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<IDbContext, CoreDbContext>(options =>
                 options.UseSqlServer(connectionString, b => b.MigrationsAssembly("AutoBem.WebApi")));
        }


        public static IServiceCollection AddDbContextMemory(this IServiceCollection services)
        {
            return services.AddDbContext<IDbContext, CoreDbContext>(options =>
            options.UseInMemoryDatabase("TestDB"));
        }
    }
}
