using Api.Domain.Interfaces;
using Api.InfraData.Context;
using Api.InfraData.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfraCrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependeceRepository(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddDbContext<Contexto>(
                o => o.UseSqlServer(configuration["ConnectionStrings:SqlServer"]));
        }
    }
}
