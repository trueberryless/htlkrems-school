using DTOs.RegistrationService;
using RegistrationService.StateMachine;

namespace Clients.Registration;

public class RegistrationServiceMock : IRegistrationService
{
    public Task<PlayersList?> GetPlayers()
    {
        // Create example data
        var players = new List<Player>
        {
            new Player("/players/1", 1, "John Doe", 1500, EPlayerStates.PENDING, new List<string>(){"confirm/1", "delete/1"}),
            new Player("/players/2", 2, "Jane Smith", 1600, EPlayerStates.PENDING, new List<string>(){"confirm/2", "delete/2"}),
            new Player("/players/3", 3, "Bob Johnson", 1450, EPlayerStates.PENDING, new List<string>(){"confirm/3", "delete/3"}),
            new Player("/players/4", 4, "Alice Brown", 1750, EPlayerStates.PENDING, new List<string>(){"confirm/4", "delete/4"}),
            new Player("/players/5", 5, "Charlie Wilson", 1400, EPlayerStates.PENDING, new List<string>(){"confirm/5", "delete/5"}),
            // Add more players as needed
        };

        // Create PlayersList with the example data
        var playersList = new PlayersList("/players", players);

        // Wrap it in a completed Task (since Task.FromResult is not available here)
        return Task.FromResult<PlayersList?>(playersList);
    }

    public Task<Player> CreatePlayer(string name)
    {
        throw new NotImplementedException();
    }

    public Task<Player> UpdatePlayer(int id, UpdatePlayerDTO playerDto)
    {
        throw new NotImplementedException();
    }
}