namespace GridMesh.ProsumerRegistry.Application.Features.CQRS
{
    public abstract class BaseRequest
    {
        public Guid CorrelationId { get; set; }
    }
}