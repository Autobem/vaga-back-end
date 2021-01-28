using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Domain.Core.Interfaces.Repositories;
using Teste.Domain.Entities;
using Teste.Infrastructure.Data.Context;

namespace Teste.Infrastructure.Data.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly TesteBackendContext _testeBackendContext;

        public VeiculoRepository(TesteBackendContext testeBackendContext)
        {
            _testeBackendContext = testeBackendContext;
        }

        public async Task Adicionar(Veiculo veiculo)
        {
            _testeBackendContext.Set<Veiculo>().Add(veiculo);
            await _testeBackendContext.SaveChangesAsync();
        }

        public async Task Atualizar(Veiculo veiculo)
        {
            _testeBackendContext.Entry(veiculo).State = EntityState.Modified;
            await _testeBackendContext.SaveChangesAsync();
        }

        public async Task<Veiculo> ObterPorId(int id)
        {
            return await _testeBackendContext.Set<Veiculo>().AsNoTracking().Include(v => v.Proprietario).Where(v => v.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Veiculo>> ObterTodos()
        {
            return await _testeBackendContext.Set<Veiculo>().Include(v => v.Proprietario).ToListAsync();
        }

        public async Task Remover(int id)
        {
            var veiculo = await ObterPorId(id);
            _testeBackendContext.Set<Veiculo>().Remove(veiculo);
            await _testeBackendContext.SaveChangesAsync();
        }
    }
}
