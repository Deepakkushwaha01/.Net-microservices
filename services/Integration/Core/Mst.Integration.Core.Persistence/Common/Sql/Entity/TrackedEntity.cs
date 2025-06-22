namespace Mst.Integration.Core.Persistence.Common.Sql.Entity
{
    public class TrackedEntity : Entity
    {
        public string? CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }
    }
}