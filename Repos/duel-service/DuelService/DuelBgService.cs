using Clients;
using Clients.Matchmaking;
using Clients.Registration;
using Clients.Statistics;
using DTOs.RegistrationService;
using DTOs.StatisticsService;
using Mapster;
using Microsoft.AspNetCore.Server.HttpSys;
using Player = StatisticsService.Model.Player;

namespace DuelService;

public class DuelBgService : BackgroundService
{
    private readonly ILogger<DuelBgService> _logger;
    private readonly IMatchmakingService _matchmakingService;
    private readonly IRegistrationService _registrationService;
    private readonly IStatisticsService _statisticsService;

    public DuelBgService(ILogger<DuelBgService> logger, 
        IMatchmakingService matchmakingService,
        IRegistrationService registrationService,
        IStatisticsService statisticsService
        )
    {
        _logger = logger;
        _matchmakingService = matchmakingService;
        _registrationService = registrationService;
        _statisticsService = statisticsService;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation( "DuelService started!");
        await DoWork();

        using PeriodicTimer timer = new(TimeSpan.FromSeconds(10));

        try
        {
            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                await DoWork();
            }
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("DuelService is stopping.");
        }
    }

    private async Task DoWork()
    {
        var duels = await _matchmakingService.GetMatchmaking();
        foreach (var duel in duels.DuelsList)
        {
            _logger.LogInformation( $"Duels are fought, Player {duel.PlayerOne.Name} vs Player {duel.PlayerTwo.Name}!");

            var statisticsOne = (await _statisticsService.GetStatistic(duel.PlayerOne.Id)).Adapt<Player>();
            var statisticsTwo = (await _statisticsService.GetStatistic(duel.PlayerTwo.Id)).Adapt<Player>();

            float delta = CalculateEloDelta(statisticsOne.CurrentEloRanking, statisticsTwo.CurrentEloRanking);
            Random r = new Random();
            if (r.Next(0, 2) == 0)
            {
                statisticsOne.CurrentEloRanking += delta;
                statisticsTwo.CurrentEloRanking -= delta;
                statisticsOne.LastDuelPlayedAt = DateTime.Now;
                statisticsTwo.LastDuelPlayedAt = DateTime.Now;
                statisticsOne.NumberOfDuelsWon += 1;
                statisticsTwo.NumberOfDuelsLost += 1;
                statisticsOne.NumberOfDuelsPlayed += 1;
                statisticsTwo.NumberOfDuelsPlayed += 1;
            }
            else
            {
                statisticsOne.CurrentEloRanking -= delta;
                statisticsTwo.CurrentEloRanking += delta;
                statisticsOne.LastDuelPlayedAt = DateTime.Now;
                statisticsTwo.LastDuelPlayedAt = DateTime.Now;
                statisticsTwo.NumberOfDuelsWon += 1;
                statisticsOne.NumberOfDuelsLost += 1;
                statisticsOne.NumberOfDuelsPlayed += 1;
                statisticsTwo.NumberOfDuelsPlayed += 1;
            }

            var statisticsOnePut = statisticsOne.Adapt<PutStatisticsDto>();
            var statisticsTwoPut = statisticsTwo.Adapt<PutStatisticsDto>();

            await _statisticsService.UpdateStatistics(statisticsOnePut);
            await _statisticsService.UpdateStatistics(statisticsTwoPut);

            await _registrationService.UpdatePlayer(statisticsOne.Id,
                new UpdatePlayerDTO(statisticsOne.CurrentEloRanking));
            
            await _registrationService.UpdatePlayer(statisticsTwo.Id,
                new UpdatePlayerDTO(statisticsTwo.CurrentEloRanking));
        }
    }
    
    private double ExpectationToWin(
        float playerOneRating, 
        float playerTwoRating)
    {
        return 1 / (1 + Math.Pow(10f, (playerTwoRating - playerOneRating) / 400.0));
    }

    private float CalculateEloDelta(
        float playerOneRating, 
        float playerTwoRating)
    {
        float eloK = 32;
			
        return (float)(eloK * (1 - ExpectationToWin(playerOneRating, playerTwoRating)));
    }

}