namespace Mst.Core.Domain.Common.Entities
{
    using System;
    using Mst.Core.Domain.Common.Enums;

    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot()
        {
        }

        protected AggregateRoot(int id, Guid uid, DateTime createdOn, DateTime? deletedOn, EntityState state)
            : base(id, uid, createdOn, deletedOn, state)
        {
        }
    }
}
