using Microsoft.Extensions.DependencyInjection;
using Projeto.Application.Contracts;
using Projeto.Application.Services;
using Projeto.CrossCutting.Cryptography;
using Projeto.Domain.Aggregates.Usuarios.Contracts.Repositories;
using Projeto.Domain.Aggregates.Usuarios.Contracts.Services;
using Projeto.Domain.Aggregates.Usuarios.CrossCutting;
using Projeto.Domain.Aggregates.Usuarios.Services;
using Projeto.Domain.Aggregates.Veiculos.Contracts.Repositories;
using Projeto.Domain.Aggregates.Veiculos.Contracts.Services;
using Projeto.Domain.Aggregates.Veiculos.Services;
using Projeto.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            #region Application

            services.AddTransient<IProprietarioApplicationService, ProprietarioApplicationService>();
            services.AddTransient<IVeiculoApplicationService, VeiculoApplicationService>();
            services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();          

            #endregion

            #region Domain

            services.AddTransient<IProprietarioDomainService, ProprietarioDomainService>();
            services.AddTransient<IVeiculoDomainService, VeiculoDomainService>();           
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();

            #endregion

            #region InfraStructure

            services.AddTransient<IProprietarioRepository, ProprietarioRepository>();
            services.AddTransient<IVeiculoRepository, VeiculoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IMD5Cryptography, MD5Cryptography>();

            #endregion
        }
    }
}
