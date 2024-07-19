using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;

namespace WebApi.Infrastructure.Cosmos;

public class CosmosRepository(CosmosClient cosmosClient, string databaseName, string containerName)
    : ICosmosRepository
{
    private readonly Container _container = cosmosClient.GetContainer(databaseName, containerName);

    public async Task AddItemAsync<T>(T item) => await Task.CompletedTask;
}