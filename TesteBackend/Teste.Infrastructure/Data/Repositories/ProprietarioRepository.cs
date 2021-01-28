using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Teste.Domain.Core.Interfaces.Repositories;
using Teste.Domain.Entities;
using Teste.Infrastructure.Data.Context;

namespace Teste.Infrastructure.Data.Repositories
{
    public class ProprietarioRepository : IProprietarioRepository
    {
        private readonly TesteBackendContext _testeBackendContext;

        public ProprietarioRepository(TesteBackendContext testeBackendContext)
        {
            _testeBackendContext = testeBackendContext;
        }

        public async Task Adicionar(Proprietario proprietario)
        {
            _testeBackendContext.Set<Proprietario>().Add(proprietario);
            await _testeBackendContext.SaveChangesAsync();
        }

        public async Task Atualizar(Proprietario proprietario)
        {
            _testeBackendContext.Entry(proprietario).State = EntityState.Modified;
            await _testeBackendContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Proprietario>> Buscar(Expression<Func<Proprietario, bool>> predicate)
        {
            return await _testeBackendContext.Set<Proprietario>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<Proprietario> ObterPorId(int id)
        {
            return await _testeBackendContext.Set<Proprietario>().FindAsync(id);
        }

        public async Task<Proprietario> ObterProprietarioVeiculos(int id)
        {
            return await _testeBackendContext.Proprietarios.AsNoTracking().Include(p => p.Veiculos).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Proprietario>> ObterTodos()
        {
            return await _testeBackendContext.Set<Proprietario>().ToListAsync();
        }

        public async Task Remover(int id)
        {
            var proprietario = await ObterPorId(id);
            _testeBackendContext.Set<Proprietario>().Remove(proprietario);
            await _testeBackendContext.SaveChangesAsync();
        }
    }
}
