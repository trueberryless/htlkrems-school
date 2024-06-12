namespace MatchmakingService.Classes;

public class Duel
{
    public Duel(Player playerOne, Player playerTwo)
    {
        PlayerOne = playerOne;
        PlayerTwo = playerTwo;
    }

    public Player PlayerOne { get; set; }
    public Player PlayerTwo { get; set; }
}