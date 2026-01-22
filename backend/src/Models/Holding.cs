using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.src.Models;

public class Holding
{
    [BsonElement("symbol")]
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = null!;

    [BsonElement("shares")]
    [JsonPropertyName("shares")]
    public int Shares { get; set; }

    [BsonElement("avgBuyPrice")]
    [JsonPropertyName("avgBuyPrice")]
    public decimal AvgBuyPrice { get; set; }
}