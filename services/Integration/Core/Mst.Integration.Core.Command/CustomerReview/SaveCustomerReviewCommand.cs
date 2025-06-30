using MediatR;
using Mst.Common.Packages.Results;
using Mst.Core.Contracts.Common.UnitOfWork;
using Mst.Core.Contracts.Integrations.Requests;
using Mst.Core.Domain.CustomerReview;
using Mst.Integration.Core.Persistence.CustomerReview.Repositories;

public record SaveCustomerReviewCommand(CustomerReviewRequestDto configuration) : IRequest<Result>
{
    public CustomerReviewRequestDto configuration { get; } = configuration;
}

public class SaveCustomerReviewCommandHandler(
ICustomerReviewRepo _customerReviewRepo,
IUnitOfWork _unitOfWork
) : IRequestHandler<SaveCustomerReviewCommand, Result>
{
    public async Task<Result> Handle(
    SaveCustomerReviewCommand command,
    CancellationToken cancellationToken = default)
    {
        CustomerReview CustomerReview = CustomerReview.Create(
            command.configuration.CustomerName,
            command.configuration.ReviewText,
            command.configuration.Rating);

        Result validatedOrError = CustomerReview.Validate();

        if (validatedOrError.IsFailure)
        {
            return Result.FromError<bool>(validatedOrError);
        }

        _customerReviewRepo.Insert(CustomerReview);
        await _unitOfWork.SaveAsync();


        return Result.Ok();
    }
}