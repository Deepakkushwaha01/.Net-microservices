namespace Mst.Core.Queries.Integration
{
    using MediatR;
    using Mst.Core.Queries.Entities;
    using Mst.Core.Queries.Infrastructure.Context;
    using Microsoft.EntityFrameworkCore;
    using Mst.Core.Contracts.Integrations.Responses;
    using Mst.Common.Packages.Results;
    using Mst.Common.Packages.Dtos;
    using Mst.Common.Packages.Extensions;

    public class CustomerReviewQuery : IRequest<Result<PagedResponse<CustomerReviewResponseDto>>>
    {
        public PaginatedRequest Request { get; }

        public CustomerReviewQuery(PaginatedRequest request)
        {
            Request = request;
        }
    }
    public class CustomerReviewQueryHandler(
        IReadonlyIntegrationDbContext _integrationDbContext
    ) : IRequestHandler<CustomerReviewQuery, Result<PagedResponse<CustomerReviewResponseDto>>>
    {
        public async Task<Result<PagedResponse<CustomerReviewResponseDto>>> Handle(CustomerReviewQuery request, CancellationToken cancellationToken)
        {
            IQueryable<CustomerReview> query = _integrationDbContext.AllOf<CustomerReview>();

            int totalRecords = await query.CountAsync(cancellationToken);

            query = query.ApplyPagination(request.Request);

            List<CustomerReviewResponseDto> mapped = await query.Select(x => new CustomerReviewResponseDto
            {
                Id = x.Id,
                Uid = x.Uid,
                CustomerName = x.CustomerName,
                ReviewText = x.ReviewText,
                Rating = x.Rating,
                CreatedOn = x.CreatedOn
            }).ToListAsync(cancellationToken);

            return Result.Ok(new PagedResponse<CustomerReviewResponseDto>(
                hasNextPage: request.Request.Limit + request.Request.Offset < totalRecords,
                totalRecords: totalRecords,
                totalDisplayRecords: mapped.Count,
                data: mapped
            ));
        }
    }
}