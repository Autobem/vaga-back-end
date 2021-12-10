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

            //Configura��o do Swagger
            SwaggerSetup.ConfigureServices(services);

            //Configura��o do JWT
            JwtSetup.AddJwtSetup(services, Configuration);

            //Configura��o do CORS
            CorsSetup.ConfigureServices(services);

            //Configura��o do EntityFramework
            EntityFrameworkSetup.ConfigureServices(services, Configuration);

            //Configura��o de inje��o de depend�ncia
            DependencyInjectionSetup.ConfigureServices(services);

            //Configura��o do AutoMapper
            AutoMapperSetup.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Configura��o do Swagger
            SwaggerSetup.Configure(app);

            //Configura��o do CORS
            CorsSetup.Configure(app);

            app.UseRouting();

            //Configura��o do JWT
            JwtSetup.UseJwtSetup(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
