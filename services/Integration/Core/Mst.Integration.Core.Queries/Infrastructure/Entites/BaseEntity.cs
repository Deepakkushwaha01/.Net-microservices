[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Mst.Core.Queries.Tests")]

namespace Mst.Core.Queries.Entities
{
    public class BaseEntity
    {
        public int Id { get; protected internal set; }

        public DateTime CreatedOn { get; protected internal set; }

        public DateTime? DeletedOn { get; protected internal set; }
    }
}