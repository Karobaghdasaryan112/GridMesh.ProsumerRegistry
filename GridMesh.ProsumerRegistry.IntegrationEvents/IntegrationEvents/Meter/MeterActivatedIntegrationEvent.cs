using GridMesh.ProsumerRegistry.Domain.Common.Interfaces.Events;
using GridMesh.ProsumerRegistry.IntegrationEvents.Interfaces;

namespace GridMesh.ProsumerRegistry.IntegrationEvents.IntegrationEvents.Meter;

public class MeterActivatedIntegrationEvent(
    Guid eventId,
    Guid prosumerId,
    Guid meterId,
    Guid feederId,
    DateTime occuredOn,
    string serialNumber)
    : IDomainIntegrationEvent
{
    public Guid MeterId { get; set; } = meterId;
    public Guid ProsumerId { get; set; } = prosumerId;
    public Guid FeederId { get; set; } = feederId;
    public string SerialNumber { get; set; } = serialNumber;
    public Guid EventId { get; set; } = eventId;
    public DateTime OccuredOnUtc { get; set; } = occuredOn;
}