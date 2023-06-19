using Domain.Dtos;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Repository.Contexto;
using Repository.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace Repository.Repositorios
{
    public class ProprietarioRepository : IProprietarioRepository
    {
        protected readonly ContextoDB _context;

        public ProprietarioRepository(ContextoDB context)
        {
            _context = context;
        }

        public async Task<Proprietario> GetByDocumento(string documento)
        {
            return await _context.Proprietarios.Where(p => p.Documento == documento).FirstOrDefaultAsync(); 
        }

        public async Task<Proprietario> GetById(int Id)
        {
            return await _context.Proprietarios.Where(p => p.ProprietarioId == Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Veiculo>> GetByVeiculo(string documento)
        {
            var proprietario = await _context.Proprietarios.Where(p => p.Documento == documento).FirstOrDefaultAsync();
            return await _context.Veiculos.Where(p => p.ProprietarioId == proprietario.ProprietarioId).ToListAsync();

        }

        public async Task<int> Add(Proprietario proprietario)
        {
            if (proprietario.ProprietarioId > 0)
            {
                return 0;
            }

            try
            {
                _context.Proprietarios.Add(proprietario);
                _context.SaveChanges();

                return proprietario.ProprietarioId;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return 0;
        }

        public async Task Delete(int id)
        {

            var entity = _context.Proprietarios.Find(id);

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

        public async Task<int> Put(Proprietario proprietario)
        {
            if (proprietario.ProprietarioId < 1)
            {
                return 0;
            }
            try
            {
                _context.Proprietarios.Update(proprietario);
                await _context.SaveChangesAsync();

                return proprietario.ProprietarioId;
            }
            catch (Exception ex)
            {
            }

            return 0;
        }
    }
}
