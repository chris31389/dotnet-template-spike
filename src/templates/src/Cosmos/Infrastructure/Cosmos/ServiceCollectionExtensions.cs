using HealthChecks.CosmosDb;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;

namespace Company.Infrastructure.Cosmos;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCosmos(this IServiceCollection services,
        string connectionStringName,
        string databaseName,
        string containerName
    ) => services
        .AddSingleton<CosmosClient>(s =>
        {
            var configuration = s.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString(connectionStringName);
            return new CosmosClientBuilder(connectionString)
                .Build();
        })
        .AddSingleton<ICosmosRepository, CosmosRepository>(s =>
        {
            var cosmosClient = s.GetRequiredService<CosmosClient>();
            return new CosmosRepository(cosmosClient, databaseName, containerName);
        })
        .AddHealthChecks()
        .AddAzureCosmosDB(optionsFactory: s => new AzureCosmosDbHealthCheckOptions
        {
            DatabaseId = databaseName
        }, timeout: TimeSpan.FromSeconds(10))
        .Services;
}