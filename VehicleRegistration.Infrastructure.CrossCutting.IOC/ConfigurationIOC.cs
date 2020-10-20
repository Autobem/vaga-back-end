using Autofac;
using VehicleRegistration.Domain.Service;
using VehicleRegistration.Application.Services;
using VehicleRegistration.Application.Interfaces;
using VehicleRegistration.Domain.Core.Interfaces.Services;
using VehicleRegistration.Domain.Core.Interfaces.Repositorys;
using VehicleRegistration.Infrastructure.Repository.Repositorys;
using VehicleRegistration.Infrastructure.CrossCutting.Adapter.Map;
using VehicleRegistration.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace VehicleRegistration.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceClient>().As<IApplicationServiceClient>();
            builder.RegisterType<ApplicationServiceCar>().As<IApplicationServiceCar>();
            builder.RegisterType<ApplicationServiceUser>().As<IApplicationServiceUser>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceClient>().As<IServiceClient>();
            builder.RegisterType<ServiceCar>().As<IServiceCar>();
            builder.RegisterType<ServiceUser>().As<IServiceUser>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositoryClient>().As<IRepositoryClient>();
            builder.RegisterType<RepositoryCar>().As<IRepositoryCar>();
            builder.RegisterType<RepositoryUser>().As<IRepositoryUser>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<MapperClient>().As<IMapperClient>();
            builder.RegisterType<MapperCar>().As<IMapperCar>();
            builder.RegisterType<MapperUser>().As<IMapperUser>();
            #endregion

            #endregion
        }
    }
}
