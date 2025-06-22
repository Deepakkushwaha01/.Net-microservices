using External.API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mst.API.Statics;
using Mst.Core.Contracts.Integrations.Requests;

namespace Mst.Integration.Services.API.Controllers.CustomerReview
{
    [ApiVersion(ApiVersions.ApiVersion1_0)]
    [ApiController]
    [Route("api/v{version:apiVersion}/customer-review")]
    public class CustomerReviewController : ExtendedApiController
    {
        private readonly IMediator _mediator;
        public CustomerReviewController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        /// <summary>
        /// Save a customer review
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SaveCustomerReview([FromBody] CustomerReviewRequestDto request)
        {

            return OkOrError(await _mediator.Send(new SaveCustomerReviewCommand(request)));
        }
    }
}