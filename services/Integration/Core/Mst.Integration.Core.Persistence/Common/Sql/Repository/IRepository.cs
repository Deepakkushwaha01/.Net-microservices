namespace Mst.Integration.Core.Persistence.Common.Sql.Repository
{
    using Mst.Integration.Core.Persistence.Common.Sql.Entity;
    public interface IRepository<TAggregate> : IDisposable where TAggregate : Entity
    {
        IQueryable<TAggregate> AllNoTrackedOf();

        void Insert(TAggregate entity);

        void Delete(TAggregate entity);
    }
}