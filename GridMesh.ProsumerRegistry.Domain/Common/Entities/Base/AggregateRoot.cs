using GridMesh.ProsumerRegistry.Domain.Common.Interfaces.Events;

namespace GridMesh.ProsumerRegistry.Domain.Common.Entities.Base;

public class AggregateRoot : Entity, IHasDomainEvents
{
    public IReadOnlyCollection<IDomainEvent> DomainEvents  => _domainEvents.AsReadOnly();
    private readonly List<IDomainEvent> _domainEvents = [];

    protected AggregateRoot(Guid id) : base(id) { }

    protected AggregateRoot() { }
    
    public void ClearDomainEvents() => _domainEvents.Clear();

    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}