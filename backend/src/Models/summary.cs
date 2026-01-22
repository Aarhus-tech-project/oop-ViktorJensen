namespace backend.src.Models;

public class PortfolioSummary
{
    public string UserId { get; set; } = null!;
    public List<Portfolio> Holdings { get; set; } = [];
    public decimal TotalInvested { get; set; }
}