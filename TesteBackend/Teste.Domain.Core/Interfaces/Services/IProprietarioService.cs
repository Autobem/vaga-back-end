using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Domain.Entities;

namespace Teste.Domain.Core.Interfaces.Services
{
    public interface IProprietarioService
    {
        Task<bool> Adicionar(Proprietario proprietario);
        Task<bool> Atualizar(Proprietario proprietario);
        Task<bool> Remover(int id);
    }
}
