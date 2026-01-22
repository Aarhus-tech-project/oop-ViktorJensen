using backend.src.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace backend.src.services;

public class StocksService
{
    private readonly IMongoCollection<Stock> _stockDataCollection;
    public StocksService(
        IOptions<MongoDbSettings> MongoDbSettings)
    {
        var mongoClient = new MongoClient(
            MongoDbSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(
            MongoDbSettings.Value.DatabaseName);
        _stockDataCollection = mongoDatabase.GetCollection<Stock>(
            MongoDbSettings.Value.StockCollectionName);
    }
    public async Task<List<Stock>> GetAsync() =>
        await _stockDataCollection.Find(_ => true).ToListAsync();
    public async Task<Stock?> GetAsync(string id) =>
        await _stockDataCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    public async Task<Stock?> GetBySymbolAsync(string symbol) =>
    await _stockDataCollection.Find(x => x.Symbol == symbol).FirstOrDefaultAsync();
}