using MongoDB.Driver;

namespace Company.Infrastructure.Mongo;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMongoDb(this IServiceCollection services,
        string connectionStringName,
        string databaseName,
        string containerName
    ) => services
        .AddSingleton<IMongoClient>(s =>
        {
            var configuration = s.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString(connectionStringName);
            return new MongoClient(connectionString);
        })
        .AddTransient<IMongoDatabase>(s =>
        {
            var mongoClient = s.GetRequiredService<IMongoClient>();
            return mongoClient.GetDatabase(databaseName);
        })
        .AddTransient<IMongoRepository, MongoRepository>()
        .AddHealthChecks()
        .AddMongoDb(s =>
        {
            var configuration = s.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString(connectionStringName);
            return connectionString ??
                   throw new InvalidOperationException($"Connection string is missing, {connectionStringName}");
        })
        .Services;
}