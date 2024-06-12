namespace MultiplayerGame.Web.Components.Services;

public class GameController : EventArgs, IDisposable, IAsyncDisposable
{
    public Guid GameId { get; set; } = Guid.NewGuid();
    public Guid PlayerOne { get; set; }
    public Guid PlayerTwo { get; set; }

    public GameStatus Status { get; set; }

    public event EventHandler UpdateClients;
    private Timer timer;

    public GameController(Guid playerOne, Guid playerTwo)
    {
        PlayerOne = playerOne;
        PlayerTwo = playerTwo;
        Status = new GameStatus();

        UpdateClients += HandleUpdateClients;
        timer = new Timer(RaiseEvent, null, 0, 20);
    }

    public bool PlayersReady()
    {
        return PlayerOne != Guid.Empty && PlayerTwo != Guid.Empty;
    }

    public void RaiseEvent(object? state)
    {
        UpdateClients.Invoke(this, this);
    }
    
    private void HandleUpdateClients(object sender, EventArgs e)
    {
        
    }

    public void Dispose()
    {
        timer.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await timer.DisposeAsync();
    }
}

public class GameStatus
{
    public double PlayerOneCircleSize { get; set; } = 40;
    public double PlayerTwoCircleSize { get; set; } = 40;
    public bool? PlayerOneWon { get; set; }
    
    public DateTime Created { get; set; } = DateTime.Now;
}