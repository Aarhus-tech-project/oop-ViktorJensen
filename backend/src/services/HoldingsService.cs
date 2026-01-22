using backend.src.Models;
using MongoDB.Driver;

namespace backend.src.services;

public class HoldingsService(
    IMongoCollection<Portfolio> portfolio) : IHoldingsService
{
    private readonly IMongoCollection<Portfolio> _portfolio = portfolio;

    public async Task<Portfolio> GetPortfolioAsync(string userId)
    {
        var portfolio = await _portfolio.Find(portfolio => portfolio.UserId == userId).FirstOrDefaultAsync();
        if (portfolio == null)
        {
            portfolio = new Portfolio
            {
                UserId = userId,
                CashBalance = 100_000m,
                Holdings = new List<Holding>()
            };
            await _portfolio.InsertOneAsync(portfolio);
        }

        return portfolio;
    }
    public async Task<Holding> BuyAsync(string userId, string symbol, int quantity, decimal price)
    {
        
    }
    public async Task<Holding> SellAsync(string userId, string symbol, int quantity, decimal price)
    {
        
    }
}
