using GridMesh.ProsumerRegistry.Domain.Common.Interfaces.Events;

namespace GridMesh.ProsumerRegistry.IntegrationEvents.Interfaces
{
    public interface IIntegrationDomainEventFactoryT<in TDomainEvent> : IIntegrationDomainEventFactory
        where TDomainEvent : IDomainEvent
    {
        IDomainIntegrationEvent ToIntegrationEvent(
            TDomainEvent domainEvent);
    }
}