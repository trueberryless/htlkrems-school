using System.ComponentModel.DataAnnotations.Schema;

namespace LinqToSql.Model.Entities;

public class Student
{
    public Student() { }

    public Student(string name)
    {
        Name = name;
    }
    
    public int Id { get; set; }
    public string Name { get; set; }

    public List<CourseEnrollment> CourseEnrollments { get; set; }
}