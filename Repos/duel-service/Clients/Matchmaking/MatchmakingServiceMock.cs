using DTOs.MatchmakingService;

namespace Clients.Matchmaking;

public class MatchmakingServiceMock : IMatchmakingService
{
    public Task<Duels?> GetMatchmaking()
    {
        // Simulating the data retrieval
        var duels = new List<Duel>
        {
            new Duel(new Player(1, "John Doe", "/players/1"), new Player(3,"Bob Johnson", "/players/3")),
            new Duel(new Player(2, "Jane Smith", "/players/2"), new Player(1, "John Doe", "/players/1")),
            new Duel(new Player(3, "Bob Johnson", "/players/3"), new Player(1, "John Doe", "/players/1")),
            new Duel(new Player(4, "Alice Brown", "/players/4"), new Player(2, "Jane Smith", "/players/2")),
            new Duel(new Player(5," Charlie Wilson", "/players/5"), new Player(3, "Bob Johnson", "/players/3")),
        };

        // Simulating the base URL
        var baseUrl = "http://localhost:5033";

        // Creating the Duels object
        var duelsResponse = new Duels($"{baseUrl}/matchmaking", duels);

        return Task.FromResult<Duels?>(duelsResponse);
    }
}