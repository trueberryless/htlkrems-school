﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.Configurations;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(AosDbContext))]
    partial class AosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Entities.Attack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ATTACK_ID");

                    b.Property<string>("AttackType")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ATTACK_TYPE");

                    b.Property<int>("CreatureId")
                        .HasColumnType("int")
                        .HasColumnName("CREATURE_ID");

                    b.Property<int>("Damage")
                        .HasColumnType("int")
                        .HasColumnName("DAMAGE");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("IDENTIFIER");

                    b.HasKey("Id");

                    b.HasIndex("CreatureId");

                    b.HasIndex("Identifier")
                        .IsUnique();

                    b.ToTable("ATTACKS");
                });

            modelBuilder.Entity("Model.Entities.Creature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CREATURE_ID");

                    b.Property<int>("Armour")
                        .HasColumnType("int")
                        .HasColumnName("ARMOUR");

                    b.Property<int>("Awareness")
                        .HasColumnType("int")
                        .HasColumnName("AWARENESS");

                    b.Property<int>("Body")
                        .HasColumnType("int")
                        .HasColumnName("BODY");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("DESCRIPTION");

                    b.Property<int>("Initiative")
                        .HasColumnType("int")
                        .HasColumnName("INITIATIVE");

                    b.Property<int>("Mettle")
                        .HasColumnType("int")
                        .HasColumnName("METTLE");

                    b.Property<int>("Mind")
                        .HasColumnType("int")
                        .HasColumnName("MIND");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NAME");

                    b.Property<int>("Soul")
                        .HasColumnType("int")
                        .HasColumnName("SOUL");

                    b.Property<int>("Toughness")
                        .HasColumnType("int")
                        .HasColumnName("TOUGNESS");

                    b.Property<int>("Wounds")
                        .HasColumnType("int")
                        .HasColumnName("WOUNDS");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CREATURES");
                });

            modelBuilder.Entity("Model.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SKILL_ID");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDENTIFIER");

                    b.Property<int>("Value")
                        .HasColumnType("int")
                        .HasColumnName("SKILL_VALUE");

                    b.HasKey("Id");

                    b.HasIndex("Identifier")
                        .IsUnique();

                    b.ToTable("SKILLS");
                });

            modelBuilder.Entity("Model.Entities.SkillItem", b =>
                {
                    b.Property<int>("CreatureId")
                        .HasColumnType("int")
                        .HasColumnName("CREATURE_ID");

                    b.Property<int>("SkillId")
                        .HasColumnType("int")
                        .HasColumnName("SKILL_ID");

                    b.HasKey("CreatureId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("CREATURE_HAS_SKILLS_JT");
                });

            modelBuilder.Entity("Model.Entities.Trait", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TRAIT_ID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("IDENTIFIER");

                    b.HasKey("Id");

                    b.HasIndex("Identifier")
                        .IsUnique();

                    b.ToTable("TRAITS");
                });

            modelBuilder.Entity("Model.Entities.TraitItem", b =>
                {
                    b.Property<int>("CreatureId")
                        .HasColumnType("int")
                        .HasColumnName("CREATURE_ID");

                    b.Property<int>("TraitId")
                        .HasColumnType("int")
                        .HasColumnName("TRAIT_ID");

                    b.HasKey("CreatureId", "TraitId");

                    b.HasIndex("TraitId");

                    b.ToTable("CREATURE_HAS_TRAITS_JT");
                });

            modelBuilder.Entity("Model.Entities.Attack", b =>
                {
                    b.HasOne("Model.Entities.Creature", "Creature")
                        .WithMany()
                        .HasForeignKey("CreatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creature");
                });

            modelBuilder.Entity("Model.Entities.SkillItem", b =>
                {
                    b.HasOne("Model.Entities.Creature", "Creature")
                        .WithMany()
                        .HasForeignKey("CreatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creature");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Model.Entities.TraitItem", b =>
                {
                    b.HasOne("Model.Entities.Creature", "Creature")
                        .WithMany()
                        .HasForeignKey("CreatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Trait", "Trait")
                        .WithMany()
                        .HasForeignKey("TraitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creature");

                    b.Navigation("Trait");
                });
#pragma warning restore 612, 618
        }
    }
}
