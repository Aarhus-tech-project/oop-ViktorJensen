using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.src.Models;

public class Stock
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [JsonPropertyName("id")]
    public string? Id {get; set; }

    [BsonElement("symbol")]
    [JsonPropertyName("symbol")]
    public string symbol {get; set; } = null!;

    [BsonElement("price")]
    [JsonPropertyName("price")]
    public decimal price {get; set; }

    [BsonElement("timestamp")]
    [JsonPropertyName("timestamp")]
    public DateTime timestamp {get; set; }
}