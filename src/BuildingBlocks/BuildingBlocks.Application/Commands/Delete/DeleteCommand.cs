using BuildingBlocks.Application.Requests;
using System;

namespace BuildingBlocks.Application.Commands.Delete
{
    public abstract class DeleteCommand : IRequest
    {
        public DeleteCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
