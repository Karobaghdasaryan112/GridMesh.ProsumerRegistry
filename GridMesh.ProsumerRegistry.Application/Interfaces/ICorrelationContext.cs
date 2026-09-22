namespace GridMesh.ProsumerRegistry.Application.Interfaces
{
    public interface ICorrelationContext
    {
        Guid CorrelationId { get; set; }
    }
}