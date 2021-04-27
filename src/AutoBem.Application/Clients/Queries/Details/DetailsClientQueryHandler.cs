using AutoBem.Domain.Clients;
using AutoBem.Domain.Clients.Models;
using BuildingBlocks.Application.Queries.Details;
using BuildingBlocks.Ioc.Attributes;

namespace AutoBem.Application.Clients.Queries.Details
{
    [Injectable]
    public class DetailsClientQueryHandler : DetailsQueryHandler<Client, DetailsClientQuery, DetailsClientResult, IClientRepository>
    {
    }
}
