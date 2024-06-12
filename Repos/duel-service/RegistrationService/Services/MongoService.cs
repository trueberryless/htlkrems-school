using Mapster;
using MongoDB.Bson;
using MongoDB.Driver;
using RegistrationService.Entities;

namespace RegistrationService.Services;

public class MongoService : IMongoService
{
    private IMongoCollection<Player> _collection;
    public MongoService(string connection, string database, string collection)
    {
        var client = new MongoClient(connection);
        _collection = client.GetDatabase(database).GetCollection<Player>(collection);
    }

    public async Task<List<Player>> GetPlayers()
    {
        var filter = Builders<Player>.Filter.Empty;
        var documents =  await _collection.Find(filter).ToListAsync();
        return documents;
    }

    public async Task<Player> GetPlayer(int id)
    {
        var filter = Builders<Player>.Filter
            .Eq(p=> p.Id, id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<Player> UpdatePlayerElo(Player p)
    {
        var filter = Builders<Player>.Filter
            .Eq(p => p.Id, p.Id);
        
        var update = Builders<Player>.Update
            .Set(p => p.EloRating, p.EloRating);
        
        await _collection.UpdateOneAsync(filter, update);
        
        return await GetPlayer(p.Id);
    }
    
    public async Task<Player> UpdatePlayerState(Player p)
    {
        var filter = Builders<Player>.Filter
            .Eq(p => p.Id, p.Id);
        
        var update = Builders<Player>.Update
            .Set(p=> p.State, p.State);
        
        await _collection.UpdateOneAsync(filter, update);
        
        return await GetPlayer(p.Id);
    }

    public async Task<Player> CreatePlayer(Player p)
    {
        var all = await _collection.Find(Builders<Player>.Filter.Empty).ToListAsync();
        if (!all.Any())
            p.Id = 1;
        else
            p.Id = all.Select(p => p.Id).Max() + 1;
        await _collection.InsertOneAsync(p);
        return p;
    }

    public async Task DeletePlayer(Player p)
    {
        var filter = Builders<Player>.Filter
            .Eq(p => p.Id, p.Id);
        
        await _collection.DeleteOneAsync(filter);
    }
}