using System.Linq.Expressions;
using GridMesh.ProsumerRegistry.Domain.Common.Entities.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GridMesh.ProsumerRegistry.Domain.Common.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : Entity
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetById(Guid id);

        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> predicate);

        ValueTask<EntityEntry<TEntity>> CreateEntityAsync(TEntity entity,
            CancellationToken cancellationToken);

        Task UpdateEntityAsync(
            TEntity entity,
            CancellationToken cancellationToken);

        Task DeleteEntityAsync(
            TEntity entity,
            CancellationToken cancellationToken);
    }
}