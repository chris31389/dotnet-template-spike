namespace WebApi.Infrastructure.Mongo;

public interface IMongoRepository
{
    Task AddItemAsync<T>(T item);
}