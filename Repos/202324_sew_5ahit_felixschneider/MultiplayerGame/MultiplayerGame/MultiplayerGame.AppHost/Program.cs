var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.MultiplayerGame_ApiService>("apiservice");

builder.AddProject<Projects.MultiplayerGame_Web>("webfrontend")
    .WithReference(apiService);

builder.Build().Run();