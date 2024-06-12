using System.Text.Json.Serialization;

namespace DTOs.MatchmakingService;

public record Duel(
    [property: JsonPropertyName("playerOne")]
    Player PlayerOne,
    [property: JsonPropertyName("playerTwo")]
    Player PlayerTwo
    );