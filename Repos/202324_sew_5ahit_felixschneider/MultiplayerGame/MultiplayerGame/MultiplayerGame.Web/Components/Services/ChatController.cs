namespace MultiplayerGame.Web.Components.Services;

public class ChatController : EventArgs, IDisposable, IAsyncDisposable
{
    public Guid ChatId { get; set; } = Guid.NewGuid();
    public Guid ChatterOne { get; set; }
    public Guid ChatterTwo { get; set; }

    public ChatStatus Status { get; set; }

    public event EventHandler UpdateClients;
    private Timer timer;

    public ChatController(Guid chatterOne, Guid chatterTwo)
    {
        ChatterOne = chatterOne;
        ChatterTwo = chatterTwo;
        Status = new ChatStatus();

        UpdateClients += HandleUpdateClients;
        timer = new Timer(RaiseEvent, null, 0, 500);
    }

    public bool ChattersReady()
    {
        return ChatterOne != Guid.Empty && ChatterTwo != Guid.Empty;
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

public class ChatStatus
{
    public List<Message> Messages { get; set; } = [];
}

public class Message
{
    public Guid Chatter { get; set; }
    public string Content { get; set; }
    public DateTime Posted { get; set; }
}