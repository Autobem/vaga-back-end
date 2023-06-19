using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Repository.Repositorios;

namespace CrossCutting.DI
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProprietarioRepository, ProprietarioRepository>();
            serviceCollection.AddScoped<IVeiculoRepository, VeiculoRepository>();
        }
    }
}
