using GridMesh.ProsumerRegistry.Domain.Entities;
using GridMesh.ProsumerRegistry.Domain.Interfaces.Repositories;
using GridMesh.ProsumerRegistry.Infrastructure.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GridMesh.ProsumerRegistry.Infrastructure.BackgroundServices
{
    public class OutboxMessagePublisherBackgroundService(
        IOutBoxMessageRepository outBoxMessageRepository,
        IKafkaProducerClient kafkaProducerClient,
        ILogger<OutboxMessagePublisherBackgroundService> logger,
        PeriodicTimer timer)
        : IHostedService, IDisposable
    {
        private PeriodicTimer _timer = timer;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var timer = new PeriodicTimer(TimeSpan.FromSeconds(5));

            while (await timer.WaitForNextTickAsync(cancellationToken))
            {
                await PrepareAsync(cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Dispose();
            return Task.CompletedTask;
        }

        private async Task PrepareAsync(CancellationToken cancellationToken)
        {
            var messages = outBoxMessageRepository.GetUnPublishedOutboxMessages(cancellationToken);

            foreach (var message in messages)
                await kafkaProducerClient.PublishAsync(
                    topic: message.Topic,
                    key: message.Id.ToString(),
                    message: message.Content,
                    cancellationToken: cancellationToken);

            foreach (var message in messages)
                message.ProcessedOnUtc = DateTime.UtcNow;
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}