using AutoBem.Domain.Clients;
using AutoBem.Domain.Clients.Models;
using BuildingBlocks.Application.Commands.Create;
using BuildingBlocks.Ioc.Attributes;

namespace AutoBem.Application.Clients.Commands.Create
{
    [Injectable]
    public class CreateClientCommandHandler : CreateCommandHandler<Client, CreateClientCommand, CreateClientResult, IClientRepository>
    {
    }
}
