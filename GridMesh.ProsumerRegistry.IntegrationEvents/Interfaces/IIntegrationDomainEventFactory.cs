using GridMesh.ProsumerRegistry.Domain.Common.Interfaces.Events;

namespace GridMesh.ProsumerRegistry.IntegrationEvents.Interfaces
{
    public interface IIntegrationDomainEventFactory
    {
        string EventType { get; }
        string Topic { get; }
        IDomainIntegrationEvent ToIntegrationEvent(IDomainEvent domainEvent);
    }
}