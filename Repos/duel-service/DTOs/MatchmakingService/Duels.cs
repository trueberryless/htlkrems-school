using System.Text.Json.Serialization;

namespace DTOs.MatchmakingService;

public record Duels(
    [property: JsonPropertyName("href")]
    string Href,
    [property: JsonPropertyName("duelsList")]
    List<Duel> DuelsList
    );