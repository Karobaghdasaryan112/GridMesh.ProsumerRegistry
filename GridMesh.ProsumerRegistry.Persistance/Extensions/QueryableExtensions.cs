using Microsoft.EntityFrameworkCore;

namespace GridMesh.ProsumerRegistry.Persistance.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> AsNoTracking<TEntity>(
            this IQueryable<TEntity> query)
            where TEntity : class
            => EntityFrameworkQueryableExtensions.AsNoTracking(query);

        public static Task<List<TEntity>> ToListAsync<TEntity>(
            this IQueryable<TEntity> query,
            CancellationToken cancellationToken = default)
            where TEntity : class
            => EntityFrameworkQueryableExtensions.ToListAsync(
                query,
                cancellationToken);

        public static Task<TEntity?> FirstOrDefaultAsync<TEntity>(
            this IQueryable<TEntity> query,
            CancellationToken cancellationToken = default)
            where TEntity : class
            => EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(
                query,
                cancellationToken);

        public static Task<bool> AnyAsync<TEntity>(
            this IQueryable<TEntity> query,
            CancellationToken cancellationToken = default)
            where TEntity : class
            => EntityFrameworkQueryableExtensions.AnyAsync(
                query,
                cancellationToken);

        public static Task<int> CountAsync<TEntity>(
            this IQueryable<TEntity> query,
            CancellationToken cancellationToken = default)
            where TEntity : class
            => EntityFrameworkQueryableExtensions.CountAsync(
                query,
                cancellationToken);
    }
}