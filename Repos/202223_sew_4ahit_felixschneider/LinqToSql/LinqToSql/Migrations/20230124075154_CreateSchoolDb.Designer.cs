﻿// <auto-generated />
using System;
using LinqToSql.Model.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LinqToSql.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20230124075154_CreateSchoolDb")]
    partial class CreateSchoolDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LinqToSql.Model.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("LinqToSql.Model.Entities.CourseEnrollment", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("EnrollmentPeriod")
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "StudentId", "EnrollmentPeriod");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseEnrollments");
                });

            modelBuilder.Entity("LinqToSql.Model.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("LinqToSql.Model.Entities.CourseEnrollment", b =>
                {
                    b.HasOne("LinqToSql.Model.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LinqToSql.Model.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}