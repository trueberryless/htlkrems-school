namespace MatchmakingService.Classes;

public class Player
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public float EloRating { get; set; }
    public string Href{ get; set; }
    
    public PlayerStatistics PlayerStatistics { get; set; }
}