namespace backend.src.Models;

public class AddHoldingRequest
{
    public string Symbol { get; set; } = null!;
    public int Shares { get; set; }
    public decimal BuyPrice { get; set; }
}