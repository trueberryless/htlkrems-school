﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.Configurations;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("20221102065901_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Entities.Debitors.Debitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DEBITOR_ID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("DEBITORS");
                });

            modelBuilder.Entity("Model.Entities.Debitors.ProjectDebitor", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("PROJECT_ID");

                    b.Property<int>("DebitorId")
                        .HasColumnType("int")
                        .HasColumnName("DEBITOR_ID");

                    b.Property<float>("Amount")
                        .HasPrecision(10, 2)
                        .HasColumnType("float")
                        .HasColumnName("AMOUNT");

                    b.HasKey("ProjectId", "DebitorId");

                    b.HasIndex("DebitorId");

                    b.ToTable("PROJECT_DEBITORS_JT");
                });

            modelBuilder.Entity("Model.Entities.Facilities.AFacility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FACILITY_ID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("FACILITY_TYPE")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FacilityCode")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("varchar(7)")
                        .HasColumnName("FACILITY_CODE");

                    b.Property<string>("FacilityTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("FACILITY_TITLE");

                    b.HasKey("Id");

                    b.ToTable("FACILITIES_ST");

                    b.HasDiscriminator<string>("FACILITY_TYPE").HasValue("AFacility");
                });

            modelBuilder.Entity("Model.Entities.Projects.AProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PROJECT_ID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CREATED_AT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("LegalCode")
                        .IsRequired()
                        .HasColumnType("varchar(4)")
                        .HasColumnName("LEGAL_FOUNDATION");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("TITLE");

                    b.HasKey("Id");

                    b.HasIndex("LegalCode");

                    b.ToTable("PROJECTS_BT");
                });

            modelBuilder.Entity("Model.Entities.Projects.LegalFoundation", b =>
                {
                    b.Property<string>("Label")
                        .HasMaxLength(4)
                        .HasColumnType("varchar(4)")
                        .HasColumnName("LABEL");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("DESCRIPTION");

                    b.HasKey("Label");

                    b.ToTable("E_LEGAL_FOUNDATIONS");
                });

            modelBuilder.Entity("Model.Entities.Projects.ProjectForerunner", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("PROJECT_ID");

                    b.Property<int>("ParentProjectId")
                        .HasColumnType("int")
                        .HasColumnName("PARENT_ID");

                    b.HasKey("ProjectId", "ParentProjectId");

                    b.HasIndex("ParentProjectId");

                    b.ToTable("PROJECT_FORERUNNERS_JT");
                });

            modelBuilder.Entity("Model.Entities.Projects.ProjectState", b =>
                {
                    b.Property<string>("Label")
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.HasKey("Label");

                    b.ToTable("E_PROJECT_STATES");
                });

            modelBuilder.Entity("Model.Entities.Projects.ProjectStateItem", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("PROJECT_ID");

                    b.Property<string>("StateCode")
                        .HasColumnType("varchar(12)")
                        .HasColumnName("PROJECT_STATE");

                    b.Property<DateTime>("StateChangedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("STATE_CHANGED_AT");

                    b.HasKey("ProjectId", "StateCode", "StateChangedAt");

                    b.HasIndex("StateCode");

                    b.ToTable("PROJECT_HAS_STATES_JT");
                });

            modelBuilder.Entity("Model.Entities.Projects.Subproject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SUBPROJECT_ID");

                    b.Property<int>("AppliedResearch")
                        .HasColumnType("int")
                        .HasColumnName("APPLIED_RESEARCH");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("DESCRIPTION");

                    b.Property<int>("FocusResearch")
                        .HasColumnType("int")
                        .HasColumnName("FOCUS_RESEARCH");

                    b.Property<int>("InstituteId")
                        .HasColumnType("int")
                        .HasColumnName("INSTITUTE_ID");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("PROJECT_ID");

                    b.Property<int>("TheoreticalResearch")
                        .HasColumnType("int")
                        .HasColumnName("THEORETICAL_RESEARCH");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.HasIndex("ProjectId");

                    b.ToTable("SUBPROJECTS");
                });

            modelBuilder.Entity("Model.Entities.Projects.SubprojectState", b =>
                {
                    b.Property<string>("Label")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("LABEL");

                    b.HasKey("Label");

                    b.ToTable("E_SUBPROJECT_STATES");
                });

            modelBuilder.Entity("Model.Entities.Projects.SubprojectStateItem", b =>
                {
                    b.Property<int>("SubprojectId")
                        .HasColumnType("int")
                        .HasColumnName("SUBPROJECT_ID");

                    b.Property<string>("StateCode")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("SUBPROJECT_STATE");

                    b.Property<DateTime>("StateChangedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("STATE_CHANGED_AT");

                    b.HasKey("SubprojectId", "StateCode", "StateChangedAt");

                    b.HasIndex("StateCode");

                    b.ToTable("SUBPROJECT_HAS_STATES_JT");
                });

            modelBuilder.Entity("Model.Entities.Facilities.Faculty", b =>
                {
                    b.HasBaseType("Model.Entities.Facilities.AFacility");

                    b.ToTable("FACILITIES_ST");

                    b.HasDiscriminator().HasValue("FACULTY");
                });

            modelBuilder.Entity("Model.Entities.Facilities.Institute", b =>
                {
                    b.HasBaseType("Model.Entities.Facilities.AFacility");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int")
                        .HasColumnName("FACULTY_ID");

                    b.HasIndex("FacultyId");

                    b.ToTable("FACILITIES_ST");

                    b.HasDiscriminator().HasValue("INSTITUTE");
                });

            modelBuilder.Entity("Model.Entities.Projects.ManagementProject", b =>
                {
                    b.HasBaseType("Model.Entities.Projects.AProject");

                    b.Property<string>("ManagementDuty")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("MANAGEMENT_DUTY");

                    b.Property<DateTime>("ProjectEnd")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("PROJECT_END");

                    b.ToTable("MANAGEMENT_PROJECTS");
                });

            modelBuilder.Entity("Model.Entities.Projects.RequestFundingProject", b =>
                {
                    b.HasBaseType("Model.Entities.Projects.AProject");

                    b.Property<bool>("IsSmallProject")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("IS_SMALL_PROJECT");

                    b.ToTable("REQUEST_FUNDING_PROJECTS");
                });

            modelBuilder.Entity("Model.Entities.Projects.ResearchFundingProject", b =>
                {
                    b.HasBaseType("Model.Entities.Projects.AProject");

                    b.Property<bool>("IsEuSponsored")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("IS_EU_SPONSORED");

                    b.Property<bool>("IsFFGSponsored")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("IS_FFG_SPONSORED");

                    b.Property<bool>("IsFWFSponsored")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("IS_FWF_SPONSORED");

                    b.ToTable("RESEARCH_FUNDING_PROJECTS");
                });

            modelBuilder.Entity("Model.Entities.Debitors.ProjectDebitor", b =>
                {
                    b.HasOne("Model.Entities.Debitors.Debitor", "Debitor")
                        .WithMany()
                        .HasForeignKey("DebitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Projects.AProject", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Debitor");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Model.Entities.Projects.AProject", b =>
                {
                    b.HasOne("Model.Entities.Projects.LegalFoundation", "LegalFoundation")
                        .WithMany()
                        .HasForeignKey("LegalCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LegalFoundation");
                });

            modelBuilder.Entity("Model.Entities.Projects.ProjectForerunner", b =>
                {
                    b.HasOne("Model.Entities.Projects.AProject", "ParentProject")
                        .WithMany()
                        .HasForeignKey("ParentProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Projects.AProject", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentProject");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Model.Entities.Projects.ProjectStateItem", b =>
                {
                    b.HasOne("Model.Entities.Projects.AProject", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Projects.ProjectState", "State")
                        .WithMany()
                        .HasForeignKey("StateCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Model.Entities.Projects.Subproject", b =>
                {
                    b.HasOne("Model.Entities.Facilities.Institute", "Institute")
                        .WithMany()
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Projects.AProject", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institute");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Model.Entities.Projects.SubprojectStateItem", b =>
                {
                    b.HasOne("Model.Entities.Projects.SubprojectState", "SubprojectState")
                        .WithMany()
                        .HasForeignKey("StateCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Projects.Subproject", "Subproject")
                        .WithMany()
                        .HasForeignKey("SubprojectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subproject");

                    b.Navigation("SubprojectState");
                });

            modelBuilder.Entity("Model.Entities.Facilities.Institute", b =>
                {
                    b.HasOne("Model.Entities.Facilities.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Model.Entities.Projects.ManagementProject", b =>
                {
                    b.HasOne("Model.Entities.Projects.AProject", null)
                        .WithOne()
                        .HasForeignKey("Model.Entities.Projects.ManagementProject", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entities.Projects.RequestFundingProject", b =>
                {
                    b.HasOne("Model.Entities.Projects.AProject", null)
                        .WithOne()
                        .HasForeignKey("Model.Entities.Projects.RequestFundingProject", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entities.Projects.ResearchFundingProject", b =>
                {
                    b.HasOne("Model.Entities.Projects.AProject", null)
                        .WithOne()
                        .HasForeignKey("Model.Entities.Projects.ResearchFundingProject", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
