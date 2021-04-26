using System;

namespace BuildingBlocks.Domain.Models
{
    public interface IModel
    {
        public Guid? Id { get; set; }
    }
}
