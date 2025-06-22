namespace Mst.Core.Queries.Integration
{
    using MediatR;
    using Mst.Core.Queries.Entities;
    using Mst.Core.Queries.Infrastructure.Context;
    using Mst.SharedKernel.Common.Results;
    using Microsoft.EntityFrameworkCore;
    using Mst.Core.Contracts.Integrations.Responses;
    using Mst.SharedKernel.Common.Dtos;

    public class CustomerReviewQuery : IRequest<Result<PagedResponse<CustomerReviewResponseDto>>>
    {
    }
    public class CustomerReviewQueryHandler(
        IReadonlyIntegrationDbContext _integrationDbContext
    ) : IRequestHandler<CustomerReviewQuery, Result<PagedResponse<CustomerReviewResponseDto>>>
    {
        public async Task<Result<PagedResponse<CustomerReviewResponseDto>>> Handle(CustomerReviewQuery request, CancellationToken cancellationToken)
        {
            var customerReviews = await _integrationDbContext.AllOf<CustomerReview>().ToListAsync(cancellationToken);


            var mapped = customerReviews.Select(x => new CustomerReviewResponseDto
            {
                Id = x.Id,
                Uid = x.Uid,
                CustomerName = x.CustomerName,
                ReviewText = x.ReviewText,
                Rating = x.Rating,
                CreatedOn = x.CreatedOn
            }).ToList();

            return Result.Ok(new PagedResponse<CustomerReviewResponseDto>(
                totalRecords: mapped.Count,
                totalDisplayRecords: mapped.Count,
                data: mapped
            ));
        }
    }
}