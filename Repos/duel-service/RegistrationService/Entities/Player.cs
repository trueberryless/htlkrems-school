using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using RegistrationService.StateMachine;

namespace RegistrationService.Entities;

public class Player
{
    [BsonId]
    public int Id { get; set; }
    
    [BsonElement("Name")]
    public string Name { get; set; }

    [BsonElement("EloRaiting")] 
    public float EloRating { get; set; } = 1500;

    [BsonElement("State")] 
    public EPlayerStates State { get; set; } = EPlayerStates.PENDING;
    
    [BsonIgnore]
    public string Href { get; set; }

    [BsonIgnore] 
    public List<string> Actions { get; set; } = null;
}