using Autofac;
using AutoMapper;
using Teste.Application;
using Teste.Application.Configuration;
using Teste.Application.Interfaces;
using Teste.Domain.Core.Interfaces.Repositories;
using Teste.Domain.Core.Interfaces.Services;
using Teste.Domain.Services;
using Teste.Infrastructure.Data.Repositories;

namespace Teste.Infrastructure.CrossCutting.IoC
{
    public class ConfigurationIoC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IoC

            builder.RegisterType<ProprietarioApplicationService>().As<IProprietarioApplicationService>();
            builder.RegisterType<VeiculoApplicationService>().As<IVeiculoApplicationService>();

            builder.RegisterType<ProprietarioService>().As<IProprietarioService>();
            builder.RegisterType<VeiculoService>().As<IVeiculoService>();

            builder.RegisterType<VeiculoRepository>().As<IVeiculoRepository>();
            builder.RegisterType<ProprietarioRepository>().As<IProprietarioRepository>();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfig());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            #endregion
        }
    }
}
