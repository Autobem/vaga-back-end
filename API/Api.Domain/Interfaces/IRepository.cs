using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity:BaseEntity
    {
        Task<TEntity> AdicionarAsync(TEntity model);
        Task<TEntity> AtualizarAsync(TEntity model);
        Task<int> DeletarAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
    }
}