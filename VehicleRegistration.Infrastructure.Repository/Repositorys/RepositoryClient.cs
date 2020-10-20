using VehicleRegistration.Domain.Models;
using VehicleRegistration.Infrastructure.Data;
using VehicleRegistration.Domain.Core.Interfaces.Repositorys;

namespace VehicleRegistration.Infrastructure.Repository.Repositorys
{
    public class RepositoryClient : RepositoryBase<Client>, IRepositoryClient
    {
        public readonly SqlContext _context;
        public RepositoryClient(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
