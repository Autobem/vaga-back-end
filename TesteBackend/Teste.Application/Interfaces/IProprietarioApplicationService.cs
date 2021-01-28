using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Application.Dtos;

namespace Teste.Application.Interfaces
{
    public interface IProprietarioApplicationService
    {
        Task<bool> Adicionar(ProprietarioDto proprietarioDto);
        Task<bool> Atualizar(ProprietarioDto proprietarioDto);
        Task<bool> Remover(int id);
        Task<ProprietarioDto> ObterPorId(int id);
        Task<IEnumerable<ProprietarioDto>> ObterTodos();
    }
}
