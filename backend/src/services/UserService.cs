using backend.src.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace backend.src.services
{
public class UserService
    {
    private readonly IMongoCollection<User> _userCollectionName;
    public UserService(
        IOptions<MongoDbSettings> MongoDbSettings)
    {
    var mongoClient = new MongoClient(
        MongoDbSettings.Value.ConnectionString);
    var mongoDatabase = mongoClient.GetDatabase(
        MongoDbSettings.Value.DatabaseName);
        _userCollectionName = mongoDatabase.GetCollection<User>(
        MongoDbSettings.Value.UserCollectionName);
    }

    public async Task<User?> GetUserByUsernameAsync(string username) =>
    await _userCollectionName.Find(user => user.Username == username).FirstOrDefaultAsync();

    }}