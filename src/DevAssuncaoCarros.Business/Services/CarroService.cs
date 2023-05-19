using DevAssuncaoCarros.Business.Interfaces;
using DevAssuncaoCarros.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAssuncaoCarros.Business.Services
{
    public class CarroService : ICarroService
    {
        private readonly ICarroRepository _carroRepo;

        public CarroService(ICarroRepository carroRepo)
        {
            _carroRepo = carroRepo;
        }

        public async Task<bool> AddCarro(Carro carro)
        {
            if(carro == null)
            {
                return false;
            }

            try
            {
                await _carroRepo.Adicionar(carro);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return true;
        }

        public async Task<bool> AtualizarCarro(Carro carro)
        {
            if (carro == null)
            {
                return false;
            }

            try
            {
                await _carroRepo.Atualizar(carro);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return true;
        }

        public async Task<bool> RemoverCarro(Guid id)
        {
            var buscarCarro = await _carroRepo.ObterPorId(id);

            if(buscarCarro != null)
            {
                await _carroRepo.Remover(id);
            }

            return true;

        }

        public void Dispose()
        {
            _carroRepo?.Dispose();
        }


    }
}
