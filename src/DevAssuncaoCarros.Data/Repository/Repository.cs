using DevAssuncaoCarros.Business.Interfaces;
using DevAssuncaoCarros.Business.Models;
using DevAssuncaoCarros.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevAssuncaoCarros.Data.Repository
{
    public abstract class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : Entidade, new()
    {

        protected readonly CarroContext carroContext;
        protected readonly DbSet<TEntidade> DbSet;

        public Repository(CarroContext context)
        {
            carroContext = context;
            DbSet = context.Set<TEntidade>();
        }

        public async Task<IEnumerable<TEntidade>> ObterTodos()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntidade> ObterPorId(Guid id)
        {
            return await DbSet.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task Adicionar(TEntidade entidade)
        {
            DbSet.Add(entidade);
            await SaveChanges(); 
        }

        public async Task Atualizar(TEntidade entidade)
        {
            DbSet.Update(entidade);
            await SaveChanges();
        }

        public async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntidade { Id = id });  
            await SaveChanges();
        }
        public async void Dispose()
        {
            await carroContext.DisposeAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await carroContext.SaveChangesAsync();
        }
    }
}
