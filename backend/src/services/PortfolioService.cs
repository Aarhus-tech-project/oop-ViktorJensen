using backend.src.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace backend.src.services;

public class PortfolioService
{
    private readonly IMongoCollection<Portfolio> _portfolioCollection;
    private readonly StocksService _stocksService;
    public PortfolioService(
        IOptions<MongoDbSettings> mongoDbSettings,
        StocksService stocksService)
    {
        _stocksService = stocksService;
        var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
        
        _portfolioCollection = mongoDatabase.GetCollection<Portfolio>(
        mongoDbSettings.Value.PortfolioCollectionName);
    }
    public async Task<List<Portfolio>> GetUserPortfolioAsync(string userId)
    {
        try
        {
            var portfolios = await _portfolioCollection
            .Find(x => x.UserId == userId)
            .ToListAsync();
            return portfolios;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<Portfolio> AddToPortfolioAsync(Portfolio portfolio)
    {
        await _portfolioCollection.InsertOneAsync(portfolio);
        return portfolio;
    }
    public async Task UpdatePortfolioAsync(string id, Portfolio portfolio)
    {
        await _portfolioCollection.ReplaceOneAsync(
            x => x.Id == id, portfolio);
    }
    public async Task<bool> RemoveFromPortfolioAsync(string id)
    {
        var result = await _portfolioCollection.DeleteOneAsync(x => x.Id == id);
        return result.DeletedCount > 0;
    }
    public async Task<PortfolioSummary> GetPortfolioSummaryAsync(string userId)
    {
        var portfolios = await GetUserPortfolioAsync(userId);
        return new PortfolioSummary
        {
            UserId = userId,
            Holdings = portfolios,
        };
    }
}
