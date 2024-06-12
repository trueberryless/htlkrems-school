using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Configuration;

public class PlaybookDbContext : DbContext
{
    // Base Tables
    public DbSet<AChangeValueEvent> ChangeValueEvents { get; set; }
    public DbSet<AEffect> Effects { get; set; }
    public DbSet<AEvent> Events { get; set; }
    public DbSet<AItemEvent> ItemEvents { get; set; }
    public DbSet<AOutcome> Outcomes { get; set; }
    public DbSet<ARegion> Regions { get; set; }
    public DbSet<ASection> Sections { get; set; }
    public DbSet<AValueChangeEffect> ValueChangeEffects { get; set; }
    
    // Child Tables
    public DbSet<AbilityOutcome> AbilityOutcomes { get; set; }
    public DbSet<AcquireItemEvent> AcquireItemEvents { get; set; }
    public DbSet<Area> Areas { get; set; }
    public DbSet<CombatEvent> CombatEvents { get; set; }
    public DbSet<CombatSkillChangeEffect> CombatSkillChangeEffects { get; set; }
    public DbSet<CombatSkillChangeEvent> CombatSkillChangeEvents { get; set; }
    public DbSet<CombatSkillTemporaryChangeEvent> CombatSkillTemporaryChangeEvents { get; set; }
    public DbSet<DefaultOutcome> DefaultOutcomes { get; set; }
    public DbSet<DropAllWeaponsEvent> DropAllWeaponsEvents { get; set; }
    public DbSet<DropBackpackEvent> DropBackpackEvents { get; set; }
    public DbSet<DropItemEvent> DropItemEvents { get; set; }
    public DbSet<DropWeaponEvent> DropWeaponEvents { get; set; }
    public DbSet<EnduranceChangeEffect> EnduranceChangeEffects { get; set; }
    public DbSet<EnduranceChangeEvent> EnduranceChangeEvents { get; set; }
    public DbSet<GoldAmountChangeEvent> GoldAmountChangeEvents { get; set; }
    public DbSet<GoldOutcome> GoldOutcomes { get; set; }
    public DbSet<ItemOutcome> ItemOutcomes { get; set; }
    public DbSet<MissionAccomplishedEvent> MissionAccomplishedEvents { get; set; }
    public DbSet<MissionFailedEvent> MissionFailedEvents { get; set; }
    public DbSet<MissionFailedOutcome> MissionFailedOutcomes { get; set; }
    public DbSet<PointOfInterest> PointOfInterests { get; set; }
    public DbSet<RandomOutcome> RandomOutcomes { get; set; }
    public DbSet<RationAmountChangeEvent> RationAmountChangeEvents { get; set; }
    public DbSet<RuleSection> RuleSections { get; set; }
    public DbSet<StoryEvent> StoryEvents { get; set; }
    public DbSet<StorySection> StorySections { get; set; }
    
    // Join Tables
    public DbSet<AbilityEffect> AbilityEffects { get; set; }
    public DbSet<CreatureAbility> CreatureAbilities { get; set; }
    public DbSet<ItemEffect> ItemEffects { get; set; }
    public DbSet<Occupation> BookAuthors { get; set; }
    
