using Microsoft.EntityFrameworkCore;

using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Entities;
using VehicleRegistry.Infrastructure.Contexts;

namespace VehicleRegistry.Infrastructure.Repositories;

/// <summary>
/// Repositório de modelo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class ModelRepository : Repository<Model>
{
    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="context">O contexto do banco de dados.</param>
    public ModelRepository(BusinessContext context) : base(context)
    {}

    /// <summary>
    /// Resgata os modelos a partir da marca.
    /// </summary>
    /// <param name="brandId">O ID da marca.</param>
    /// <returns>Os modelos solicitados.</returns>
    public async Task<IEnumerable<Model>> GetByBrandAsync(Guid brandId)
    {
        return await this.context.Set<Model>().Where(
            model => model.BrandId == brandId
        ).ToListAsync();
    }

    /// <summary>
    /// Atualiza determinada entidade.
    /// </summary>
    /// <param name="data">Os novos dados da entidade.</param>
    /// <returns>A tarefa do método assíncrono.</returns>
    public override async Task UpdateAsync(Data data)
    {
        var modelData = (ModelData) data;

        // Pega a entidade correspondente.
        var model = await this.GetAsync(modelData.Id);
        // Verifica se a mesma é válida.
        if (model is not null) {
            // Atualiza os dados.
            model.Name = modelData.Name;
            await this.context.SaveChangesAsync();
        }
    }
}