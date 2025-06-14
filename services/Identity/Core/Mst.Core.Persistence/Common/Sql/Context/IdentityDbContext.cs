namespace Identity.Core.Persistence.Common.Sql.Context
{
    using External.Core.Persistence.Common.Sql.Context;
    using Microsoft.EntityFrameworkCore;
    public class IdentityDbContext : DbContext, IIdentityDbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add any additional model configurations here
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
