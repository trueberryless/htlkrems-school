using RegistrationService.Entities;

namespace RegistrationService.Services;

public interface IMongoService
{
    Task<List<Player>> GetPlayers();

    Task<Player> GetPlayer(int id);

    Task<Player> UpdatePlayerElo(Player p);
    Task<Player> UpdatePlayerState(Player p);
    
    Task<Player> CreatePlayer(Player p);

    Task DeletePlayer(Player p);
}