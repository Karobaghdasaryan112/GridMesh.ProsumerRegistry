namespace GridMesh.ProsumerRegistry.Domain.Common.Interfaces.Events;

public interface IHasDomainEvents
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    void ClearDomainEvents();
}