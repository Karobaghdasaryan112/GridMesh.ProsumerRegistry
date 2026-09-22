using System.Linq.Expressions;
using GridMesh.ProsumerRegistry.Domain.Common.Entities.Base;
using GridMesh.ProsumerRegistry.Domain.Common.Interfaces.Repositories;
using GridMesh.ProsumerRegistry.Persistance.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GridMesh.ProsumerRegistry.Persistance.Common.Repositories
{
    public abstract class BaseRepository<TEntity>(ProsumerRegistryDbContext context) : IBaseRepository<TEntity>
    where TEntity : Entity
    {
        public IQueryable<TEntity> GetAll()
            => context.Set<TEntity>();

        public IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> predicate)
            => context
                .Set<TEntity>()
                .Where(predicate);

        public IQueryable<TEntity> GetById(Guid id)
            => context
                .Set<TEntity>()
                .Where(e => e.Id == id);

        public IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> predicate)
            => context
                .Set<TEntity>()
                .Where(predicate);

        public ValueTask<EntityEntry<TEntity>> CreateEntityAsync(TEntity entity,
            CancellationToken cancellationToken)
            => context.Set<TEntity>()
                .AddAsync(entity, cancellationToken);

        public Task UpdateEntityAsync(
            TEntity entity,
            CancellationToken cancellationToken)
            => Task.FromResult(context.Set<TEntity>().Update(entity));

        public Task DeleteEntityAsync(
            TEntity entity,
            CancellationToken cancellationToken)
            => Task.FromResult(context.Set<TEntity>().Remove(entity));
    }
}