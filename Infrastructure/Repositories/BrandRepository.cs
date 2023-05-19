using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Entities;
using VehicleRegistry.Infrastructure.Contexts;

namespace VehicleRegistry.Infrastructure.Repositories;

/// <summary>
/// Repositório de marca.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class BrandRepository : Repository<Brand>
{
    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="context">O contexto do banco de dados.</param>
    public BrandRepository(BusinessContext context) : base(context)
    {}

    /// <summary>
    /// Atualiza determinada entidade.
    /// </summary>
    /// <param name="data">Os novos dados da entidade.</param>
    /// <returns>A tarefa do método assíncrono.</returns>
    public override async Task UpdateAsync(Data data)
    {
        var brandData = (BrandData) data;

        // Pega a entidade correspondente.
        var brand = await this.GetAsync(brandData.Id);
        // Verifica se a mesma é válida.
        if (brand is not null) {
            // Atualiza os dados.
            brand.Name = brandData.Name;
            await this.context.SaveChangesAsync();
        }
    }
}