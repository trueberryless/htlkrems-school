using System.Text.Json.Serialization;

namespace DTOs.RegistrationService;

public record PlayersList(
    [property: JsonPropertyName("href")]
    string Href,
    [property: JsonPropertyName("players")]
    List<Player> Players
    );