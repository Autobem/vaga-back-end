using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Repository.Contexto;
using Repository.Interfaces;

namespace Repository.Repositorios
{
    public class VeiculoRepository : IVeiculoRepository
    {
        protected readonly ContextoDB _context;

        public VeiculoRepository(ContextoDB context)
        {
            _context = context;
        }
        public async Task<int> Add(Veiculo veiculo)
        {
            if (veiculo.VeiculoId > 0)
            {
                return 0;
            }

            try
            {
                _context.Veiculos.Add(veiculo);
                _context.SaveChanges();

                return veiculo.VeiculoId;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return 0;
        }

        public async Task Delete(int Id)
        {
            var entity = _context.Proprietarios.Find(Id);

            try
            {
                _context.Proprietarios.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Veiculo> GetByDocumento(long documento)
        {
            return await _context.Veiculos.Where(p => p.Renavam == documento).FirstOrDefaultAsync();
        }

        public async Task<Veiculo> GetById(int Id)
        {
            return await _context.Veiculos.Where(p => p.ProprietarioId == Id).FirstOrDefaultAsync();
        }

        public async Task<int> Put(Veiculo veiculo)
        {
            if (veiculo.VeiculoId < 1)
            {
                return 0;
            }
            try
            {
                _context.Veiculos.Update(veiculo);
                _context.SaveChanges();

                return veiculo.VeiculoId;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return 0;
        }
    }
}
