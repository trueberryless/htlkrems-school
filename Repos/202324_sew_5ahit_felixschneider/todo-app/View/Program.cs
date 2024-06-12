using Domain.Repositories.Implementations;
using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using MudBlazor;
using MudBlazor.Services;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using View.Services;
using Messaging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthenticationCore();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// then we can add the Options
// this adds services we need
builder.Services.AddOptions();

builder.Services.AddDbContextFactory<ModelDbContext>(
    options => options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 27))
    ),
    ServiceLifetime.Singleton
);

// MudBlazor
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;

    config.SnackbarConfiguration.PreventDuplicates = true;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 5000;
    config.SnackbarConfiguration.HideTransitionDuration = 200;
    config.SnackbarConfiguration.ShowTransitionDuration = 200;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

// Repositories
builder.Services.AddScoped<ILogEntryRepository, LogEntryRepository>();
builder.Services.AddScoped<IRoleClaimRepository, RoleClaimRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

builder.Services.AddScoped<IThemeHandler, ThemeHandler>();
builder.Services.AddScoped<CircuitHandler, CircuitTracker>();

builder.Services.AddScoped<EventProvider>();

builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<IEmailTemplateRepository, EmailTemplateRepository>();

builder.Services.AddScoped<NavigationProvider>();
builder.Services.AddScoped<DateManager>();
builder.Services.AddScoped<BrowserService>();

builder.Services.AddScoped<Messaging.Message>();

builder.Services.AddLogging(); // the default Logger

builder.Services.AddHttpContextAccessor(); // this services enables us to access to HttpContext of our App

builder.Services
    .AddScoped<AuthenticationStateProvider,
        CustomAuthStateProvider>(); // we register our implementation of the AuthenticationStateProvider
builder.Services.AddScoped<UserService>(); // The UserService we use to login/register/logout

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<ModelDbContext>();  
var connected = false;  
while (!connected)  
{  
    if (!dbContext.Database.CanConnect())  
    {        
        await Task.Delay(1_000);  
        continue;  
    }
	  
    dbContext.Database.Migrate();  
    connected = true;  
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();