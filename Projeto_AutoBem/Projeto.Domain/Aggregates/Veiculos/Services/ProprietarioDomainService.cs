using Projeto.Domain.Aggregates.Veiculos.Contracts.Repositories;
using Projeto.Domain.Aggregates.Veiculos.Contracts.Services;
using Projeto.Domain.Aggregates.Veiculos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Aggregates.Veiculos.Services
{
    public class ProprietarioDomainService : IProprietarioDomainService
    {
        //atributo
        private readonly IProprietarioRepository  proprietarioRepository;

        //construtor para injeção de dependência (inicialização)
        public ProprietarioDomainService(IProprietarioRepository proprietarioRepository)
        {
            this.proprietarioRepository = proprietarioRepository;
        }

        public void Create(Proprietario obj)
        {
            proprietarioRepository.Create(obj);
        }

        public void Update(Proprietario obj)
        {
            proprietarioRepository.Update(obj);
        }

        public void Delete(Proprietario obj)
        {
            proprietarioRepository.Delete(obj);
        }

        public List<Proprietario> GetAll()
        {
            return proprietarioRepository.ListarTodos();
        }

        public Proprietario GetById(int id)
        {
            return proprietarioRepository.GetById(id);
        }
    }
}
