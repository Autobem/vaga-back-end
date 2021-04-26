using BuildingBlocks.Application.Requests;
using System;

namespace BuildingBlocks.Application.Commands.Delete
{
    public abstract class DeleteCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
