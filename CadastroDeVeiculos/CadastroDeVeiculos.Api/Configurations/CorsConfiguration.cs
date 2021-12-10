using Microsoft.Extensions.DependencyInjection;

namespace CadastroDeVeiculos.Api.Configurations
{
    public static class CorsConfiguration
    {
        public static IServiceCollection AddCorsConfigure(this IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy(name: "CorsPolicy", builder =>
                {
                    builder.WithOrigins("https://localhost:5001")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            return services;
        }
    }
}
