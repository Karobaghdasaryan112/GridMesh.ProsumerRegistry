using GridMesh.ProsumerRegistry.Application.Interfaces;

namespace GridMesh.ProsumerRegistry.Application.Services;

public class CorrelationContext : ICorrelationContext
{
    public Guid CorrelationId { get; set; } = Guid.NewGuid();
}