using System.Text.Json.Serialization;

namespace DTOs.MatchmakingService;

public record Player(
    [property: JsonPropertyName("id")]
    int Id,
    
    [property: JsonPropertyName("name")]
    string Name,
    
    [property: JsonPropertyName("href")]
    string Href
    );