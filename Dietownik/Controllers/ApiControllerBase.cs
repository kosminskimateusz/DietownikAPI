using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain;
using Dietownik.ApplicationServices.API.ErrorHandling;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dietownik.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<ApiControllerBase> logger;

        protected ApiControllerBase(IMediator mediator, ILogger<ApiControllerBase> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<TResponse>
        where TResponse : ErrorResponseBase
        {
            if (!this.ModelState.IsValid)
            {
                var errors = this.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new { errors = x.Value.Errors }).ToList();
                foreach (var err in errors)
                    logger.LogInformation($"{err.errors[0].ErrorMessage}");

                return this.BadRequest(
                    this.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new { property = x.Key, errors = x.Value.Errors }));
            }

            var userName = this.User.FindFirstValue(ClaimTypes.Name);

            var response = await this.mediator.Send(request);

            if (response.Error != null)
            {
                logger.LogInformation($"{response.Error.Error}");
                return this.ErrorResponse(response.Error);
            }

            return this.Ok(response);
        }

        protected async Task<IActionResult> HandleRequestWithoutResponseBody<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<TResponse>
        where TResponse : ErrorResponseBase
        {
            if (!this.ModelState.IsValid)
            {
                var errors = this.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new { errors = x.Value.Errors }).ToList();
                foreach (var err in errors)
                    logger.LogInformation($"{err.errors[0].ErrorMessage}");

                return this.BadRequest(
                    this.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new { property = x.Key, errors = x.Value.Errors }));
            }

            var response = await this.mediator.Send(request);

            if (response.Error != null)
            {
                logger.LogInformation($"{response.Error.Error}");
                return this.ErrorResponse(response.Error);
            }

            return this.Ok();
        }

        private IActionResult ErrorResponse(ErrorModel errorModel)
        {
            var httpCode = GetHttpStatusCode(errorModel.Error);
            return StatusCode((int)httpCode, errorModel);
        }

        private static HttpStatusCode GetHttpStatusCode(string errorType)
        {
            switch (errorType)
            {
                case ErrorType.ValidationError:
                    return HttpStatusCode.BadRequest;
                case ErrorType.NotFound:
                    return HttpStatusCode.NotFound;
                case ErrorType.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                case ErrorType.NotAuthenticated:
                    return HttpStatusCode.NetworkAuthenticationRequired;
                case ErrorType.Unauthorized:
                    return HttpStatusCode.Unauthorized;
                case ErrorType.UnsupportedMediaType:
                    return HttpStatusCode.UnsupportedMediaType;
                case ErrorType.UnsupportedMethod:
                    return HttpStatusCode.MethodNotAllowed;
                case ErrorType.RequestTooLarge:
                    return HttpStatusCode.RequestEntityTooLarge;
                case ErrorType.TooManyRequests:
                    return HttpStatusCode.TooManyRequests;
                default:
                    return HttpStatusCode.BadRequest;
            }
        }
    }
}