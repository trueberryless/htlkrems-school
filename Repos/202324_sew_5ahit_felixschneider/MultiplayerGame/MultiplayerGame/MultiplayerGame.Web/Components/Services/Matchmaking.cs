using Microsoft.AspNetCore.SignalR;

namespace MultiplayerGame.Web.Components.Services;

public class Matchmaking
{
    private List<GameController> Games { get; set; } = [];

    public Tuple<Guid, Guid> JoinGame()
    {
        var emptyGame = Games.FirstOrDefault(t => t.PlayerOne == Guid.Empty || t.PlayerTwo == Guid.Empty);

        var playerId = Guid.NewGuid();

        if (emptyGame != null)
        {
            if (emptyGame.PlayerOne == Guid.Empty)
            {
                emptyGame.PlayerOne = playerId;
            }
            else
            {
                emptyGame.PlayerTwo = playerId;
            }

            return new Tuple<Guid, Guid>(emptyGame.GameId, playerId);
        }
        else
        {
            emptyGame = new GameController(playerId, Guid.Empty);
            Games.Add(emptyGame);
            return new Tuple<Guid, Guid>(emptyGame.GameId, playerId);
        }
    }

    public GameController? Game(Guid gameGuid)
    {
        return Games.FirstOrDefault(g => g.GameId == gameGuid);
    }
}