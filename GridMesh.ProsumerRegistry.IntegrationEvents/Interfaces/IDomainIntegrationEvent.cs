namespace GridMesh.ProsumerRegistry.IntegrationEvents.Interfaces
{
    public interface IDomainIntegrationEvent
    {
        Guid EventId { get; protected set; }
        DateTime OccuredOnUtc { get; protected set; }
    }
}