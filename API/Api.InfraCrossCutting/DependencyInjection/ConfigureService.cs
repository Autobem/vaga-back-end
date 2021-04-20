using Api.Domain.Interfaces.Services;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.InfraCrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependeceService(IServiceCollection services)
        {
            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<IVeiculoService, VeiculoService>();
        }
    }
}