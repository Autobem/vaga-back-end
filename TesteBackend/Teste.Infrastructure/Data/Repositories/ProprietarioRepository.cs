using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public void Adicionar(Proprietario proprietario)
        {
            _testeBackendContext.Set<Proprietario>().Add(proprietario);
            _testeBackendContext.SaveChanges();
        }

        public void Atualizar(Proprietario proprietario)
        {
            _testeBackendContext.Entry(proprietario).State = EntityState.Modified;
            _testeBackendContext.SaveChanges();
        }

        public Proprietario ObterPorId(int id)
        {
            return _testeBackendContext.Set<Proprietario>().Find(id);
        }

        public IEnumerable<Proprietario> ObterTodos()
        {
            return _testeBackendContext.Set<Proprietario>().Include(p => p.Veiculos).ToList();
        }

        public void Remover(int id)
        {
            var proprietario = ObterPorId(id);
            _testeBackendContext.Set<Proprietario>().Remove(proprietario);
            _testeBackendContext.SaveChanges();
        }
    }
}
