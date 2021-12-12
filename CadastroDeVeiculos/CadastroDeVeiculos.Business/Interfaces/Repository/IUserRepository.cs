using CadastroDeVeiculos.Domain.Entities;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Business.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetLogin(string login, string password);
    }
}
