using AutoMapper;
using CadastroDeVeiculos.Application.AutoMapper.ProfileConfiguration;
using CadastroDeVeiculos.Application.Interfaces;
using CadastroDeVeiculos.Application.Services;
using CadastroDeVeiculos.Business.Interfaces.NotificationHandler;
using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Business.NotificationHandlers;
using CadastroDeVeiculos.Data.EntityFramework.Context;
using CadastroDeVeiculos.Data.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CadastroDeVeiculos.Ioc.DependencyConfiguration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Context
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //Mediator
            var handlersApplication = AppDomain.CurrentDomain.Load("CadastroDeVeiculos.Application");
            services.AddMediatR(handlersApplication);

            //Notification
            services.AddScoped<INotificationContext, INotificationContext>();

            //Repository
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            //Service
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(ProfileObjectToDTO));



            return services;
        }
    }
}
