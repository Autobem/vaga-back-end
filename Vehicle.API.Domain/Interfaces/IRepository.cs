using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.API.Domain.Entities;

namespace Vehicles.API.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> SelectAsync();
        Task<T> SelectAsync(Guid id);
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistAsync(Guid id);
        Task<IEnumerable<Owner>> GetOnwers();
        Task<Owner> GetOnwer(Guid id);
    }
}
