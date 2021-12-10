using Projeto.Domain.Aggregates.Veiculos.Contracts.Repositories;
using Projeto.Domain.Aggregates.Veiculos.Contracts.Services;
using Projeto.Domain.Aggregates.Veiculos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Aggregates.Veiculos.Services
{
    public class VeiculoDomainService : IVeiculoDomainService
    {
        //atributo
        private readonly IVeiculoRepository veiculoRepository;

        public VeiculoDomainService(IVeiculoRepository veiculoRepository)
        {
            this.veiculoRepository = veiculoRepository;
        }

        public void Create(Veiculo obj)
        {
            veiculoRepository.Create(obj);
        }

        public void Update(Veiculo obj)
        {
            veiculoRepository.Update(obj);
        }

        public void Delete(Veiculo obj)
        {
            veiculoRepository.Delete(obj);
        }

        public List<Veiculo> GetAll()
        {
            return veiculoRepository.GetAll();
        }

        public Veiculo GetById(int id)
        {
            return veiculoRepository.GetById(id);
        }

    }
}
