using GridMesh.ProsumerRegistry.Domain.Common.Entities.Base;

namespace GridMesh.ProsumerRegistry.Domain.Entities
{
    public class OutboxMessage : Entity
    {
        public Guid Id { get; set; }

        public string Type { get; set; } = null!;

        public string Content { get; set; } = null!;

        public DateTime OccurredOnUtc { get; set; }

        public DateTime? ProcessedOnUtc { get; set; }

        public string? Error { get; set; }
        public string Topic { get; set; }
    }
}