using AutoBem.Domain.Clients;
using AutoBem.Domain.Clients.Models;
using AutoBem.Infrastructure.Clients.Entities;
using BuildingBlocks.Domain.Generics.CPF;
using BuildingBlocks.Infraestructure.Repositories;
using BuildingBlocks.Ioc.Attributes;
using System.Linq;

namespace AutoBem.Infrastructure.Clients.Repositories
{
    [Injectable]
    public class ClientRepository : CrudRepository<Client, ClientEntity>, IClientRepository
    {
        public bool ExistCPF(CPF cpf)
        {
            return this.DbSet
                .Where(e => e.CPF == cpf.Value)
                .Any();
        }
    }
}
