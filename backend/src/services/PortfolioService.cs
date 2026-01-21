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
        
        _portfolioCollection = mongoDatabase.GetCollection<Portfolio>("portfolios");
    }

    // Get all stocks in a user's portfolio
    public async Task<List<Portfolio>> GetUserPortfolioAsync(string userId)
    {
        var portfolios = await _portfolioCollection
            .Find(x => x.UserId == userId)
            .ToListAsync();

        // Update current prices from stock_data collection
        foreach (var portfolio in portfolios)
        {
            var stock = await _stocksService.GetBySymbolAsync(portfolio.StockSymbol);
            if (stock != null)
            {
                portfolio.CurrentPrice = (int)stock.price;
            }
        }

        return portfolios;
    }

    // Add stock to portfolio
    public async Task<Portfolio> AddToPortfolioAsync(Portfolio portfolio)
    {
        portfolio.PurchaseDate = DateTime.UtcNow;
        await _portfolioCollection.InsertOneAsync(portfolio);
        return portfolio;
    }

    // Update portfolio holding
    public async Task UpdatePortfolioAsync(string id, Portfolio portfolio)
    {
        await _portfolioCollection.ReplaceOneAsync(
            x => x.Id == id, portfolio);
    }

    // Remove stock from portfolio
    public async Task<bool> RemoveFromPortfolioAsync(string id)
    {
        var result = await _portfolioCollection.DeleteOneAsync(x => x.Id == id);
        return result.DeletedCount > 0;
    }

    // Get portfolio summary with gains/losses
    public async Task<PortfolioSummary> GetPortfolioSummaryAsync(string userId)
    {
        var portfolios = await GetUserPortfolioAsync(userId);
        
        var totalInvested = portfolios.Sum(p => p.PurchasePrice * p.Quantity);
        var totalCurrentValue = portfolios.Sum(p => p.CurrentPrice * p.Quantity);
        var totalGainLoss = totalCurrentValue - totalInvested;
        var gainLossPercent = totalInvested != 0 ? totalGainLoss / totalInvested * 100 : 0;

        return new PortfolioSummary
        {
            UserId = userId,
            Holdings = portfolios,
            TotalInvested = totalInvested,
            TotalCurrentValue = totalCurrentValue,
            TotalGainLoss = totalGainLoss,
            GainLossPercent = gainLossPercent
        };
    }
}

public class PortfolioSummary
{
    public string UserId { get; set; } = null!;
    public List<Portfolio> Holdings { get; set; } = [];
    public decimal TotalInvested { get; set; }
    public decimal TotalCurrentValue { get; set; }
    public decimal TotalGainLoss { get; set; }
    public decimal GainLossPercent { get; set; }
}