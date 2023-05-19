using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Entities;
using VehicleRegistry.Infrastructure.Contexts;

namespace VehicleRegistry.Infrastructure.Repositories;

/// <summary>
/// Repositório de tipo de veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class VehicleTypeRepository : Repository<VehicleType>
{
    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="context">O contexto do banco de dados.</param>
    public VehicleTypeRepository(BusinessContext context) : base(context)
    {}

    /// <summary>
    /// Atualiza determinada entidade.
    /// </summary>
    /// <param name="data">Os novos dados da entidade.</param>
    /// <returns>A tarefa do método assíncrono.</returns>
    public override async Task UpdateAsync(Data data)
    {
        var typeData = (VehicleTypeData) data;

        // Pega a entidade correspondente.
        var type = await this.GetAsync(typeData.Id);
        // Verifica se a mesma é válida.
        if (type is not null) {
            // Atualiza os dados.
            type.Name = typeData.Name;
            await this.context.SaveChangesAsync();
        }
    }
}