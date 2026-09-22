using Microsoft.Extensions.Logging;

namespace GridMesh.ProsumerRegistry.Infrastructure.Logging;

public sealed record LogEntry(
    DateTime TimestampUtc,
    string ServiceName,
    string Layer,
    string Category,
    LogLevel Level,
    string Message,
    string? Exception,
    string? CorrelationId,   
    string? TraceId,         
    string PropertiesJson    
);