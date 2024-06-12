using Clients;
using Clients.Registration;
using Clients.Statistics;
using MatchmakingService;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IntegrationTests;

public class MatchmakingTests 
    : IClassFixture<WebApplicationFactory<MatchmakingService.Program>>
{
    private readonly WebApplicationFactory<MatchmakingService.Program> _factory;
    private readonly IOptions<MatchmakingServiceOptions> _options;

    public MatchmakingTests(WebApplicationFactory<MatchmakingService.Program> factory)
    {
        _factory = factory;
        _options = Options.Create(new MatchmakingServiceOptions()
            {
                hostname = "localhost",
                port = 80,
                basePath = "/api"
            }
        );
    }

    [Fact]
    public async Task MatchmakingTestWithMock()
    {
        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddScoped<IRegistrationService, RegistrationServiceMock>();
                services.AddScoped<IStatisticsService, StatisticsServiceMock>();
            });
        }).CreateClient();
        
        var _matchmakingService = new Clients.Matchmaking.MatchmakingService(client, _options);
        
        var duels = await _matchmakingService.GetMatchmaking();
        Assert.Equal(duels.Href, $"http://{_options.Value.hostname}{_options.Value.basePath}/matchmaking");
        Assert.True(duels.DuelsList.Count > 0);
        Assert.NotNull(duels.DuelsList[0]);
    }
}