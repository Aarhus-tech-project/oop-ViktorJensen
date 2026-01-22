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
    public string Symbol {get; set; } = null!;

    [BsonElement("price")]
    [JsonPropertyName("price")]
    public decimal Price {get; set; }

    [BsonElement("timestamp")]
    [JsonPropertyName("timestamp")]
    public DateTime Timestamp {get; set; }
}