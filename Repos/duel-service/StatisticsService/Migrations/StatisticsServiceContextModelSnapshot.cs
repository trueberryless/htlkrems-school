﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StatisticsService.MyDbContext;

#nullable disable

namespace StatisticsService.Migrations
{
    [DbContext(typeof(StatisticsServiceContext))]
    partial class StatisticsServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("StatisticsService.Model.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("AverageDuelDuration")
                        .HasColumnType("REAL");

                    b.Property<int>("CurrentEloRanking")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastDuelPlayedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfDuelsDraw")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfDuelsLost")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfDuelsPlayed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfDuelsWon")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("PLAYERS");
                });
#pragma warning restore 612, 618
        }
    }
}
