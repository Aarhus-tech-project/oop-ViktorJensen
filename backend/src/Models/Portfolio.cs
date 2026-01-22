using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.src.Models;

public class Portfolio
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [JsonPropertyName("id")]
    public string? Id {get; set; }
    
    [BsonElement("userId")]
    [JsonPropertyName("userId")]
    public string UserId { get; set; } = null!;

    [BsonElement("stockSymbol")]
    [JsonPropertyName("stockSymbol")]
    public string StockSymbol { get; set; } = null!;

    [BsonElement("quantity")]
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [BsonElement("purchasePrice")]
    [JsonPropertyName("purchasePrice")]
    public int PurchasePrice { get; set; }

    [BsonElement("purchaseDate")]
    [JsonPropertyName("purchaseDate")]
    public DateTime PurchaseDate { get; set; }

    [BsonElement("currentPrice")]
    [JsonPropertyName("currentPrice")]
    public int CurrentPrice { get; set; }

    [BsonIgnore]
    [JsonPropertyName("gainLoss")]
    public decimal GainLoss => (CurrentPrice - PurchasePrice) * Quantity;

    [BsonIgnore]
    [JsonPropertyName("gainLossPercent")]
    public decimal GainLossPercent => PurchasePrice != 0 ? (CurrentPrice - PurchasePrice) / PurchasePrice * 100 : 0;
}