using System.Collections.ObjectModel;
using GridMesh.ProsumerRegistry.Domain.Common.Interfaces.Repositories;
using GridMesh.ProsumerRegistry.Domain.Entities;

namespace GridMesh.ProsumerRegistry.Domain.Interfaces.Repositories;

public interface IOutBoxMessageRepository : IBaseRepository<OutboxMessage>
{
    IReadOnlyList<OutboxMessage> GetUnPublishedOutboxMessages(CancellationToken cancellationToken);
}