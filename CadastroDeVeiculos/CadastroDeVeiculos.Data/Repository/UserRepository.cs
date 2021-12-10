using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Data.EntityFramework.Context;
using CadastroDeVeiculos.Domain.Entities;

namespace CadastroDeVeiculos.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
