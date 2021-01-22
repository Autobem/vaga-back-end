using System.Collections.Generic;
using Teste.Application.Dtos;

namespace Teste.Application.Interfaces
{
    public interface IVeiculoApplicationService
    {
        void Adicionar(VeiculoDto veiculoDto);
        void Atualizar(VeiculoDto veiculoDto);
        void Remover(int id);
        VeiculoDto ObterPorId(int id);
        IEnumerable<VeiculoDto> ObterTodos();
    }
}
