using MatchmakingService.Classes;

namespace MatchmakingService.Services;

public class MatchmakingCalcService
{
    public List<Duel> Next(List<Player> players)
    {
        List<Duel> duels = new List<Duel>();

        foreach (var p in players)
        {
            var statistics = players.Where(s => s.Id != p.Id).ToList();
            var playerWithNearElo = statistics.Select(s => new
            {
                relEloAbs = Math.Abs(s.PlayerStatistics.CurrentEloRanking - p.PlayerStatistics.CurrentEloRanking),
                statistics = s,
            }).OrderBy(s => s.relEloAbs)
            .Take(int.Max(int.Min(players.Count / 3, 10),1))
            .OrderBy(s => s.statistics.PlayerStatistics.LastDuelPlayedAt).ToList();

            Duel d = new Duel(p, players.First(pl => pl.Id == playerWithNearElo.First().statistics.Id));
            duels.Add(d);
        } 
        return duels;
    }
}