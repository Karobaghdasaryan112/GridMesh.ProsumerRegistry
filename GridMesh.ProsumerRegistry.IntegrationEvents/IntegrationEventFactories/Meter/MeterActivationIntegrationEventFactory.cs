using GridMesh.ProsumerRegistry.Domain.Common.Interfaces.Events;
using GridMesh.ProsumerRegistry.Domain.Constants;
using GridMesh.ProsumerRegistry.Domain.Events.Meters;
using GridMesh.ProsumerRegistry.IntegrationEvents.IntegrationEvents.Meter;
using GridMesh.ProsumerRegistry.IntegrationEvents.Interfaces;

namespace GridMesh.ProsumerRegistry.IntegrationEvents.IntegrationEventFactories.Meter;

public class MeterActivationIntegrationEventFactory : IIntegrationDomainEventFactoryT<MeterActivatedDomainEvent>
{
    public string EventType => nameof(MeterActivatedIntegrationEvent);
    
    public string Topic => KafkaTopics.MeterActivated;

    public IDomainIntegrationEvent ToIntegrationEvent(IDomainEvent domainEvent)
        => ToIntegrationEvent((MeterActivatedDomainEvent)domainEvent);

    public IDomainIntegrationEvent ToIntegrationEvent(MeterActivatedDomainEvent domainEvent)
        => new MeterActivatedIntegrationEvent(
            domainEvent.EventId,
            domainEvent.ProsumerId,
            domainEvent.MeterId,
            domainEvent.FeederId,
            domainEvent.OccuredOn,
            domainEvent.SerialNumber);
}