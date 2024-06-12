using DTOs.MatchmakingService;

namespace Clients.Matchmaking;

public interface IMatchmakingService
{

    public Task<Duels?> GetMatchmaking();
}