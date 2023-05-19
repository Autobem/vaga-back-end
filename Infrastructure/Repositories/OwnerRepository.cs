using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Entities;
using VehicleRegistry.Infrastructure.Contexts;

namespace VehicleRegistry.Infrastructure.Repositories;

/// <summary>
/// Repositório de proprietário.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class OwnerRepository : Repository<Owner>
{
    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="context">O contexto do banco de dados.</param>
    public OwnerRepository(BusinessContext context) : base(context)
    {}

    /// <summary>
    /// Atualiza determinada entidade.
    /// </summary>
    /// <param name="data">Os novos dados da entidade.</param>
    /// <returns>A tarefa do método assíncrono.</returns>
    public override async Task UpdateAsync(Data data)
    {
        var ownerData = (OwnerData) data;

        // Pega a entidade correspondente.
        var owner = await this.GetAsync(ownerData.Id);
        // Verifica se a mesma é válida.
        if (owner is not null) {
            // Atualiza os dados.
            owner.Name = ownerData.Name;
            owner.Surname = ownerData.Surname;
            await this.context.SaveChangesAsync();
        }
    }
}