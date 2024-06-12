using Domain.Repositories.Implementations;
using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;
using WebGui.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContextFactory<AosDbContext>(
    options => options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"), 
        new MySqlServerVersion(new Version(8,0,27))
    )
);


// Add services to the container. (Scoped, Singelton, Transient)
builder.Services.AddScoped<IRepository<Attack>, AttackRepository>();
builder.Services.AddScoped<IRepository<Creature>, CreatureRepository>();
builder.Services.AddScoped<IRepository<Skill>, SkillRepository>();
builder.Services.AddScoped<IRepository<SkillItem>, SkillItemRepository>();
builder.Services.AddScoped<IRepository<Trait>, TraitRepository>();
builder.Services.AddScoped<IRepository<TraitItem>, TraitItemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();