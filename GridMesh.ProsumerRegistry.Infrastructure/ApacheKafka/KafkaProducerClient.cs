using Confluent.Kafka;
using GridMesh.ProsumerRegistry.Infrastructure.Interfaces;

namespace GridMesh.ProsumerRegistry.Infrastructure.ApacheKafka
{
    public class KafkaProducerClient : IKafkaProducerClient
    {
        private readonly IProducer<string, string> _producer;

        public KafkaProducerClient(KafkaOptions options)
        {
            var config = new ProducerConfig()
            {
                BootstrapServers = options.BootstrapServers,
            };

            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public async Task PublishAsync(string topic, string key, string message, CancellationToken cancellationToken)
            => await _producer.ProduceAsync(topic, new Message<string, string> { Key = key, Value = message },
                cancellationToken);
    }
}