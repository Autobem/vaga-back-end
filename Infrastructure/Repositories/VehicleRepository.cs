using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Entities;
using VehicleRegistry.Infrastructure.Contexts;

namespace VehicleRegistry.Infrastructure.Repositories;

/// <summary>
/// Repositório de veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class VehicleRepository : Repository<Vehicle>
{
    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="context">O contexto do banco de dados.</param>
    public VehicleRepository(BusinessContext context) : base(context)
    {}

    /// <summary>
    /// Resgata determinado veículo pela sua placa.
    /// </summary>
    /// <param name="plate">A placa do veículo.</param>
    /// <returns>O veículo solicitado.</returns>
    public Vehicle? GetByPlate(string plate)
    {
        return this.context.Set<Vehicle>().Where(
            vehicle => vehicle.Plate == plate
        ).FirstOrDefault();
    }

    /// <summary>
    /// Atualiza determinada entidade.
    /// </summary>
    /// <param name="data">Os novos dados da entidade.</param>
    /// <returns>A tarefa do método assíncrono.</returns>
    public override async Task UpdateAsync(Data data)
    {
        var vehicleData = (VehicleData) data;

        // Pega a entidade correspondente.
        var vehicle = await this.GetAsync(vehicleData.Id);
        // Verifica se a mesma é válida.
        if (vehicle is not null) {
            // Atualiza os dados.
            vehicle.Owner = vehicleData.Owner;
            vehicle.Color = vehicleData.Color;
            vehicle.Fuel = vehicleData.Fuel;
            vehicle.Model = vehicleData.Model;
            vehicle.Plate = vehicleData.Plate;
            vehicle.Year = vehicleData.Year;
            await this.context.SaveChangesAsync();
        }
    }
}