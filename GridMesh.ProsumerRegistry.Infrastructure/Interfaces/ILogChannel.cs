using GridMesh.ProsumerRegistry.Infrastructure.Logging;

namespace GridMesh.ProsumerRegistry.Infrastructure.Interfaces
{
    public interface ILogChannel
    {
        IAsyncEnumerable<LogEntry> ReadAllAsync();

        bool TryEnqueue(LogEntry entry);
    }
}