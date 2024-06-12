namespace LinqToSql.Model.Entities;

public class Course
{
    public Course() { }

    public Course(string courseName)
    {
        CourseName = courseName;
    }
    
    public int Id { get; set; }
    public string CourseName { get; set; }
}