namespace Domain.Contracts.Repository;

public interface IBaseRepository<T>
{
    Task<T> Insert(T entity);

    Task Delete(Guid id);

    Task Update(T entity);

    Task<List<T>> Get();

    Task<T> GetById(Guid id);
}