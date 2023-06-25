using Domain.Contracts.Repository;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : class
{
    private readonly BaseContext _context;

    public BaseRepository(BaseContext context)
    {
        var options = new DbContextOptions<BaseContext>();
        _context = context ?? new BaseContext(options);
    }

    public async Task<T> Insert(T entity)
    {
        var result = await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task Update(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        _context.Set<T>().Remove(await GetById(id));
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> Get()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    #region Dispose Implementation

    private bool disposedValue;

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        _context.Dispose();
        disposedValue = disposing;
    }

    #endregion Dispose Implementation

}