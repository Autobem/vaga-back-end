using BuildingBlocks.Application.Commands.Delete;
using System;

namespace AutoBem.Application.Clients.Commands.Delete
{
    public class DeleteClientCommand : DeleteCommand
    {
        public DeleteClientCommand(Guid id) : base(id)
        {
        }
    }
}
