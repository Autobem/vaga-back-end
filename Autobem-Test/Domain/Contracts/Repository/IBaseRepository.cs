namespace Domain.Contracts.Repository;

public interface IBaseRepository<T>
{
    Task Insert(T entity);
    Task Delete(Guid id);
    Task Update(T entity);
    Task<IEnumerable<T>> Get();
    Task<T> GetById(Guid id);
}