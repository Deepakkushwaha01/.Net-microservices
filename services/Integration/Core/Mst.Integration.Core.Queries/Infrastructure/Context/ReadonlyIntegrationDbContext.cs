namespace Mst.Core.Queries.Infrastructure.Context
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Mst.Core.Queries.Entities;

    public class ReadonlyIntegrationDbContext : DbContext, IReadonlyIntegrationDbContext
    {
        public ReadonlyIntegrationDbContext(DbContextOptions<ReadonlyIntegrationDbContext> options)
            : base(options) { }

        public IQueryable<Entity> AllOf<Entity>() where Entity : BaseEntity
        {
            return SetOf<Entity>();
        }

        public IQueryable<Entity> SetOf<Entity>() where Entity : class
        {
            return Set<Entity>().AsNoTracking();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntity).Assembly);

            IEnumerable<IMutableEntityType> baseEntities = modelBuilder.Model.GetEntityTypes()
                    .Where(entityType => typeof(BaseEntity).IsAssignableFrom(entityType.ClrType));

        }
    }
}