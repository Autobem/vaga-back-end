using VehicleRegistration.Domain.Models;
using VehicleRegistration.Domain.Core.Interfaces.Services;
using VehicleRegistration.Domain.Core.Interfaces.Repositorys;

namespace VehicleRegistration.Domain.Service
{
    public class ServiceCar : ServiceBase<Car>, IServiceCar
    {
        private readonly IRepositoryCar _repositoryCar;

        public ServiceCar(IRepositoryCar RepositoryCar)
            : base(RepositoryCar)
        {
            _repositoryCar = RepositoryCar;
        }
    }
}
