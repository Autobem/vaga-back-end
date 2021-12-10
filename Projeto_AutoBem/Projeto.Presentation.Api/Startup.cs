using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Projeto.Presentation.Api.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore 
);

            //Configuração do Swagger
            SwaggerSetup.ConfigureServices(services);

            //Configuração do JWT
            JwtSetup.AddJwtSetup(services, Configuration);

            //Configuração do CORS
            CorsSetup.ConfigureServices(services);

            //Configuração do EntityFramework
            EntityFrameworkSetup.ConfigureServices(services, Configuration);

            //Configuração de injeção de dependência
            DependencyInjectionSetup.ConfigureServices(services);

            //Configuração do AutoMapper
            AutoMapperSetup.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Configuração do Swagger
            SwaggerSetup.Configure(app);

            //Configuração do CORS
            CorsSetup.Configure(app);

            app.UseRouting();

            //Configuração do JWT
            JwtSetup.UseJwtSetup(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
