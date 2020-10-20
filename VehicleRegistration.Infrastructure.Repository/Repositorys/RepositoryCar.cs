using VehicleRegistration.Domain.Models;
using VehicleRegistration.Infrastructure.Data;
using VehicleRegistration.Domain.Core.Interfaces.Repositorys;

namespace VehicleRegistration.Infrastructure.Repository.Repositorys
{
    public class RepositoryCar : RepositoryBase<Car>, IRepositoryCar
    {
        public readonly SqlContext _context;
        public RepositoryCar(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
