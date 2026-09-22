using GridMesh.ProsumerRegistry.Domain.Common.Interfaces.Events;
using GridMesh.ProsumerRegistry.Domain.Entities;
using GridMesh.ProsumerRegistry.IntegrationEvents.Common.IntegrationEvents;
using GridMesh.ProsumerRegistry.IntegrationEvents.Interfaces;
using static GridMesh.ProsumerRegistry.IntegrationEvents.Common.Constants.ApplicationConstants;

namespace GridMesh.ProsumerRegistry.IntegrationEvents.Resources
{
    public class IntegrationEventMapping
    {
        private readonly Dictionary<
            Type,
            IntegrationEventMappingEntryRecord> _mappings = [];

        public IntegrationEventMapping(
            IEnumerable<IIntegrationDomainEventFactory> factories)
        {
            CreateMapping(factories);
        }

        private void CreateMapping(
            IEnumerable<IIntegrationDomainEventFactory> factories)
        {
            foreach (var factory in factories)
            {
                var factoryInterface = factory
                    .GetType()
                    .GetInterfaces()
                    .First(i =>
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() ==
                        typeof(IIntegrationDomainEventFactoryT<>));

                var domainEventType =
                    factoryInterface.GetGenericArguments()[0];

                _mappings.Add(
                    domainEventType,
                    new IntegrationEventMappingEntryRecord(factory.EventType,
                        (domainEvent) =>
                            new IntegrationEventMappingRecord(factory.ToIntegrationEvent(domainEvent),factory.Topic,
                                factory.EventType)));
            }
        }

        public IntegrationEventMappingRecord Map(IDomainEvent domainEvent)
        {
            if (!_mappings.TryGetValue(
                    domainEvent.GetType(),
                    out var mapper))
            {
                throw new InvalidOperationException(
                    $"{IntegrationEventMappingExceptionMessage}{domainEvent.GetType().Name}");
            }

            return mapper.Map(domainEvent);
        }
    }
}