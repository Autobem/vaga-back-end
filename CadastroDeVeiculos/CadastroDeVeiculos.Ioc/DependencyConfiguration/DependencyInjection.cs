using AutoMapper;
using CadastroDeVeiculos.Application.AutoMapper.ProfileConfiguration;
using CadastroDeVeiculos.Application.Interfaces;
using CadastroDeVeiculos.Application.Services;
using CadastroDeVeiculos.Business.Interfaces.Account;
using CadastroDeVeiculos.Business.Interfaces.NotificationHandler;
using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Business.NotificationHandlers;
using CadastroDeVeiculos.Data.EntityFramework.Context;
using CadastroDeVeiculos.Data.Identity;
using CadastroDeVeiculos.Data.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;
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

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ApplicationDbContext>();



            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config => config.AccessDeniedPath = "/Account/Login");
            


            var handlersApplication = AppDomain.CurrentDomain.Load("CadastroDeVeiculos.Application");
            services.AddMediatR(handlersApplication);


            services.AddScoped<INotificationContext, NotificationContext>();


            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();


            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IVehicleService, VehicleService>();


            services.AddAutoMapper(typeof(ProfileObjectToDTO));
            services.AddAutoMapper(typeof(ProfileDTOToCommand));



            return services;
        }
    }
}
