using System.Collections.Generic;
using Teste.Application.Dtos;

namespace Teste.Application.Interfaces
{
    public interface IProprietarioApplicationService
    {
        void Adicionar(ProprietarioDto proprietarioDto);
        void Atualizar(ProprietarioDto proprietarioDto);
        void Remover(int id);
        ProprietarioDto ObterPorId(int id);
        IEnumerable<ProprietarioDto> ObterTodos();
    }
}
