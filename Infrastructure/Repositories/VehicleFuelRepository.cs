using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Entities;
using VehicleRegistry.Infrastructure.Contexts;

namespace VehicleRegistry.Infrastructure.Repositories;

/// <summary>
/// Repositório de combustível de veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class VehicleFuelRepository : Repository<VehicleFuel>
{
    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="context">O contexto do banco de dados.</param>
    public VehicleFuelRepository(BusinessContext context) : base(context)
    {}

    /// <summary>
    /// Atualiza determinada entidade.
    /// </summary>
    /// <param name="data">Os novos dados da entidade.</param>
    /// <returns>A tarefa do método assíncrono.</returns>
    public override async Task UpdateAsync(Data data)
    {
        var fuelData = (VehicleFuelData) data;

        // Pega a entidade correspondente.
        var fuel = await this.GetAsync(fuelData.Id);
        // Verifica se a mesma é válida.
        if (fuel is not null) {
            // Atualiza os dados.
            fuel.Name = fuelData.Name;
            await this.context.SaveChangesAsync();
        }
    }
}