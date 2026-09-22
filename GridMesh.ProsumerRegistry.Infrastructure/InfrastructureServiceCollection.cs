using GridMesh.ProsumerRegistry.Infrastructure.ApacheKafka;
using GridMesh.ProsumerRegistry.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static GridMesh.ProsumerRegistry.Infrastructure.Constants.Configurations;

namespace GridMesh.ProsumerRegistry.Infrastructure;

public static class InfrastructureServiceCollection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<KafkaOptions>(
            configuration.GetSection(KafkaSectionName));

        services.AddSingleton<IKafkaProducerClient, KafkaProducerClient>();

        return services;
    }
}