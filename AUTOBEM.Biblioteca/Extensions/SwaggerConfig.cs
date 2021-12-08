using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AUTOBEM.Biblioteca.Extensions
{
    public static class SwaggerConfig
    {
        public static void ConfigureSwaggerDoc(this IServiceCollection services, string description)
        {
            services.AddOpenApiDocument(config =>
            {
                config.Version = "v1";
                config.AllowReferencesWithProperties = true; //Habilita a geração de exemplos para propriedades aninhadas
                config.Title = "Documentação de API: " + Assembly.GetEntryAssembly().GetName().Name;
                config.Description = description;
            });
        }

        public static void ConfigureSwaggerUI(this IApplicationBuilder app)
        {
            // Ativa o middleware para veicular o Swagger gerado como um terminal JSON.
            app.UseOpenApi();

            // Registra o gerador Swagger e os middlewares Swagger UI
            app.UseSwaggerUi3(config => config.TransformToExternalPath = (internalUiRoute, request) =>
            {
                config.Path = "/swagger";
                return internalUiRoute.StartsWith("/") && internalUiRoute.StartsWith(request.PathBase) == false
                    ? request.PathBase + internalUiRoute
                    : internalUiRoute;
            });
        }
    }
}
