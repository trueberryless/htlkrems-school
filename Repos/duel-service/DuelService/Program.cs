using Clients;
using Clients.Matchmaking;
using Clients.Registration;
using Clients.Statistics;
using DuelService;

var builder = WebApplication.CreateBuilder(args);


var registrationServiceOptions= builder.Configuration.GetRequiredSection("RegistrationServiceApi");
builder.Services.Configure<RegistrationServiceOptions>(registrationServiceOptions);

var statisticsServiceOptions = builder.Configuration.GetRequiredSection("StatisticsServiceApi");
builder.Services.Configure<StatisticsServiceOptions>(statisticsServiceOptions);

var matchmakingServiceOptions = builder.Configuration.GetRequiredSection("MatchmakingServiceApi");
builder.Services.Configure<MatchmakingServiceOptions>(matchmakingServiceOptions);

builder.Services.AddHttpClient();

builder.Services.AddSingleton<IRegistrationService, Clients.Registration.RegistrationService>();
builder.Services.AddSingleton<IStatisticsService, Clients.Statistics.StatisticsService>();
builder.Services.AddSingleton<IMatchmakingService, MatchmakingService>();

builder.Services.AddHostedService<DuelBgService>();

var app = builder.Build();
app.Run();