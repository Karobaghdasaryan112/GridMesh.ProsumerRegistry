namespace GridMesh.ProsumerRegistry.Domain.Common.Interfaces.Events;

public interface IDomainEvent
{
    Guid EventId { get; set; }
    DateTime OccuredOnUtc => DateTime.UtcNow;
}