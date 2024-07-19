using MongoDB.Driver;

namespace Company.Infrastructure.Mongo;

public class MongoRepository(IMongoClient mongoClient, string databaseName) : IMongoRepository
{
    private readonly IMongoDatabase _database = mongoClient.GetDatabase(databaseName);

    public async Task AddItemAsync<T>(T item) => await Task.CompletedTask;
}