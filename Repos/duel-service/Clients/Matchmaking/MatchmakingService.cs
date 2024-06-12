using System.Text.Json;
using DTOs.MatchmakingService;
using Microsoft.Extensions.Options;

namespace Clients.Matchmaking;

public class MatchmakingService : AClientService, IMatchmakingService
{

    public MatchmakingService(HttpClient httpClient, IOptions<MatchmakingServiceOptions> options) : base(httpClient, options){ }

    public async Task<Duels?> GetMatchmaking()
    {
        var httpResponseMessage = await _httpClient.GetAsync("/api/matchmaking");
        var body = await httpResponseMessage.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Duels>(body);
    }
}
