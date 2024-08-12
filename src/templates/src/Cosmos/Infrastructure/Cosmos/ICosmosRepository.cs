namespace Company.Infrastructure.Cosmos;

public interface ICosmosRepository
{
    Task AddItemAsync<T>(T item);
}