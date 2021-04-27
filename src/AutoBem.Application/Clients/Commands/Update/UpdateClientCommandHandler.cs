using AutoBem.Domain.Clients;
using AutoBem.Domain.Clients.Models;
using BuildingBlocks.Application.Commands.Update;
using BuildingBlocks.Ioc.Attributes;

namespace AutoBem.Application.Clients.Commands.Update
{
    [Injectable]
    public class UpdateClientCommandHandler : UpdateCommandHandler<Client, UpdateClientCommand, IClientRepository>
    {
    }
}
