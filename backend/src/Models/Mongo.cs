namespace backend.src.Models;

public class MongoDbSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string StockCollectionName { get; set; } = null!;
    public string UserCollectionName { get; set; } = null!;
    public string PortfolioCollectionName { get; set; } = null!;
}