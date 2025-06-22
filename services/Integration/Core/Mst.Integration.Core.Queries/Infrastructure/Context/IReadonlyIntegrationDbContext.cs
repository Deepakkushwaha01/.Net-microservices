namespace Mst.Core.Queries.Infrastructure.Context
{
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Mst.Core.Queries.Entities;

    public interface IReadonlyIntegrationDbContext : IDisposable
    {
        ChangeTracker ChangeTracker { get; }

        IQueryable<Entity> SetOf<Entity>() where Entity : class;

        IQueryable<Entity> AllOf<Entity>() where Entity : BaseEntity;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}