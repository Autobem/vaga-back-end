using System.Collections.Generic;
using Teste.Domain.Core.Interfaces.Repositories;
using Teste.Domain.Core.Interfaces.Services;
using Teste.Domain.Entities;

namespace Teste.Domain.Services
{
    public class ProprietarioService : IProprietarioService
    {
        private readonly IProprietarioRepository _proprietarioRepository;

        public ProprietarioService(IProprietarioRepository proprietarioRepository)
        {
            _proprietarioRepository = proprietarioRepository;
        }

        public void Adicionar(Proprietario proprietario)
        {
            _proprietarioRepository.Adicionar(proprietario);
        }

        public void Atualizar(Proprietario proprietario)
        {
            _proprietarioRepository.Atualizar(proprietario);
        }

        public Proprietario ObterPorId(int id)
        {
            return _proprietarioRepository.ObterPorId(id);
        }

        public IEnumerable<Proprietario> ObterTodos()
        {
            return _proprietarioRepository.ObterTodos();
        }

        public void Remover(int id)
        {
            _proprietarioRepository.Remover(id);
        }
    }
}
