using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LinqToSql.Model.Entities;

public class CourseEnrollment
{
    public CourseEnrollment() { }

    public CourseEnrollment(Student student, Course course, string enrollmentPeriod)
    {
        Student = student;
        Course = course;
        EnrollmentPeriod = enrollmentPeriod;
    }

    public int StudentId { get; set; }
    public Student Student { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }

    public int? Grade { get; set; }
    public string EnrollmentPeriod { get; set; } 
}