using System.Net.Http.Json;
using System.Text.Json;
using DTOs.RegistrationService;
using Microsoft.Extensions.Options;

namespace Clients.Registration;

public class RegistrationService : AClientService, IRegistrationService
{
    public RegistrationService(HttpClient httpClient, IOptions<RegistrationServiceOptions> options) : base(httpClient,options){ }

    public async Task<PlayersList?> GetPlayers()
    {
        var httpResponseMessage = await _httpClient.GetAsync("/api/players");
        string body = await httpResponseMessage.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<PlayersList>(body);
    }

    public async Task<Player> CreatePlayer(string name)
    {
        var content = JsonContent.Create(name);
        var response = await _httpClient.PostAsync("/api/registration", content);

        var body = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Player>(body)!;
    }

    public async Task<Player> UpdatePlayer(int id, UpdatePlayerDTO updatePlayerDto)
    {
        var content = JsonContent.Create(updatePlayerDto);
        var response = await _httpClient.PutAsync($"/api/registration/{id}", content);
        var body = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Player>(body)!;
    }

    /*
     *
       POST /Registration
           Legt einen neuen Spieler an
           Name wird im Body des Requests übergeben
           Id und Elo-Wert wird vom Service vergeben
       PUT /Registration/{id}
           Aktualisiert einen vorhandenen Spieler
           Name und Elo-Wert können aktualisiert werden
       GET /Players
           Liefert eine Liste aller eingetragenen Spieler
     */
}
