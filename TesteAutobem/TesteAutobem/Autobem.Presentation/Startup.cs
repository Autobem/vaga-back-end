using Autobem.Application;
using Autobem.Application.DTO;
using Autobem.Application.Interfaces;
using Autobem.Domain.Entities;
using Autobem.Domain.Interfaces.Repositories;
using Autobem.Domain.Interfaces.Services;
using Autobem.Domain.Services;
using Autobem.Infra.Data.Context;
using Autobem.Infra.Data.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autobem.Presentation
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
            services.AddControllers();

            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddTransient(typeof(IBaseServiceApp<>), typeof(BaseServiceApp<>));

            services.AddTransient<ICorRepository, CorRepository>();
            services.AddTransient<ICorService, CorService>();
            services.AddTransient<ICorServiceApp, CorServiceApp>();

            services.AddTransient<IProprietarioRepository, ProprietarioRepository>();
            services.AddTransient<IProprietarioService, ProprietarioService>();
            services.AddTransient<IProprietarioServiceApp, ProprietarioServiceApp>();

            services.AddTransient<IVeiculoRepository, VeiculoRepository>();
            services.AddTransient<IVeiculoService, VeiculoService>();
            services.AddTransient<IVeiculoServiceApp, VeiculoServiceApp>();

            var connectionString = Configuration.GetConnectionString("AutobemConnection");

            services.AddDbContext<AutobemContext>(options => options.UseSqlServer(connectionString));

            AutoMapperConfig(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AutoMapperConfig(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CorDTO, Cor>();
                cfg.CreateMap<Cor, CorDTO>();

                cfg.CreateMap<ProprietarioDTO, Proprietario>();
                cfg.CreateMap<Proprietario, ProprietarioDTO>();

                cfg.CreateMap<VeiculoDTO, Veiculo>();
                cfg.CreateMap<Veiculo, VeiculoDTO>();
            });
        }
    }
}
