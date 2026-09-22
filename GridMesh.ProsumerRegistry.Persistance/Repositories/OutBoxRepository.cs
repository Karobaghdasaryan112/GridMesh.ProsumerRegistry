using GridMesh.ProsumerRegistry.Domain.Entities;
using GridMesh.ProsumerRegistry.Domain.Interfaces.Repositories;
using GridMesh.ProsumerRegistry.Persistance.Common.Repositories;
using GridMesh.ProsumerRegistry.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace GridMesh.ProsumerRegistry.Persistance.Repositories
{
    public class OutBoxMessageRepository(ProsumerRegistryDbContext context)
        : BaseRepository<OutboxMessage>(context), IOutBoxMessageRepository
    {
        public IReadOnlyList<OutboxMessage> GetUnPublishedOutboxMessages(CancellationToken cancellationToken)
            => Get(o => o.ProcessedOnUtc == null)
                .ToList()
                .AsReadOnly();
    }
}