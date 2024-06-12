using Microsoft.EntityFrameworkCore;
using Model.Entities.Debitors;
using Model.Entities.Facilities;
using Model.Entities.Projects;

namespace Model.Configurations; 

public class ProjectDbContext : DbContext {

    public DbSet<LegalFoundation> LegalFoundations { get; set; }
    
    public DbSet<ProjectState> ProjectStates { get; set; }

    public DbSet<AProject> Projects { get; set; }

    public DbSet<RequestFundingProject> RequestFundingProjects { get; set; }

    public DbSet<ResearchFundingProject> ResearchFundingProjects { get; set; }

    public DbSet<ProjectStateItem> ProjectStateItems { get; set; }

    public DbSet<ProjectForerunner> ProjectForerunners { get; set; }

    public DbSet<ManagementProject> ManagementProjects { get; set; }

    public DbSet<AFacility> Facilities { get; set; }

    public DbSet<Faculty> Faculties { get; set; }

    public DbSet<Institute> Institutes { get; set; }

    public DbSet<Subproject> Subprojects { get; set; }

    public DbSet<SubprojectState> SubprojectStates { get; set; }

    public DbSet<SubprojectStateItem> SubprojectStateItems { get; set; }

    public DbSet<Debitor> Debitors { get; set; }

    public DbSet<ProjectDebitor> ProjectDebitors { get; set; }
    
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) {
        
    }

    protected override void OnModelCreating(ModelBuilder builder) {
        builder.Entity<AProject>()
            .HasOne(p => p.LegalFoundation)
            .WithMany()
            .HasForeignKey(p => p.LegalCode);

        builder.Entity<ProjectStateItem>()
            .HasKey(psi => new { psi.ProjectId, psi.StateCode, psi.StateChangedAt });
        
        builder.Entity<ProjectStateItem>()
            .HasOne(p => p.Project)
            .WithMany()
            .HasForeignKey(p => p.ProjectId);
        
        builder.Entity<ProjectStateItem>()
            .HasOne(p => p.State)
            .WithMany()
            .HasForeignKey(p => p.StateCode);

        builder.Entity<ProjectForerunner>()
            .HasKey(pf => new { pf.ProjectId, pf.ParentProjectId});
        
        builder.Entity<ProjectForerunner>()
            .HasOne(p => p.Project)
            .WithMany()
            .HasForeignKey(p => p.ProjectId);
        
        builder.Entity<ProjectForerunner>()
            .HasOne(p => p.ParentProject)
            .WithMany()
            .HasForeignKey(p => p.ParentProjectId);

        builder.Entity<ManagementProject>()
            .Property(mp => mp.ManagementDuty)
            .HasConversion<string>();

        builder.Entity<AFacility>()
            .HasDiscriminator<string>("FACILITY_TYPE")
            .HasValue<Faculty>("FACULTY")
            .HasValue<Institute>("INSTITUTE");

        builder.Entity<Institute>()
            .HasOne(i => i.Faculty)
            .WithMany()
            .HasForeignKey(i => i.FacultyId);

        builder.Entity<Subproject>()
            .HasOne(s => s.Project)
            .WithMany()
            .HasForeignKey(s => s.ProjectId);
        
        builder.Entity<Subproject>()
            .HasOne(s => s.Institute)
            .WithMany()
            .HasForeignKey(s => s.InstituteId);

        builder.Entity<SubprojectStateItem>()
            .HasKey(ssi => new { ssi.SubprojectId, ssi.StateCode, ssi.StateChangedAt});
        
        builder.Entity<SubprojectStateItem>()
            .HasOne(ssi => ssi.Subproject)
            .WithMany()
            .HasForeignKey(ssi => ssi.SubprojectId);
        
        builder.Entity<SubprojectStateItem>()
            .HasOne(ssi => ssi.SubprojectState)
            .WithMany()
            .HasForeignKey(ssi => ssi.StateCode);

        builder.Entity<ProjectDebitor>()
            .HasKey(pd => new { pd.ProjectId, pd.DebitorId });
        
        builder.Entity<ProjectDebitor>()
            .HasOne(pd => pd.Project)
            .WithMany()
            .HasForeignKey(pd => pd.ProjectId);
        
        builder.Entity<ProjectDebitor>()
            .HasOne(pd => pd.Debitor)
            .WithMany()
            .HasForeignKey(pd => pd.DebitorId);
    }
}