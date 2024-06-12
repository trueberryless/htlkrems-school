using System.Text.Json.Serialization;
namespace DTOs.RegistrationService;

public record UpdatePlayerDTO(
    [property: JsonPropertyName("eloRating")]
    float EloRating
    );