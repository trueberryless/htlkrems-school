using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Configuration;

public class CinemaDbContext : DbContext
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Country> Country { get; set; }
    public DbSet<Hall> Halls { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Occupation> Occupations { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Screening> Screenings { get; set; }
    public DbSet<State> State { get; set; }
    
    public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Compound keys
        modelBuilder.Entity<Occupation>()
            .HasKey(o => new { o.MovieId, o.PersonId, o.Role, o.OccupationBegin });
        
        modelBuilder.Entity<Screening>()
            .HasKey(s => new { s.MovieId, s.HallId, s.StartsAt });

        // 1:n Relations
        modelBuilder.Entity<Address>()
            .HasOne(a => a.Country)
            .WithMany()
            .HasForeignKey(a => a.CountryName);
        
        modelBuilder.Entity<Address>()
            .HasOne(a => a.State)
            .WithMany()
            .HasForeignKey(a => a.StateCode);
        
        modelBuilder.Entity<Occupation>()
            .HasOne(o => o.Movie)
            .WithMany()
            .HasForeignKey(o => o.MovieId);
        
        modelBuilder.Entity<Occupation>()
            .HasOne(o => o.Person)
            .WithMany()
            .HasForeignKey(o => o.PersonId);

        modelBuilder.Entity<Screening>()
            .HasOne(s => s.Movie)
            .WithMany()
            .HasForeignKey(s => s.MovieId);

        modelBuilder.Entity<Screening>()
            .HasOne(s => s.Hall)
            .WithMany()
            .HasForeignKey(s => s.HallId);

        modelBuilder.Entity<Hall>()
            .HasOne(h => h.Cinema)
            .WithMany()
            .HasForeignKey(h => h.CinemaId);

        modelBuilder.Entity<Cinema>()
            .HasOne(c => c.Address)
            .WithMany()
            .HasForeignKey(c => c.AddressId);

        // Enum Conversion
        modelBuilder.Entity<Occupation>()
            .Property(o => o.Role)
            .HasConversion<string>();

        modelBuilder.Entity<Cinema>()
            .HasIndex(c => c.Label)
            .IsUnique(true);
    }
}