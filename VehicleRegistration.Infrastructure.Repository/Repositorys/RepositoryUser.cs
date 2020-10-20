using VehicleRegistration.Domain.Models;
using VehicleRegistration.Infrastructure.Data;
using VehicleRegistration.Domain.Core.Interfaces.Repositorys;

namespace VehicleRegistration.Infrastructure.Repository.Repositorys
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        public readonly SqlContext _context;
        public RepositoryUser(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
