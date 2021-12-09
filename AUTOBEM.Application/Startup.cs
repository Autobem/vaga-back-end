using AUTOBEM.Application.Extensions;
using AUTOBEM.Application.Models;
using AUTOBEM.Biblioteca.Extensions;
using AUTOBEM.Domain.Entities;
using AUTOBEM.Domain.Interfaces;
using AUTOBEM.Infra.Data.Context;
using AUTOBEM.Infra.Data.Repository;
using AUTOBEM.Service.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using System.Text;

namespace AUTOBEM.Application
{
    public class Startup
    {
        private readonly string description = "** API para vaga back-end Autobem. Desenvolvida com .NET CORE 5, Swagger, MySQL, OAuth 2 com geração de Authorization Token, link para teste: https://localhost:5001/v1/account/anonimo, https://localhost:5001/v1/account/autenticado, https://localhost:5001/v1/account/empregado, https://localhost:5001/v1/account/gerente, https://localhost:5001/api/Owner / Postman JSon Incluído na Solução.";
        private readonly string version = "v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureOpenTracing();
            services.AddMvc();
            services.AddCors();

            services.AddControllers()
                .AddNewtonsoftJson(jsonOptions =>
                {
                    jsonOptions.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            byte[] key = Encoding.ASCII.GetBytes(Settings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
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

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
