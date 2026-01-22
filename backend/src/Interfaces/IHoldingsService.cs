using backend.src.Models;

public interface IHoldingsService
{
    Task<Portfolio> GetPortfolioAsync(string UserId);
    Task<Holding> BuyAsync(string userId, string symbol, int quantity, decimal price);
    Task<Holding> SellAsync(string userId, string symbol, int quantity, decimal price);
}