using System.Threading.Channels;
using GridMesh.ProsumerRegistry.Infrastructure.Interfaces;

namespace GridMesh.ProsumerRegistry.Infrastructure.Logging
{
    public class LogChannel : ILogChannel, IDisposable
    {
        private readonly Channel<LogEntry> _channel = Channel.CreateBounded<LogEntry>(
            new BoundedChannelOptions(capacity: 50_000)
            {
                FullMode = BoundedChannelFullMode.DropOldest,
                SingleReader = true,
                SingleWriter = false
            });

        public bool TryEnqueue(LogEntry entry)
        {
            return _channel.Writer.TryWrite(entry);
        }

        public IAsyncEnumerable<LogEntry> ReadAllAsync()
        {
            return _channel.Reader.ReadAllAsync();
        }

        public void Dispose()
        {
            _channel.Writer.Complete();
        }
    }
}