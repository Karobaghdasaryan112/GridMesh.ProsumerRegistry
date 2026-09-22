using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GridMesh.ProsumerRegistry.Infrastructure.Logging
{
    public class GridMeshLoggerProvider(LogChannel channel, IOptions<GridMeshLoggingOptions> options) : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, GridMeshLogger> _loggers =
            new();

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers
                .GetOrAdd(
                    categoryName,
                    category =>
                        new GridMeshLogger(category, options, channel));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}