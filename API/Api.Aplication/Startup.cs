using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.InfraCrossCutting.DependencyInjection;
using Api.InfraCrossCutting.Mappings;
using InfraCrossCutting.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace application
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
            //configurando serviços
            ConfigureService.ConfigureDependeceService(services);

            //configurando dependencia repository
            ConfigureRepository.ConfigureDependeceRepository(services, Configuration);

            //preparando configuração mapper
            var config = new AutoMapper.MapperConfiguration(c => {
                c.AddProfile(new DTOParaModelProfile());
                c.AddProfile(new EntityParaDTOProfile());
                c.AddProfile(new ModelParaEntityProfile());
            });
            //adicionando no pipeline
            services.AddSingleton(config.CreateMapper());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Teste AutoBem", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste AutoBem v1");
                    c.RoutePrefix = string.Empty;
                });

                // Redireciona para swagger caso abra na principal
                var option = new RewriteOptions();
                option.AddRedirect("^$", "swagger");
                app.UseRewriter(option);
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
