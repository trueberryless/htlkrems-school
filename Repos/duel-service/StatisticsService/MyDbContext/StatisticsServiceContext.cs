using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StatisticsService.Model;

namespace StatisticsService.MyDbContext;

public class StatisticsServiceContext : DbContext
{
    protected readonly IConfiguration Configuration;
    
    public DbSet<Player> Players { get; set; }
    
    public string DbPath { get; }

    public StatisticsServiceContext(IConfiguration configuration)
    {
        Configuration = configuration;
        
        var path = Environment.CurrentDirectory;
        DbPath = System.IO.Path.Join(path, "duel.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}