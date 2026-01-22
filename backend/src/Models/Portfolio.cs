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

    [BsonElement("cashBalance")]
    [JsonPropertyName("cashBalance")]
    public decimal CashBalance { get; set; }

    [BsonElement("totalValue")]
    [JsonPropertyName("totalValue")]
    public decimal TotalValue { get; set; }

    [BsonElement("holdings")]
    [JsonPropertyName("holdings")]
    public List<Holding> Holdings { get; set; } = new();
}