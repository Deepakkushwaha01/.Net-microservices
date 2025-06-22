namespace Mst.Core.Domain.Common.Entities
{
    using System;
    using Mst.Core.Domain.Common.Enums;

    public abstract class Entity
    {
        public int Id { get; protected set; }

        public Guid Uid { get; protected set; }

        public DateTime CreatedOn { get; protected set; }

        public DateTime? DeletedOn { get; protected set; }

        public EntityState State { get; protected set; }

        public bool IsStateChanged => State != EntityState.Unchanged;

        protected Entity()
        {
        }

        protected Entity(int id, Guid uid, DateTime createdOn, DateTime? deletedOn, EntityState state)
        {
            Id = id;
            Uid = uid;
            CreatedOn = createdOn;
            DeletedOn = deletedOn;
            State = state;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public void MarkModified()
        {
            State = EntityState.Modified;
        }

        public void MarkDeleted(DateTime deletedOn)
        {
            DeletedOn = deletedOn;

            MarkModified();
        }
    }
}
