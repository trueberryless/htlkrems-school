using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Configurations; 

public class AosDbContext : DbContext{

    public DbSet<Creature> Creatures { get; set; }

    public DbSet<Attack> Attacks { get; set; }

    public DbSet<Trait> Traits { get; set; }

    public DbSet<TraitItem> TraitItems { get; set; }

    public DbSet<Skill> Skills { get; set; }

    public DbSet<SkillItem> SkillItems { get; set; }

    public AosDbContext(DbContextOptions<AosDbContext> options) : base(options) {
        
    }

    protected override void OnModelCreating(ModelBuilder builder) {
        builder.Entity<Creature>()
            .HasIndex(c => c.Name)
            .IsUnique();

        builder.Entity<Attack>()
            .HasIndex(a => a.Identifier)
            .IsUnique();

        builder.Entity<Attack>()
            .HasOne(a => a.Creature)
            .WithMany()
            .HasForeignKey(a => a.CreatureId);

        builder.Entity<Attack>()
            .Property(a => a.AttackType)
            .HasConversion<string>();

        builder.Entity<Trait>()
            .HasIndex(t => t.Identifier)
            .IsUnique();

        builder.Entity<TraitItem>()
            .HasKey(ti => new {ti.CreatureId, ti.TraitId});

        builder.Entity<TraitItem>()
            .HasOne(ti => ti.Creature)
            .WithMany()
            .HasForeignKey(ti => ti.CreatureId);

        builder.Entity<TraitItem>()
            .HasOne(ti => ti.Trait)
            .WithMany()
            .HasForeignKey(ti => ti.TraitId);

        builder.Entity<Skill>()
            .HasIndex(s => s.Identifier)
            .IsUnique();
        
        builder.Entity<SkillItem>()
            .HasKey(sk => new { sk.CreatureId, sk.SkillId });

        builder.Entity<SkillItem>()
            .HasOne(si => si.Creature)
            .WithMany()
            .HasForeignKey(si => si.CreatureId);

        builder.Entity<SkillItem>()
            .HasOne(si => si.Skill)
            .WithMany()
            .HasForeignKey(si => si.SkillId);
    }
}