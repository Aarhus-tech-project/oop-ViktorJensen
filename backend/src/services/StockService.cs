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
        await _stockDataCollection.Find(stock => stock.Id == id).FirstOrDefaultAsync();
    public async Task<Stock?> GetBySymbolAsync(string symbol) =>
    await _stockDataCollection.Find(stock => stock.Symbol == symbol).FirstOrDefaultAsync();
    // public async Task<List<Stock>> GetTop500Async()
    // {
    //     return await _stockDataCollection
    //         .Find(_ => true)
    //         .SortByDescending(s => s.Price)
    //         .Limit(500)
    //         .ToListAsync();
    // }
    public async Task<List<Stock>> GetPagedAsync(int page, int pageSize)
    {
        return await _stockDataCollection
            .Find(_ => true)
            .Skip((page - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();
    }
}