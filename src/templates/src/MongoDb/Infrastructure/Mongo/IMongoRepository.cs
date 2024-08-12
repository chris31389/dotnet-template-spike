namespace Company.Infrastructure.Mongo;

public interface IMongoRepository
{
    Task AddItemAsync<T>(T item);
}