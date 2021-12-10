using AutoMapper;
using CadastroDeVeiculos.Application.AutoMapper.ProfileConfiguration;
using CadastroDeVeiculos.Application.Interfaces;
using CadastroDeVeiculos.Application.Services;
using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Data.EntityFramework.Context;
using CadastroDeVeiculos.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroDeVeiculos.Ioc.DependencyConfiguration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(ProfileConfiguration));


            return services;
        }
    }
}
