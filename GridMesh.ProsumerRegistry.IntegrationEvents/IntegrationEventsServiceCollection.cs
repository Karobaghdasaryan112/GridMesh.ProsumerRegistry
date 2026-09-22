using GridMesh.ProsumerRegistry.IntegrationEvents.IntegrationEventFactories.Meter;
using GridMesh.ProsumerRegistry.IntegrationEvents.Interfaces;
using GridMesh.ProsumerRegistry.IntegrationEvents.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace GridMesh.ProsumerRegistry.IntegrationEvents
{
    public static class IntegrationEventsServiceCollection
    {
        public static IServiceCollection AddIntegrationEvents(this IServiceCollection services)
        {
            services.AddSingleton<IIntegrationDomainEventFactory, MeterActivationIntegrationEventFactory>();
            services.AddSingleton<IntegrationEventMapping>();

            return services;
        }
    }
}