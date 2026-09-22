using GridMesh.ProsumerRegistry.Application.Features.CQRS;
using GridMesh.ProsumerRegistry.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GridMesh.ProsumerRegistry.Application.Features.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger, ICorrelationContext correlationContext)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : BaseRequest
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            using var scope = logger.BeginScope(new Dictionary<string, object>
            {
                ["CorrelationId"] = correlationContext.CorrelationId,
                ["Request"] = typeof(TRequest).Name
            });

            logger.LogInformation(
                "Handling request {RequestType}.",
                typeof(TRequest).Name);

            var response = await next(cancellationToken);

            logger.LogInformation(
                "Successfully handled request {RequestType}.",
                typeof(TRequest).Name);

            return response;
        }
    }
}