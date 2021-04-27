using AutoBem.Domain.Clients;
using AutoBem.Domain.Clients.Models;
using BuildingBlocks.Application.Queries.List;
using BuildingBlocks.Ioc.Attributes;

namespace AutoBem.Application.Clients.Queries.ListAll
{
    [Injectable]
    public class ListAllClientQueryHandler : ListAllQueryHandler<Client, ListAllVehicleQuery, ListClientResult, IClientRepository>
    {
    }
}
