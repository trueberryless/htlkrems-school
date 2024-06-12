using Microsoft.AspNetCore.SignalR;

namespace MultiplayerGame.Web.Components.Services;

public class MatchmakingChat
{
    private List<ChatController> Chats { get; set; } = [];

    public Tuple<Guid, Guid> JoinChat()
    {
        var emptyChat = Chats.FirstOrDefault(t => t.ChatterOne == Guid.Empty || t.ChatterTwo == Guid.Empty);

        var chatterId = Guid.NewGuid();

        if (emptyChat != null)
        {
            if (emptyChat.ChatterOne == Guid.Empty)
            {
                emptyChat.ChatterOne = chatterId;
            }
            else
            {
                emptyChat.ChatterTwo = chatterId;
            }

            return new Tuple<Guid, Guid>(emptyChat.ChatId, chatterId);
        }
        else
        {
            emptyChat = new ChatController(chatterId, Guid.Empty);
            Chats.Add(emptyChat);
            return new Tuple<Guid, Guid>(emptyChat.ChatId, chatterId);
        }
    }

    public ChatController? Chat(Guid chatGuid)
    {
        return Chats.FirstOrDefault(g => g.ChatId == chatGuid);
    }
}