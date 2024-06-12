using System.Net;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StatisticsService;
using StatisticsService.MyDbContext;
using StatisticsService.Middleware;
using StatisticsService.Repositories;

var builder = WebApplication.CreateBuilder(args);

{
    var services = builder.Services;
    
    services.AddDbContext<StatisticsServiceContext>();
    services.AddCors();

    services.AddControllers().AddJsonOptions(x =>
    {
        // serialize enums as strings in api responses (e.g. Role)
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

        // ignore omitted parameters on models to enable optional params (e.g. User update)
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

    services.AddScoped<IStatisticRepository, StatisticRepository>();

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    
    //add healthCheck Service
    builder.Services.AddHealthChecks();
    
    if(builder.Environment.IsDevelopment()){
        builder.WebHost.ConfigureKestrel((context, serverOptions) =>
        {
            serverOptions.Listen(IPAddress.Loopback, 5002);
        });
    }
}

var app = builder.Build();

{
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
    
    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.MapControllers();
    app.MapHealthChecks("/health");
    
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.Run();