using GridMesh.ProsumerRegistry.Application.Interfaces;

namespace GridMesh.ProsumerRegistery.Middleware
{
    public class CorrelationIdMiddleware(RequestDelegate next)
    {
        private const string HeaderName = "X-Correlation-Id";

        public async Task InvokeAsync(HttpContext context, ICorrelationContext correlationContext)
        {
            var correlationId = context.Request.Headers.TryGetValue(HeaderName, out var value)
                ? Guid.Parse(value!)
                : Guid.NewGuid();

            correlationContext.CorrelationId = correlationId;
            context.Response.Headers[HeaderName] = correlationId.ToString();

            await next(context);
        }
    }
}