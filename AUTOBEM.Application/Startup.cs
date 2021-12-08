using AUTOBEM.Application.Extensions;
using AUTOBEM.Application.Models;
using AUTOBEM.Domain.Entities;
using AUTOBEM.Domain.Interfaces;
using AUTOBEM.Infra.Data.Context;
using AUTOBEM.Infra.Data.Repository;
using AUTOBEM.Service.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Converters;

namespace AUTOBEM.Application
{
    public class Startup
    {
        private readonly string description = "** API para vaga back-end Autobem.";
        private readonly string version = "v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Habilita as ferramentas de instrumentação do OpenTracing
            services.ConfigureOpenTracing();

            services.AddControllers()
                                .AddNewtonsoftJson(jsonOptions =>
                                {
                                    jsonOptions.SerializerSettings.Converters.Add(new StringEnumConverter());
                                });

            services.AddDbContext<MySqlContext>(options =>
            {
                var server = Configuration["database:mysql:server"];
                var port = Configuration["database:mysql:port"];
                var database = Configuration["database:mysql:database"];
                var username = Configuration["database:mysql:username"];
                var password = Configuration["database:mysql:password"];

                options.UseMySql($"Server={server};Port={port};Database={database};Uid={username};Pwd={password}", opt =>
                {
                    opt.CommandTimeout(180);
                    opt.EnableRetryOnFailure(5);
                });
            });

            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            services.AddScoped<IBaseService<User>, BaseService<User>>();

            services.AddScoped<IBaseRepository<Vehicle>, BaseRepository<Vehicle>>();
            services.AddScoped<IBaseService<Vehicle>, BaseService<Vehicle>>();

            services.AddScoped<IBaseRepository<Owner>, BaseRepository<Owner>>();
            services.AddScoped<IBaseService<Owner>, BaseService<Owner>>();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<CreateUserModel, User>();
                config.CreateMap<UpdateUserModel, User>();
                config.CreateMap<User, UserModel>();

                config.CreateMap<CreateOwnerModel, Owner>();
                config.CreateMap<UpdateOwnerModel, Owner>();
                config.CreateMap<Owner, OwnerModel>();

                config.CreateMap<CreateVehicleModel, Vehicle>();
                config.CreateMap<UpdateVehicleModel, Vehicle>();
                config.CreateMap<Vehicle, VehicleModel>();
            }).CreateMapper());

            // Habilita o Swagger            
            services.ConfigureSwaggerDoc(description);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version, new OpenApiInfo { Title = description, Version = version });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", description));
            }

            app.ConfigureSwaggerUI();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
