using System;

namespace BuildingBlocks.Infraestructure.Entities
{
    public abstract class CommonEntity : ICommonEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
