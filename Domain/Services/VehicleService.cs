using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Entities;
using VehicleRegistry.Infrastructure.Repositories;

namespace VehicleRegistry.Domain.Services;

/// <summary>
/// Serviço de veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class VehicleService : Service
{
    /// <summary>
    /// O repositório de veículo.
    /// </summary>
    private VehicleRepository repository;

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="repository">O repositório de veículo.</param>
    public VehicleService(VehicleRepository repository)
    {
        this.repository = repository;
    }

    /// <summary>
    /// Cria um novo veículo.
    /// </summary>
    /// <param name="vehicle">Os dados do novo veículo.</param>
    /// <returns>A tarefa do método assíncrono.</returns>
    public async Task Create(VehicleData vehicle)
    {
        await this.repository.AddAsync(new Vehicle {
            Owner = vehicle.Owner,
            Color = vehicle.Color,
            Fuel = vehicle.Fuel,
            Model = vehicle.Model,
            Plate = vehicle.Plate,
            Year = vehicle.Year
        });
    }

    /// <summary>
    /// Pega todos os veículos.
    /// </summary>
    /// <returns>Os veículos registrados.</returns>
    public async Task<List<VehicleData>> GetAll()
    {
        // Resgata os veículos do banco de dados.
        IEnumerable<Vehicle> results = await this.repository.GetAllAsync();
        var vehicles = new List<VehicleData>();
        // Converte as entidades para DTO's.
        VehicleData? data;
        foreach (var vehicle in results)
        {
            data = this.ToDataTransfer(vehicle);
            if (data is not null) {
                vehicles.Add(data);
            }
        }

        return vehicles;
    }

    /// <summary>
    /// Pega um determinado veículo pelo ID.
    /// </summary>
    /// <param name="id">O ID do veículo.</param>
    /// <returns>Os dados do veículo solicitado.</returns>
    public async Task<VehicleData?> GetByID(Guid id)
    {
        return this.ToDataTransfer(await this.repository.GetAsync(id));
    }

    /// <summary>
    /// Pega um determinado veículo pela placa.
    /// </summary>
    /// <param name="plate">A placa do veículo.</param>
    /// <returns>Os dados do veículo solicitado.</returns>
    public VehicleData? GetVehicleByPlate(string plate)
    {
        return this.ToDataTransfer(((VehicleRepository) this.repository).GetByPlate(
            plate
        ));
    }

    /// <summary>
    /// Exclui um determinado veículo pelo ID.
    /// </summary>
    /// <param name="id">O ID do veículo.</param>
    /// <returns>A tarefa do método assíncrono.</returns>
    public async Task RemoveVehicleByID(Guid id)
    {
        await this.repository.RemoveAsync(id);
    }

    /// <summary>
    /// Atualiza um determinado veículo pelo ID.
    /// </summary>
    /// <param name="data">Os novos dados do veículo.</param>
    /// <returns>A tarefa do método assíncrono.</returns>
    public async Task UpdateVehicleByID(VehicleData data)
    {
        await this.repository.UpdateAsync(data);
    }

    /// <summary>
    /// Converte uma dada entidade de veículo para um DTO.
    /// </summary>
    /// <param name="vehicle">A entidade de veículo a ser convertida.</param>
    /// <returns>O novo DTO com os dados do veículo.</returns>
    private VehicleData? ToDataTransfer(Vehicle? vehicle)
    {
        return (vehicle is not null) ? new VehicleData {
            Id = vehicle.Id,
            OwnerId = vehicle.OwnerId,
            ColorId = vehicle.ColorId,
            FuelId = vehicle.FuelId,
            ModelId = vehicle.ModelId,
            Plate = vehicle.Plate,
            Year = vehicle.Year,
            CreatedAt = vehicle.CreatedAt,
            UpdatedAt = vehicle.UpdatedAt
        } : null;
    }
}