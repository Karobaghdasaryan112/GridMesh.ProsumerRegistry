using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GridMesh.ProsumerRegistry.Infrastructure.Logging
{
    public class GridMeshLogger(
        string categoryName,
        IOptions<GridMeshLoggingOptions> options,
        LogChannel channel) : ILogger, ISupportExternalScope
    {
        private IExternalScopeProvider? _scopeProvider;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            var message = formatter(state, exception);

            var entry = new LogEntry(
                TimestampUtc: DateTime.UtcNow,
                ServiceName: options.Value.ServiceName,
                Layer: LogLayerResolver.Resolve(categoryName),
                Category: categoryName,
                Level: logLevel,
                Message: message,
                Exception: exception?.ToString(),
                CorrelationId: null,
                TraceId: Activity.Current?.TraceId.ToString(),
                PropertiesJson: "{}"
            );

            channel.TryEnqueue(entry);
        }

        public bool IsEnabled(LogLevel logLevel)
            => logLevel != LogLevel.None;

        public IDisposable BeginScope<TState>(TState state)
            where TState : notnull
            => _scopeProvider?.Push(state)!;

        private sealed class NullScope : IDisposable
        {
            public static readonly NullScope Instance = new();

            public void Dispose()
            {
            }
        }

        public void SetScopeProvider(IExternalScopeProvider scopeProvider)
        {
            _scopeProvider = scopeProvider;
        }
    }
}