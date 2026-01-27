using backend.src.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace backend.src.services;

public class HoldingsService
{
    private readonly IMongoCollection<Portfolio> _portfolioCollection;
    private readonly StocksService _stocksService;

    public HoldingsService(
        IOptions<MongoDbSettings> mongoDbSettings,
        StocksService stocksService)
    {
        _stocksService = stocksService;
        var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
        
        _portfolioCollection = mongoDatabase.GetCollection<Portfolio>(
        mongoDbSettings.Value.PortfolioCollectionName);
    }

    public async Task AddHoldingAsync(string userId, AddHoldingRequest request)
    {
        Console.WriteLine($"HoldingsController received userId: '{userId}'");
        var portfolio = await _portfolioCollection
            .Find(portfolio => portfolio.UserId == userId)
            .FirstOrDefaultAsync();

        if (portfolio == null)
            throw new Exception("Portfolio not found");

        var existingHolding = portfolio.Holdings
            .FirstOrDefault(h => h.Symbol == request.Symbol);

        if (existingHolding == null)
        {
            portfolio.Holdings.Add(new Holding
            {
                Symbol = request.Symbol,
                Shares = request.Shares,
                AvgBuyPrice = request.BuyPrice
            });
        }
        else
        {
            var totalOldValue = existingHolding.Shares * existingHolding.AvgBuyPrice;
            var totalNewValue = request.Shares * request.BuyPrice;
            var newTotalShares = existingHolding.Shares + request.Shares;

            existingHolding.Shares = newTotalShares;
            existingHolding.AvgBuyPrice = (totalOldValue + totalNewValue) / newTotalShares;
        }

        var cost = request.Shares * request.BuyPrice;
        portfolio.CashBalance -= cost;

        await _portfolioCollection.ReplaceOneAsync(
            p => p.Id == portfolio.Id,
            portfolio
        );
    }
}
