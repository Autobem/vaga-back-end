using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api.Configurations
{
    public static class CorsSetup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(s => s.AddPolicy("DefaultPolicy",
               builder => {
                   builder.AllowAnyOrigin()    //qualquer cliente pode acessar a API
                          .AllowAnyMethod()    //qualquer método POST, PUT, DELETE, GET
                          .AllowAnyHeader();   //qualquer cabeçalho <HEAD>
               }));
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseCors("DefaultPolicy");
        }
    }
}
