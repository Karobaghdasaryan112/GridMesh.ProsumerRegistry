using GridMesh.ProsumerRegistry.Domain.Common.Results;

namespace GridMesh.ProsumerRegistry.Domain.Common.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<Result> SaveChangesAsync(CancellationToken cancellationToken);
    }
}