using LinqToSql.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinqToSql.Model.Configuration;

public class SchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(@"server=localhost; port=3306; database=schooldb; user=insy; password=insy; Persist Security Info=False; Connect Timeout=300",
                new MySqlServerVersion(new Version(8, 0, 27)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseEnrollment>()
            .HasKey(ce => new { ce.CourseId, ce.StudentId, ce.EnrollmentPeriod });
    }
}