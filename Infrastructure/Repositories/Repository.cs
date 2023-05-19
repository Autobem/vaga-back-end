using Microsoft.EntityFrameworkCore;

using VehicleRegistry.Application.DataTransferObjects;

namespace VehicleRegistry.Infrastructure.Repositories;

/// <summary>
/// Base para todos os repositórios.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public abstract class Repository<TEntity> where TEntity : class
{
    /// <summary>
    /// Contexto do banco de dados.
    /// </summary>
    protected readonly DbContext context;

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="context">O contexto do banco de dados.</param>
    public Repository(DbContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Adiciona um novo registro.
    /// </summary>
    /// <param name="entity">A entidade com os dados a serem inseridos.</param>
    /// <returns>A tarefa do método assíncrono.</returns>
    public async Task AddAsync(TEntity entity)
    {
        await this.context.Set<TEntity>().AddAsync(entity);
        await this.context.SaveChangesAsync();
    }

    /// <summary>
    /// Resgata determinado registro pelo ID.
    /// </summary>
    /// <param name="id">O ID do registro.</param>
    /// <returns>O registro solicitado.</returns>
    public async Task<TEntity?> GetAsync(Guid id)
    {
        return await this.context.Set<TEntity>().FindAsync(id);
    }

    /// <summary>
    /// Resgata todos os registros de determinada entidade.
    /// </summary>
    /// <returns>Todos os registros existentes.</returns>
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await this.context.Set<TEntity>().ToListAsync();
    }

    /// <summary>
    /// Deleta determinado registro pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do registro.</param>
    /// <returns>A tarefa do método assíncrono.</returns>
    public async Task RemoveAsync(Guid id)
    {
        var entity = await this.GetAsync(id);
        if (entity is not null) {
            this.context.Set<TEntity>().Remove(entity);
            await this.context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Atualiza determinado registro.
    /// </summary>
    /// <param name="data">Os novos dados do registro.</param>
    /// <returns>A tarefa do método assíncrono.</returns>
    public abstract Task UpdateAsync(Data data);
}