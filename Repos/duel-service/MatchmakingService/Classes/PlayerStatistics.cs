namespace MatchmakingService.Classes;

public class PlayerStatistics
{
    public float CurrentEloRanking { get; set; }
    public int NumberOfDuelsWon { get; set; } 
    public int NumberOfDuelsLost { get; set; } 
    public int NumberOfDuelsDraw { get; set; }
    public int NumberOfDuelsPlayed { get; set; } 
    public double AverageDuelDuration { get; set; }
    public DateTime LastDuelPlayedAt { get; set; }
}