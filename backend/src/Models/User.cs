using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.src.Models;
public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [BsonElement("email")]
    [JsonPropertyName("email")]
    public string Email { get; set; } = null!;

    [BsonElement("username")]
    [JsonPropertyName("username")]
    public string Username { get; set; } = null!;

    [BsonElement("pwdHash")]
    [JsonPropertyName("pwdHash")]
    public string PwdHash { get; set; } = null!;

    [BsonElement("createdAt")]
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [BsonElement("updatedAt")]
    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

}