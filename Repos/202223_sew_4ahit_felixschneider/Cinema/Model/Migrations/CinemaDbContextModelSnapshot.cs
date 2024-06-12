﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.Configuration;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    partial class CinemaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ADDRESS_ID");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("COUNTRY");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("LOCATION");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("POSTAL_CODE");

                    b.Property<string>("StateCode")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("STATE");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("STREET");

                    b.HasKey("Id");

                    b.HasIndex("CountryName");

                    b.HasIndex("StateCode");

                    b.ToTable("ADDRESSES");
                });

            modelBuilder.Entity("Model.Entities.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CINEMA_ID");

                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("ADDRESS_ID");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("LABEL");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("CINEMAS");
                });

            modelBuilder.Entity("Model.Entities.Country", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NAME");

                    b.HasKey("Name");

                    b.ToTable("E_COUNTRIES");
                });

            modelBuilder.Entity("Model.Entities.Hall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("HALL_ID");

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("CAPACITY");

                    b.Property<int>("CinemaId")
                        .HasColumnType("int")
                        .HasColumnName("CINEMA_ID");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("CODE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("HALLS");
                });

            modelBuilder.Entity("Model.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MOVIE_ID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("DESCRIPTION");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasColumnName("DURATION");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("NAME");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("SHORT_DESCRIPTION");

                    b.HasKey("Id");

                    b.ToTable("MOVIES");
                });

            modelBuilder.Entity("Model.Entities.Occupation", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int")
                        .HasColumnName("MOVIE_ID");

                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("PERSON_ID");

                    b.Property<string>("Role")
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("ROLE");

                    b.Property<DateTime>("OccupationBegin")
                        .HasColumnType("DATETIME(6)")
                        .HasColumnName("OCCUPATION_BEGIN");

                    b.Property<DateTime>("OccupationEnd")
                        .HasColumnType("DATETIME(6)")
                        .HasColumnName("OCCUPATION_END");

                    b.HasKey("MovieId", "PersonId", "Role", "OccupationBegin");

                    b.HasIndex("PersonId");

                    b.ToTable("OCCUPATIONS_JT");
                });

            modelBuilder.Entity("Model.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PERSON_ID");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("FIRST_NAME");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("LAST_NAME");

                    b.HasKey("Id");

                    b.ToTable("MOVIE_CREWS");
                });

            modelBuilder.Entity("Model.Entities.Screening", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int")
                        .HasColumnName("MOVIE_ID");

                    b.Property<int>("HallId")
                        .HasColumnType("int")
                        .HasColumnName("HALL_ID");

                    b.Property<DateTime>("StartsAt")
                        .HasColumnType("DATETIME(6)")
                        .HasColumnName("STARTS_AT");

                    b.Property<DateTime>("EndsAt")
                        .HasColumnType("DATETIME(6)")
                        .HasColumnName("ENDS_AT");

                    b.HasKey("MovieId", "HallId", "StartsAt");

                    b.HasIndex("HallId");

                    b.ToTable("SCREENINGS_JT");
                });

            modelBuilder.Entity("Model.Entities.State", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NAME");

                    b.HasKey("Name");

                    b.ToTable("E_STATES");
                });

            modelBuilder.Entity("Model.Entities.Address", b =>
                {
                    b.HasOne("Model.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.State", "State")
                        .WithMany()
                        .HasForeignKey("StateCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Model.Entities.Cinema", b =>
                {
                    b.HasOne("Model.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Model.Entities.Hall", b =>
                {
                    b.HasOne("Model.Entities.Cinema", "Cinema")
                        .WithMany()
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("Model.Entities.Occupation", b =>
                {
                    b.HasOne("Model.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Model.Entities.Screening", b =>
                {
                    b.HasOne("Model.Entities.Hall", "Hall")
                        .WithMany()
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hall");

                    b.Navigation("Movie");
                });
#pragma warning restore 612, 618
        }
    }
}