    // undefined
    public DbSet<Ability> Abilities { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Creature> Creatures { get; set; }
    public DbSet<ImageDecorator> ImageDecorators { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<PlayerLevel> PlayerLevels { get; set; }

    public PlaybookDbContext(DbContextOptions<PlaybookDbContext> options) : base (options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // multiple key
        modelBuilder.Entity<Occupation>()
            .HasKey(b => new { b.BookId, b.AuthorId, b.OccupationType });
        
        modelBuilder.Entity<ItemEffect>()
            .HasKey(i => new { i.ItemId, i.EffectId });
        
        modelBuilder.Entity<AbilityEffect>()
            .HasKey(a => new { a.AbilityType, a.EffectId });
        
        modelBuilder.Entity<CreatureAbility>()
            .HasKey(c => new { c.CreatureId, c.AbilityType });
        
        // Relations
        modelBuilder.Entity<Occupation>()
            .HasOne(b => b.Book)
            .WithMany()
            .HasForeignKey(b => b.BookId);
        
        modelBuilder.Entity<Occupation>()
            .HasOne(b => b.Author)
            .WithMany()
            .HasForeignKey(b => b.AuthorId);

        modelBuilder.Entity<ASection>()
            .HasOne(s => s.Book)
            .WithMany()
            .HasForeignKey(s => s.BookId);
        
        modelBuilder.Entity<ImageDecorator>()
            .HasOne(i => i.Section)
            .WithOne()
            .HasForeignKey<ImageDecorator>(i => i.SectionId);
        
        modelBuilder.Entity<ItemEffect>()
            .HasOne(i => i.Item)
            .WithMany()
            .HasForeignKey(i => i.ItemId);
        
        modelBuilder.Entity<ItemEffect>()
            .HasOne(i => i.Effect)
            .WithMany()
            .HasForeignKey(i => i.EffectId);

        modelBuilder.Entity<AbilityEffect>()
            .HasOne(a => a.Effect)
            .WithMany()
            .HasForeignKey(a => a.EffectId);
        
        modelBuilder.Entity<AbilityEffect>()
            .HasOne(a => a.Ability)
            .WithMany()
            .HasForeignKey(a => a.AbilityType);
        
        modelBuilder.Entity<AbilityOutcome>()
            .HasOne(a => a.Ability)
            .WithMany()
            .HasForeignKey(a => a.AbilityType);

        modelBuilder.Entity<AOutcome>()
            .HasOne(o => o.RootASection)
            .WithMany()
            .HasForeignKey(o => o.RootSectionId);
        
        modelBuilder.Entity<AOutcome>()
            .HasOne(o => o.Section)
            .WithMany()
            .HasForeignKey(o => o.SectionId);

        modelBuilder.Entity<CreatureAbility>()
            .HasOne(c => c.Creature)
            .WithMany()
            .HasForeignKey(c => c.CreatureId);
        
        modelBuilder.Entity<CreatureAbility>()
            .HasOne(c => c.Ability)
            .WithMany()
            .HasForeignKey(c => c.AbilityType);
        
        modelBuilder.Entity<ItemOutcome>()
            .HasOne(i => i.Item)
            .WithMany()
            .HasForeignKey(i => i.ItemId);
        
        modelBuilder.Entity<StorySection>()
            .HasOne(s => s.ARegion)
            .WithMany()
            .HasForeignKey(s => s.RegionId);
        
        modelBuilder.Entity<ARegion>()
            .HasOne(r => r.Area)
            .WithMany()
            .HasForeignKey(r => r.AreaId);
        
        modelBuilder.Entity<AEvent>()
            .HasOne(e => e.Section)
            .WithMany()
            .HasForeignKey(e => e.SectionId);
        
        modelBuilder.Entity<CombatEvent>()
            .HasOne(c => c.Creature)
            .WithMany()
            .HasForeignKey(c => c.CreatureId);
        
        modelBuilder.Entity<AItemEvent>()
            .HasOne(i => i.Item)
            .WithMany()
            .HasForeignKey(i => i.ItemId);
        
        // Single Table
        modelBuilder.Entity<Item>()
            .HasDiscriminator<string>("ITEM_TYPE")
            .HasValue<Weapon>("WEAPON")
            .HasValue<MagicalItem>("MAGICAL_ITEM")
            .HasValue<Backpack>("BACKPACK")
            .HasValue<Key>("KEY")
            .HasValue<Herb>("HERB")
            .HasValue<Gem>("GEM")
            .HasValue<Potion>("POTION")
            .HasValue<Scroll>("SCROLL")
            .HasValue<Utility>("UTILITY");
        
        // Enums
        modelBuilder.Entity<ARegion>().Property(r => r.RegionType).HasConversion<string>();
        modelBuilder.Entity<Occupation>().Property(o => o.OccupationType).HasConversion<string>();
        modelBuilder.Entity<RuleSection>().Property(r => r.SectionType).HasConversion<string>();
        modelBuilder.Entity<Item>().Property(i => i.Weight).HasConversion<string>();
        modelBuilder.Entity<Ability>().Property(a => a.AbilityType).HasConversion<string>();
        modelBuilder.Entity<PlayerLevel>().Property(p => p.Level).HasConversion<string>();
    }
}