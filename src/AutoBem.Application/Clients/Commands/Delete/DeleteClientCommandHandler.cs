using AutoBem.Domain.Clients;
using AutoBem.Domain.Clients.Models;
using BuildingBlocks.Application.Commands.Delete;
using BuildingBlocks.Ioc.Attributes;

namespace AutoBem.Application.Clients.Commands.Delete
{
    [Injectable]
    public class DeleteClientCommandHandler : DeleteCommandHandler<Client, DeleteClientCommand, IClientRepository>
    {
    }
}
