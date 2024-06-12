using Clients;
using Clients.Registration;
using Clients.Statistics;
using Mapster;
using MatchmakingService.Classes;
using Microsoft.AspNetCore.Mvc;

namespace MatchmakingService.Controllers;

[ApiController]
[Route("/api")]
public class MatchmakingController : ControllerBase
{
    readonly IStatisticsService _statisticsService;
    readonly IRegistrationService _registrationService;
    readonly Services.MatchmakingCalcService _matchmakingCalcService;

    public MatchmakingController(IRegistrationService registrationService, IStatisticsService statisticsService, Services.MatchmakingCalcService matchmakingCalcService)
    {
        this._registrationService = registrationService;
        this._statisticsService = statisticsService;
        this._matchmakingCalcService = matchmakingCalcService;
    }

    [HttpGet("matchmaking")]
    public async Task<DTOs.MatchmakingService.Duels> GetMatchmaking()
    {
        var players = (await this._registrationService.GetPlayers())!.Players.Select(p => p.Adapt<Player>()).ToList();
        foreach (var p in players)
        {
            var statistic = (await _statisticsService.GetStatistic(p.Id)).Adapt<PlayerStatistics>();
            p.PlayerStatistics = statistic;
        }

        var duels = this._matchmakingCalcService.Next(players)
            .Select(d => d.Adapt<DTOs.MatchmakingService.Duel>()).ToList();
        return new DTOs.MatchmakingService.Duels(Url.ActionLink(nameof(GetMatchmaking),ControllerContext.ActionDescriptor.ControllerName)!, duels);
    }
}