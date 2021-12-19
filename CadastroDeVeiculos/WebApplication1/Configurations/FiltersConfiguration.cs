using CadastroDeVeiculos.WebApi.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroDeVeiculos.WebApi.Configurations
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
