using AutoBem.Domain.Clients.Models;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Generics.CPF;

namespace AutoBem.Domain.Clients
{
    public interface IClientRepository : ICrudRepository<Client>
    {
        bool ExistCPF(CPF cpf);
    }
}
