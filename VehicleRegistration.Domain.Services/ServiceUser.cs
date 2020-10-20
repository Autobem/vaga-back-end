using VehicleRegistration.Domain.Models;
using VehicleRegistration.Domain.Core.Interfaces.Services;
using VehicleRegistration.Domain.Core.Interfaces.Repositorys;

namespace VehicleRegistration.Domain.Service
{
    public class ServiceUser : ServiceBase<User>, IServiceUser
    {
        private readonly IRepositoryUser _repositoryUser;

        public ServiceUser(IRepositoryUser RepositoryUser)
            : base(RepositoryUser)
        {
            _repositoryUser = RepositoryUser;
        }
    }
}
