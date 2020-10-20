using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleRegistration.Infrastructure.CrossCutting.IOC;
using VehicleRegistration.Infrastructure.Data;

namespace VehicleRegistration.Presentation
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["SqlConnection:SqlConnectionString"];
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(connection));
            services.AddMemoryCache();
            //services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void ConfigureContainer(ContainerBuilder Builder)
        {
            Builder.RegisterModule(new ModuleIOC());
        }
    }
}
