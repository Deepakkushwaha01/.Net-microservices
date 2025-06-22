using Mst.Core.Contracts.Common.UnitOfWork;
using Mst.Core.Persistence.Common.Sql.Context;
using Mst.SharedKernel.Common.Results;

namespace External.Core.Persistence.Common.UnitOfWork
{


    public class UnitOfWork : IUnitOfWork
    {
        private readonly IIntegrationDbContext _integrationDbContext;


        public UnitOfWork(IIntegrationDbContext integrationDbContext)
        {
            _integrationDbContext = integrationDbContext;
        }

        public Task<Result> SaveAsync()
        {
            return SaveChanges();
        }

        private async Task<Result> SaveChanges()
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

    }
}
