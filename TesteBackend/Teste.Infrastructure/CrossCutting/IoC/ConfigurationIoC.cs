using Autofac;
using AutoMapper;
using Teste.Application;
using Teste.Application.Configuration;
using Teste.Application.Interfaces;
using Teste.Domain.Core.Interfaces.Repositories;
using Teste.Domain.Core.Interfaces.Services;
using Teste.Domain.Services;
using Teste.Domain.Services.Notifications;
using Teste.Infrastructure.Data.Repositories;

namespace Teste.Infrastructure.CrossCutting.IoC
{
    public class ConfigurationIoC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IoC

            builder.RegisterType<ProprietarioApplicationService>().As<IProprietarioApplicationService>().InstancePerLifetimeScope(); ;
            builder.RegisterType<VeiculoApplicationService>().As<IVeiculoApplicationService>().InstancePerLifetimeScope(); ;

            builder.RegisterType<ProprietarioService>().As<IProprietarioService>().InstancePerLifetimeScope(); ;
            builder.RegisterType<VeiculoService>().As<IVeiculoService>().InstancePerLifetimeScope(); ;
            builder.RegisterType<Notificador>().As<INotificador>().InstancePerLifetimeScope(); ;
            

            builder.RegisterType<VeiculoRepository>().As<IVeiculoRepository>().InstancePerLifetimeScope(); ;
            builder.RegisterType<ProprietarioRepository>().As<IProprietarioRepository>().InstancePerLifetimeScope(); ;

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfig());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            #endregion
        }
    }
}
