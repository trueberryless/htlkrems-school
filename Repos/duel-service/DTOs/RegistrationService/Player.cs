using System.Text.Json.Serialization;
using RegistrationService.StateMachine;

namespace DTOs.RegistrationService;

public record Player(
    [property: JsonPropertyName("href")] 
    string Href,
    [property: JsonPropertyName("id")] 
    int Id,
    [property: JsonPropertyName("name")] 
    string Name,
    [property: JsonPropertyName("eloRating")]
    float EloRating,
    [property: JsonPropertyName("state"), JsonConverter(typeof(JsonStringEnumConverter))]
    EPlayerStates state,
    [property: JsonPropertyName("actions")]
    List<string> Actions
    ); 