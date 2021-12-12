using CadastroDeVeiculos.Application.DTOs;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Interfaces
{
    public interface IUserService : IBaseService<UserDTO>
    {
        Task<UserDTO> GetLogin(string login, string password);
    }
}
