using System.Text.Json.Serialization;

namespace DTOs.StatisticsService;

public record ReadStatisticsDto(
    [property: JsonPropertyName("href")]
    string Href,
    [property: JsonPropertyName("currentEloRanking")]
    float CurrentEloRanking,
    [property: JsonPropertyName("lastDuelPlayedAt")]
    DateTime LastDuelPlayedAt);

public record ReadStatisticDto(
    [property: JsonPropertyName("href")]
    string Href, 
    [property: JsonPropertyName("id")]
    int Id,
    [property: JsonPropertyName("currentEloRanking")]
    float CurrentEloRanking, 
    [property: JsonPropertyName("numberOfDuelsWon")]
    int NumberOfDuelsWon, 
    [property: JsonPropertyName("numberOfDuelsLost")]
    int NumberOfDuelsLost, 
    [property: JsonPropertyName("numberOfDuelsDraw")]
    int NumberOfDuelsDraw, 
    [property: JsonPropertyName("numberOfDuelsPlayed")]
    int NumberOfDuelsPlayed, 
    [property: JsonPropertyName("averageDuelDuration")]
    double AverageDuelDuration,
    [property: JsonPropertyName("lastDuelPlayedAt")]
    DateTime LastDuelPlayedAt);
    
public record PostStatisticsDto(
    [property: JsonPropertyName("currentEloRanking")]
    float CurrentEloRanking, 
    [property: JsonPropertyName("numberOfDuelsWon")]
    int NumberOfDuelsWon, 
    [property: JsonPropertyName("numberOfDuelsLost")]
    int NumberOfDuelsLost, 
    [property: JsonPropertyName("numberOfDuelsDraw")]
    int NumberOfDuelsDraw, 
    [property: JsonPropertyName("numberOfDuelsPlayed")]
    int NumberOfDuelsPlayed, 
    [property: JsonPropertyName("averageDuelDuration")]
    double AverageDuelDuration,
    [property: JsonPropertyName("lastDuelPlayedAt")]
    DateTime LastDuelPlayedAt);
    
public record PutStatisticsDto(
    [property: JsonPropertyName("id")]
    int Id,
    [property: JsonPropertyName("currentEloRanking")]
    float CurrentEloRanking, 
    [property: JsonPropertyName("numberOfDuelsWon")]
    int NumberOfDuelsWon, 
    [property: JsonPropertyName("numberOfDuelsLost")]
    int NumberOfDuelsLost, 
    [property: JsonPropertyName("numberOfDuelsDraw")]
    int NumberOfDuelsDraw, 
    [property: JsonPropertyName("numberOfDuelsPlayed")]
    int NumberOfDuelsPlayed, 
    [property: JsonPropertyName("averageDuelDuration")]
    double AverageDuelDuration,
    [property: JsonPropertyName("lastDuelPlayedAt")]
    DateTime LastDuelPlayedAt);