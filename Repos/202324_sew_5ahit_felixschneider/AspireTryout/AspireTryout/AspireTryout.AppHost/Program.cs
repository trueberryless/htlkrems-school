var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedisContainer("cache");

var apiService = builder.AddProject<Projects.AspireTryout_ApiService>("apiservice");

builder.AddProject<Projects.AspireTryout_Web>("webfrontend")
    .WithReference(apiService)
    .WithReference(cache);

builder.Build().Run();