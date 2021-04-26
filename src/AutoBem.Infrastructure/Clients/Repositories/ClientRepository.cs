using AutoBem.Domain.Clients;
using AutoBem.Domain.Clients.Models;
using AutoBem.Infrastructure.Clients.Entities;
using BuildingBlocks.Infraestructure.Repositories;
using BuildingBlocks.Ioc.Attributes;

namespace AutoBem.Infrastructure.Clients.Repositories
{
    [Injectable]
    public class ClientRepository : CrudRepository<Client, ClientEntity>, IClientRepository
    {

    }
}
