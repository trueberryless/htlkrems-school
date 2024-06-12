using System.Net;
using Clients;
using Clients.Registration;
using Clients.Statistics;
using MatchmakingService.Services;

namespace MatchmakingService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var registrationServiceOptions= builder.Configuration.GetRequiredSection("RegistrationServiceApi");
        builder.Services.Configure<RegistrationServiceOptions>(registrationServiceOptions);

        var statisticsServiceOptions = builder.Configuration.GetRequiredSection("StatisticsServiceApi");
        builder.Services.Configure<StatisticsServiceOptions>(statisticsServiceOptions);

        builder.Services.AddHttpClient();

        builder.Services.AddScoped<IRegistrationService, Clients.Registration.RegistrationService>();
        builder.Services.AddScoped<IStatisticsService, Clients.Statistics.StatisticsService>();

        builder.Services.AddSingleton<MatchmakingCalcService>();

        builder.Services.AddControllers();
        //add healthCheck Service
        builder.Services.AddHealthChecks();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        if(builder.Environment.IsDevelopment()){
            builder.WebHost.ConfigureKestrel((context, serverOptions) =>
            {
                serverOptions.Listen(IPAddress.Loopback, 5000);
            });
        }

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        app.MapHealthChecks("/health");

        app.Run();
    }
}