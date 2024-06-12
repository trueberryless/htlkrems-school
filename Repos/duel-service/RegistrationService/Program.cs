using System.Net;
using System.Text.Json.Serialization;
using RegistrationService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("URL")!;
string db = builder.Configuration.GetConnectionString("Database")!;
string collection = builder.Configuration.GetConnectionString("Collection")!;

builder.Services.AddSingleton<IMongoService, MongoService>(s => new MongoService(connection, db, collection));

/*builder.Services.AddControllers().AddJsonOptions(x =>
{
    // serialize enums as strings in api responses (e.g. Role)
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});*/

//add healthCheck Service
builder.Services.AddHealthChecks();

if(builder.Environment.IsDevelopment()){
    builder.WebHost.ConfigureKestrel((context, serverOptions) =>
    {
        serverOptions.Listen(IPAddress.Loopback, 5001);
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();