using GridMesh.ProsumerRegistry.Domain.Common.Interfaces.Events;

namespace GridMesh.ProsumerRegistry.Domain.Events.Meters;

public class MeterActivatedDomainEvent : IDomainEvent
{
    public Guid EventId { get; set; }
    public Guid MeterId { get; set; }
    public Guid ProsumerId { get; set; }
    public Guid FeederId { get; set; }
    public string SerialNumber { get; set; }
    public DateTime OccuredOn { get; set; }

    public MeterActivatedDomainEvent(
        Guid meterId,
        Guid prosumerId,
        Guid feederId,
        string serialNumber,
        DateTime occuredOn, string topic)
    {
        MeterId = meterId;
        OccuredOn = occuredOn;
        ProsumerId = prosumerId;
        FeederId = feederId;
        SerialNumber = serialNumber;
    }
}