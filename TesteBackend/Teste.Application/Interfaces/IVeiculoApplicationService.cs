using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Application.Dtos;

namespace Teste.Application.Interfaces
{
    public interface IVeiculoApplicationService
    {
        Task<bool> Adicionar(VeiculoDto veiculoDto);
        Task<bool> Atualizar(VeiculoDto veiculoDto);
        Task<bool> Remover(int id);
        Task<VeiculoDto> ObterPorId(int id);
        Task<IEnumerable<VeiculoDto>> ObterTodos();
    }
}
