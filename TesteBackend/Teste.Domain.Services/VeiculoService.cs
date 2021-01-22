using System.Collections.Generic;
using Teste.Domain.Core.Interfaces.Repositories;
using Teste.Domain.Core.Interfaces.Services;
using Teste.Domain.Entities;

namespace Teste.Domain.Services
{
     public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public void Adicionar(Veiculo veiculo)
        {
            _veiculoRepository.Adicionar(veiculo);
        }

        public void Atualizar(Veiculo veiculo)
        {
            _veiculoRepository.Atualizar(veiculo);
        }

        public Veiculo ObterPorId(int id)
        {
            return _veiculoRepository.ObterPorId(id);
        }

        public IEnumerable<Veiculo> ObterTodos()
        {
            return _veiculoRepository.ObterTodos();
        }

        public void Remover(int id)
        {
            _veiculoRepository.Remover(id);
        }
    }
}
