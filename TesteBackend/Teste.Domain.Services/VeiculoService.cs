using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Domain.Core.Interfaces.Repositories;
using Teste.Domain.Core.Interfaces.Services;
using Teste.Domain.Entities;
using Teste.Domain.Entities.Validations;

namespace Teste.Domain.Services
{
     public class VeiculoService : ServiceBase, IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository,
            INotificador notificador) : base(notificador)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<bool> Adicionar(Veiculo veiculo)
        {
            if (!ExecutarValidacao(new VeiculoValidation(), veiculo)) return false;
            await _veiculoRepository.Adicionar(veiculo);
            return true;
        }

        public async Task<bool> Atualizar(Veiculo veiculo)
        {
            if (!ExecutarValidacao(new VeiculoValidation(), veiculo)) return false;
            await _veiculoRepository.Atualizar(veiculo);
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _veiculoRepository.Remover(id);
            return true;
        }
    }
}
