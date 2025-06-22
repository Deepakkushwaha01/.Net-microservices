

namespace Mst.Integration.Core.Persistence.Common.Sql.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Mst.Core.Persistence.Common.Sql.Context;
    using Mst.Integration.Core.Persistence.Common.Sql.Entity;
    using Mst.SharedKernel.Common.Results;

    public class Repository<TAggregate> : IRepository<TAggregate> where TAggregate : Entity
    {
        protected readonly IIntegrationDbContext _integrationDbContext;

        protected readonly DbSet<TAggregate> _dbSet;

        public Repository(IIntegrationDbContext integrationDbContext)
        {
            _integrationDbContext = integrationDbContext;
            _dbSet = _integrationDbContext.Set<TAggregate>();
        }
        public virtual void Insert(TAggregate entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbSet.Add(entity);
        }

        public virtual void Delete(TAggregate entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbSet.Remove(entity);
        }

        public virtual IQueryable<TAggregate> AllNoTrackedOf()
        {
            return _dbSet.AsNoTracking();
        }

        public virtual async Task<Result> SaveChangesAsync()
        {
            try
            {
                await _integrationDbContext.SaveChangesAsync();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Failed(ex.Message);
            }
        }

        public void Dispose()
        {
            _integrationDbContext?.Dispose();
        }
    }
}