namespace Mst.Core.Persistence.Common.Sql.Context
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    public interface IIntegrationDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        ChangeTracker ChangeTracker { get; }

        void HealthCheck();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}