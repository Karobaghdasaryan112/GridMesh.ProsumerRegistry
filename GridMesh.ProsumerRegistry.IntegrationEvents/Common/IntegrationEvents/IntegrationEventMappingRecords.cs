using GridMesh.ProsumerRegistry.Domain.Common.Interfaces.Events;
using GridMesh.ProsumerRegistry.IntegrationEvents.Interfaces;

namespace GridMesh.ProsumerRegistry.IntegrationEvents.Common.IntegrationEvents
{
    public record IntegrationEventMappingEntryRecord(
        string EventType,
        Func<IDomainEvent, IntegrationEventMappingRecord> Map);

    public sealed record IntegrationEventMappingRecord(
        IDomainIntegrationEvent Event,
        string Topic,
        string EventType);
}