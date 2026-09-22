using System.Text.Json;
using GridMesh.ProsumerRegistry.Domain.Common.Entities.Base;
using GridMesh.ProsumerRegistry.Domain.Common.Interfaces.Repositories;
using GridMesh.ProsumerRegistry.Domain.Common.Results;
using GridMesh.ProsumerRegistry.Domain.Entities;
using GridMesh.ProsumerRegistry.IntegrationEvents.Resources;
using GridMesh.ProsumerRegistry.Persistance.Data;
using MediatR;

namespace GridMesh.ProsumerRegistry.Persistance.Repositories
{
    public class UnitOfWork(
        ProsumerRegistryDbContext context,
        IntegrationEventMapping integrationEventMapper,
        IPublisher mediator)
        : IUnitOfWork
    {
        public async Task<Result> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var aggregatesWithEvents = context.ChangeTracker
                .Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Count != 0)
                .ToList();

            var allDomainEvents = aggregatesWithEvents
                .SelectMany(a => a.DomainEvents)
                .ToList();

            var outBoxMessages = allDomainEvents
                .Select(integrationEventMapper.Map)
                .Where(a =>
                    a.Event?.EventId != Guid.Empty &&
                    !string.IsNullOrEmpty(a.EventType))
                .Select(a => new OutboxMessage
                {
                    Id = Guid.NewGuid(),
                    Type = a.EventType,
                    Content = JsonSerializer.Serialize(a.Event),
                    OccurredOnUtc = a!.Event.OccuredOnUtc,
                    Topic = a.Topic,
                }).ToList();

            foreach (var aggregateWithEvent in aggregatesWithEvents)
                aggregateWithEvent.ClearDomainEvents();

            if (outBoxMessages.Count > 0)
                await context.Set<OutboxMessage>().AddRangeAsync(outBoxMessages!, cancellationToken);

            var resultCount = await context.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in allDomainEvents)
            {
                if (domainEvent is INotification notification)
                    await mediator.Publish(notification, cancellationToken);
            }

            return resultCount == 0
                ? Result.Failure(Error.Failure(
                    code: "Database.NoChanges",
                    message: "No changes were made to the database."))
                : Result.Success();
        }
    }
}