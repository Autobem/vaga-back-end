using System.Linq;
using System.Threading.Tasks;
using Teste.Domain.Core.Interfaces.Repositories;
using Teste.Domain.Core.Interfaces.Services;
using Teste.Domain.Entities;
using Teste.Domain.Entities.Validations;

namespace Teste.Domain.Services
{
    public class ProprietarioService : ServiceBase, IProprietarioService
    {
        private readonly IProprietarioRepository _proprietarioRepository;

        public ProprietarioService(IProprietarioRepository proprietarioRepository,
            INotificador notificador) : base(notificador)
        {
            _proprietarioRepository = proprietarioRepository;
        }

        public async Task<bool> Adicionar(Proprietario proprietario)
        {
            if (!ExecutarValidacao(new ProprietarioValidation(), proprietario)) return false;
            if (_proprietarioRepository.Buscar(p => p.Cpf == proprietario.Cpf).Result.Any())
            {
                Notificar("Já existe um proprietário com o CPF informado.");
                return false;
            }
            await _proprietarioRepository.Adicionar(proprietario);
            return true;
        }

        public async Task<bool> Atualizar(Proprietario proprietario)
        {
            if (!ExecutarValidacao(new ProprietarioValidation(), proprietario)) return false;

            if (_proprietarioRepository.Buscar(p => p.Cpf == proprietario.Cpf && p.Id != proprietario.Id).Result.Any())
            {
                Notificar("Já existe um proprietário com o CPF infomado.");
                return false;
            }
            await _proprietarioRepository.Atualizar(proprietario);
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            if (_proprietarioRepository.ObterProprietarioVeiculos(id).Result.Veiculos.Any())
            {
                Notificar("O proprietário possui veiculo(s) cadastrado(s)!");
                return false;
            }
            await _proprietarioRepository.Remover(id);
            return true;
        }
    }
}
