namespace GridMesh.ProsumerRegistry.Domain.Common.Entities.Base;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }

    protected Entity(Guid id)
    {
        Id = id;
    }

    protected Entity()
    {
    }

    public bool Equals(Entity? other)
        => other is not null && (ReferenceEquals(this, other) || Id == other.Id);

    protected void Touch() => UpdatedAt = DateTime.UtcNow;

    public override bool Equals(object? obj) => Equals(obj as Entity);

    public override int GetHashCode() => Id.GetHashCode();

}