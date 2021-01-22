using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public void Adicionar(Veiculo veiculo)
        {
            _testeBackendContext.Set<Veiculo>().Add(veiculo);
            _testeBackendContext.SaveChanges();
        }

        public void Atualizar(Veiculo veiculo)
        {
            _testeBackendContext.Entry(veiculo).State = EntityState.Modified;
            _testeBackendContext.SaveChanges();
        }

        public Veiculo ObterPorId(int id)
        {
            return _testeBackendContext.Set<Veiculo>().Find(id);
        }

        public IEnumerable<Veiculo> ObterTodos()
        {
            return _testeBackendContext.Set<Veiculo>().Include(v => v.Proprietario).ToList();
        }

        public void Remover(int id)
        {
            var veiculo = ObterPorId(id);
            _testeBackendContext.Set<Veiculo>().Remove(veiculo);
            _testeBackendContext.SaveChanges();
        }
    }
}
