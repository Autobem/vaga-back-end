using System;

namespace BuildingBlocks.Infraestructure.Entities
{
    public interface ICommonEntity
    {
        Guid Id { get; set; }

        DateTimeOffset CreatedAt { get; set; }

        Guid CreatedBy { get; set; }

        DateTimeOffset? UpdatedAt { get; set; }

        Guid? UpdatedBy { get; set; }

    }
}
