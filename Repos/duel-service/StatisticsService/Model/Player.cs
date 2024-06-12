using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatisticsService.Model;

[Table("PLAYERS")]
public class Player
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public float CurrentEloRanking { get; set; } = 1500f;
    public int NumberOfDuelsWon { get; set; }
    public int NumberOfDuelsLost { get; set; }
    public int NumberOfDuelsDraw { get; set; }
    public int NumberOfDuelsPlayed { get; set; }
    public double AverageDuelDuration { get; set; }
    public DateTime? LastDuelPlayedAt { get; set; }
    
    [NotMapped]
    public string? Href { get; set; }

    public Player(
        int id,
        float currentEloRanking,
        int numberOfDuelsWon,
        int numberOfDuelsLost, 
        int numberOfDuelsDraw,
        int numberOfDuelsPlayed,
        double averageDuelDuration,
        DateTime lastDuelPlayedAt
    )
    {
        Id = id;
        CurrentEloRanking = currentEloRanking;
        NumberOfDuelsWon = numberOfDuelsWon;
        NumberOfDuelsLost = numberOfDuelsLost;
        NumberOfDuelsDraw = numberOfDuelsDraw;
        NumberOfDuelsPlayed = numberOfDuelsPlayed;
        AverageDuelDuration = averageDuelDuration;
        LastDuelPlayedAt = lastDuelPlayedAt;
    }
    
    public Player() {}
}