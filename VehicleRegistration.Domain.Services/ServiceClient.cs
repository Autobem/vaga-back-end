using VehicleRegistration.Domain.Models;
using VehicleRegistration.Domain.Core.Interfaces.Services;
using VehicleRegistration.Domain.Core.Interfaces.Repositorys;

namespace VehicleRegistration.Domain.Service
{
    public class ServiceClient : ServiceBase<Client>, IServiceClient
    {
        private readonly IRepositoryClient _repositoryClient;

        public ServiceClient(IRepositoryClient RepositoryClient)
            : base(RepositoryClient)
        {
            _repositoryClient = RepositoryClient;
        }
    }
}
