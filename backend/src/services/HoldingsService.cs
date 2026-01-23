using backend.src.Models;
using MongoDB.Driver;

namespace backend.src.services;

// public class HoldingsService(
//     IMongoCollection<Portfolio> portfolio) : IHoldingsService
// {
//     private readonly IMongoCollection<Portfolio> _portfolio = portfolio;

//     public async Task<Portfolio> GetPortfolioAsync(string userId)
//     {
//         var portfolio = await _portfolio.Find(portfolio => portfolio.UserId == userId).FirstOrDefaultAsync() ?? throw new Exception("Please create a portfolio to continue");
//         return portfolio;
//     }
    // public async Task<Holding> BuyAsync(string userId, string symbol, int quantity, decimal price)
    // {
    //     var portfolio = await GetPortfolioAsync(userId);
    //     decimal totalCost = quantity * price;

    //     if (portfolio.CashBalance < totalCost)
    //         throw new Exception("Insufficient funds for current transaction");
    // }
    // public async Task<Holding> SellAsync(string userId, string symbol, int quantity, decimal price)
    // {
    //     var portfolio = await GetPortfolioAsync(userId);
    //     decimal totalSale = quantity * price;
    // }
// }
