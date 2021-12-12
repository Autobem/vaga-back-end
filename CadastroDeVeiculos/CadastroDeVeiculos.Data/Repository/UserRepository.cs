using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Data.EntityFramework.Context;
using CadastroDeVeiculos.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._applicationDbContext = dbContext;
        }

        public async Task<User> GetLogin(string login, string password)
        {
            return  this._applicationDbContext.Set<User>().Where(c => c.LoginData == login && c.Password == password).FirstOrDefault();
        }
    }
}
