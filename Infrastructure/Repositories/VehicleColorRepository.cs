using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Entities;
using VehicleRegistry.Infrastructure.Contexts;

namespace VehicleRegistry.Infrastructure.Repositories;

/// <summary>
/// Repositório de cor de veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class VehicleColorRepository : Repository<VehicleColor>
{
    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="context">O contexto do banco de dados.</param>
    public VehicleColorRepository(BusinessContext context) : base(context)
    {}

    /// <summary>
    /// Atualiza determinada entidade.
    /// </summary>
    /// <param name="data">Os novos dados da entidade.</param>
    /// <returns>A tarefa do método assíncrono.</returns>
    public override async Task UpdateAsync(Data data)
    {
        var colorData = (VehicleColorData) data;

        // Pega a entidade correspondente.
        var color = await this.GetAsync(colorData.Id);
        // Verifica se a mesma é válida.
        if (color is not null) {
            // Atualiza os dados.
            color.Name = colorData.Name;
            await this.context.SaveChangesAsync();
        }
    }
}