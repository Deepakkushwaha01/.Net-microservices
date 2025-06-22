namespace Integration.Core.Persistence.Common.Sql.Context
{
    using Microsoft.EntityFrameworkCore;
    using Mst.Core.Persistence.Common.Sql.Configuration;
    using Mst.Core.Persistence.Common.Sql.Context;

    public class IntegrationDbContext : DbContext, IIntegrationDbContext
    {
        public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CustomerReviewConfiguration());
        }

        public void HealthCheck()
        {
            try
            {
                Database.OpenConnection();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Database.CloseConnection();
            }
        }
    }
}
