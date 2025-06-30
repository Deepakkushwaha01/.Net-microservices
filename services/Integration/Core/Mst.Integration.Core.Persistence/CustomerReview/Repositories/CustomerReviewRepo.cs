namespace Mst.Integration.Core.Persistence.CustomerReview.Repositories
{
    using Mst.Common.Packages.Results;
    using Mst.Core.Persistence.Common.Sql.Context;
    using Mst.Core.Persistence.CustomerReview.Entity;
    using Mst.Core.Persistence.CustomerReview.Factory;
    using Mst.Integration.Core.Persistence.Common.Sql.Repository;

    /// <summary>
    /// Repository for managing customer reviews.
    /// </summary>
    public class CustomerReviewRepo : Repository<CustomerReview>, ICustomerReviewRepo
    {
        public CustomerReviewRepo(IIntegrationDbContext dbContext) : base(dbContext)
        {
        }

        public Result Insert(Mst.Core.Domain.CustomerReview.CustomerReview customerReview)
        {
            Insert(customerReview.ToCustomerReviewEntity());
            return Result.Ok();
        }

        // Additional methods specific to CustomerReview can be added here
    }
}