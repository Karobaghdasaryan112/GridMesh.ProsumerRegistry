namespace GridMesh.ProsumerRegistry.Infrastructure.Interfaces
{
    public interface IKafkaProducerClient
    {
        Task PublishAsync(
            string topic,
            string key,
            string message,
            CancellationToken cancellationToken);
    }
}