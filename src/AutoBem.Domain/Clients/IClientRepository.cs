using AutoBem.Domain.Clients.Models;
using BuildingBlocks.Domain;

namespace AutoBem.Domain.Clients
{
    public interface IClientRepository : ICrudRepository<Client>
    {
    }
}
