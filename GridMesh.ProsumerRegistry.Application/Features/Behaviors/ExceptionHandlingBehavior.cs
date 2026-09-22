using GridMesh.ProsumerRegistry.Application.Features.CQRS;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GridMesh.ProsumerRegistry.Application.Features.Behaviors
{
    public class ExceptionHandlingBehavior<TRequest, TResponse>(
        ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : BaseRequest
    {
        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            try
            {
                return await next(cancellationToken);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                logger.LogWarning(
                    "Request {RequestType} was cancelled.",
                    typeof(TRequest).Name);

                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "Unhandled exception while handling request {RequestType}.",
                    typeof(TRequest).Name);
                throw;
            }
        }
    }
}