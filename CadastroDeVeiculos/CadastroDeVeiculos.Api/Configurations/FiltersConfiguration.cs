using CadastroDeVeiculos.Api.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroDeVeiculos.Api.Configurations
{
    public static class FiltersConfiguration
    {
        public static IServiceCollection AddFilters(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.AddService<ErrorFilterAttribute>();
            });

            return services;
        }
    }
}
