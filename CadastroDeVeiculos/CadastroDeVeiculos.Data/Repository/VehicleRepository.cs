using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Data.EntityFramework.Context;
using CadastroDeVeiculos.Domain.Entities;

namespace CadastroDeVeiculos.Data.Repository
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
