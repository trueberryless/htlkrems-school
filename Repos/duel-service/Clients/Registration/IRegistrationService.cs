using DTOs.RegistrationService;

namespace Clients.Registration;

public interface IRegistrationService
{
    Task<PlayersList?> GetPlayers();

    Task<Player> CreatePlayer(string name);

    Task<Player> UpdatePlayer(int id, UpdatePlayerDTO playerDto);
}