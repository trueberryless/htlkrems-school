using LinqToSqlExamples.Model.Configuration;
using LinqToSqlExamples.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinqToSqlExamples;

public static class Program
{
    public static async Task Main(string[] args)
    {
        await SetupTestData();

        await UpdateGrades();

        await Query1();

        await Query2();

        await Query3();

        await Query4();

        await CeanupOldData();
    }

    private static async Task SetupTestData()
    {
        Console.Write("Setting up test data ... ");
        await using var context = new SchoolContext();
        if (await context.Students.AnyAsync())
        {
            Console.WriteLine("SKIPPED");
            return;
        }

        var students = new List<Student>()
        {
            new Student("Fritz"),
            new Student("Ellie"),
            new Student("Ferdl"),
            new Student("Lisa")
        };

        var courses = new List<Course>()
        {
            new Course("Software Entwicklung 4"),
            new Course("Datenbanken 4"),
            new Course("Verteilte Systeme 5"),
            new Course("Programming in COBOL 1")
        };

        var enrollments = new List<CourseEnrollment>()
        {
            new CourseEnrollment(students[0], courses[0], "2022/23"),
            new CourseEnrollment(students[1], courses[0], "2022/23"),
            new CourseEnrollment(students[2], courses[0], "2022/23"),
            new CourseEnrollment(students[3], courses[0], "2022/23"),
            new CourseEnrollment(students[0], courses[1], "2022/23"),
            new CourseEnrollment(students[1], courses[1], "2022/23"),
            new CourseEnrollment(students[2], courses[1], "2022/23"),
            new CourseEnrollment(students[3], courses[1], "2022/23"),
            new CourseEnrollment(students[1], courses[2], "2022/23"),
            new CourseEnrollment(students[0], courses[3], "1992/93")
        };
        
        await context.Students.AddRangeAsync(students);
        await context.Courses.AddRangeAsync(courses);
        await context.CourseEnrollments.AddRangeAsync(enrollments);
        await context.SaveChangesAsync();

        Console.WriteLine("DONE");
    }
    
    private static async Task UpdateGrades()
    {
        Console.Write("Setting grades ... ");
        // TODO: update existing CourseEnrollments, setting some grades.
        // TODO: give at least one 1, one 5, and leave at least one grade NULL

        Console.WriteLine("DONE");
    }
    
    private static async Task Query1()
    {
        Console.WriteLine("List all students that have at least one 5 as a grade ...");
        // TODO
        Console.WriteLine("DONE");
    }
    
    private static async Task Query2()
    {
        Console.WriteLine("List the average grade for each student ...");
        // TODO
        Console.WriteLine("DONE");
    }
    
    private static async Task Query3()
    {
        Console.WriteLine("List the minimum and maximum grade for each course ...");
        // TODO
        Console.WriteLine("DONE");
    }

    private static async Task Query4()
    {
        Console.WriteLine("List all students where a grade has not been given yet");
        // TODO: output should be like:
        // student 1
        //   course with missing grade 1
        //   course with missing grade 2
        //   ...
        // student 2
        //   course with missing grade 1
        //   ...

        Console.WriteLine("DONE");
    }
    
    private static async Task CeanupOldData()
    {
        Console.WriteLine("Delete ABAP Programming course and every course enrollment linked to it.");
        // TODO
        Console.WriteLine("DONE");
    }
}



