namespace External.API.Controllers
{
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Primitives;
    using Mst.Common.Packages.Results;

    public class ExtendedApiController : ControllerBase
    {

        protected static HttpStatusCode GetStatusCode(ResultType resultType)
        {
            HttpStatusCode statusCode;

            switch (resultType)
            {
                case ResultType.NotFound:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case ResultType.Forbidden:
                    statusCode = HttpStatusCode.Forbidden;
                    break;
                case ResultType.Conflicted:
                    statusCode = HttpStatusCode.Conflict;
                    break;
                case ResultType.Invalid:
                    statusCode = HttpStatusCode.NotAcceptable;
                    break;
                case ResultType.Unauthorized:
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            return statusCode;
        }

        protected IActionResult OkOrError<T>(Result<T> result)
        {
            IActionResult? errorResponse = GetErrorResponse(result);

            if (errorResponse != null)
            {
                return errorResponse;
            }

            return Ok(result.Value);
        }

        protected IActionResult OkOrError(ResultCommonLogic result)
        {
            IActionResult? errorResponse = GetErrorResponse(result);

            if (errorResponse != null)
            {
                return errorResponse;
            }

            return Ok();
        }

        private IActionResult? GetErrorResponse(ResultCommonLogic result)
        {
            if (result.IsFailure)
            {
                HttpStatusCode statusCode = GetStatusCode(result.ResultType);

                ObjectResult errorResponse = new(result.Message)
                {
                    StatusCode = (int)statusCode
                };

                return errorResponse;
            }

            return null;
        }

        protected string? GetTokenFromRequest(HttpRequest request)
        {
            if (request.Cookies.TryGetValue("AccessToken", out string? cookieToken))
            {
                return cookieToken;
            }
            else if (request.Headers.TryGetValue("Authorization", out StringValues bearerToken))
            {
                return bearerToken.ToString().Replace("Bearer", string.Empty).Trim();
            }
            else if (request.Query.TryGetValue("access_token", out StringValues queryToken))
            {
                return queryToken;
            }
            else
            {
                return null;
            }
        }
    }
}
