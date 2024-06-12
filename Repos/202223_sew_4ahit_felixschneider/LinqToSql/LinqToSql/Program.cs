using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToSql.Model.Configuration;
using LinqToSql.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinqToSql;

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

        await CleanupOldData();
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

        await using var context = new SchoolContext();

        var enrollments = await context.CourseEnrollments.ToListAsync();

        foreach (var enrollment in enrollments)
        {
            enrollment.Grade = new Random().Next(1, 6);
        }

        enrollments[0].Grade = 1;
        enrollments[1].Grade = 5;
        enrollments[2].Grade = null;
        
        context.CourseEnrollments.UpdateRange(enrollments);
        await context.SaveChangesAsync();
        
        Console.WriteLine("DONE");
    }

    private static async Task Query1()
    {
        Console.WriteLine("List all students that have at least one 5 as a grade ...");
        
        await using var context = new SchoolContext();
        var enrollments = context.CourseEnrollments;

        var data = await enrollments
            .Where(e => e.Grade == 5)
            .Select(e => e.StudentId)
            .Distinct()
            .ToListAsync();

        foreach (var student in data)
        {
            Console.WriteLine(student);
        }

        Console.WriteLine("DONE");
    }

    private static async Task Query2()
    {
        Console.WriteLine("List the average grade for each student ...");
        
        await using var context = new SchoolContext();

        var data = await context.CourseEnrollments
            .GroupBy(
                e => e.Student,
                (key, studentEnrollment)
                    => new
                    {
                        studentName = key.Name,
                        average_grade = studentEnrollment.Select(s => s.Grade).Average()
                    }
                )
            .ToListAsync();

        foreach (var averageGrade in data)
        {
            Console.WriteLine(averageGrade.studentName + ": " + averageGrade.average_grade);
        }

        var data2 = await context.Students.Select(
            s => new
            {
                studentName = s.Name,
                average_grade = s.CourseEnrollments.Average(e => e.Grade)
            }).ToListAsync();

        foreach (var averageGrade2 in data2)
        {
            Console.WriteLine(averageGrade2.studentName + ": " + averageGrade2.average_grade);
        }
        
        Console.WriteLine("DONE");
    }

    private static async Task Query3()
    {
        Console.WriteLine("List the minimum and maximum grade for each course ...");
        
        await using var context = new SchoolContext();

        var data = await context.CourseEnrollments
            .GroupBy(
                e => e.Course,
                (key, courseEnrollment)
                    => new
                    {
                        courseName = key.CourseName,
                        minimum_grade = courseEnrollment.Min(c => c.Grade),
                        maximum_grade = courseEnrollment.Max(c => c.Grade)
                    }
                )
            .ToListAsync();

        foreach (var courseData in data)
        {
            Console.WriteLine(courseData.courseName + ": Min: " + courseData.minimum_grade + "; Max: " + courseData.maximum_grade);
        }
        
        Console.WriteLine("DONE");
    }

    private static async Task Query4()
    {
        Console.WriteLine("List all students where a grade has not been given yet");
        // TODO: output should be like:
        // student 1
        //   course with missing grade 1 --> if last number should be grade number, there will be none because grade == null
        //   course with missing grade 2 --> because of that, I will print the number of missing grades like in an ordered list
        //   ...
        // student 2
        //   course with missing grade 1
        //   ...

        await using var context = new SchoolContext();

        var data = await context.CourseEnrollments
            .Where(e => e.Grade == null)
            .GroupBy(
                e => e.StudentId,
                (key, studentGroup)
                => new
                {
                    studentName = key,
                    number_of_missing_values = studentGroup.Select(s => s.CourseId).Count()
                })
            .ToListAsync();

        for (var i = 0; i < data.Count; i++)
        {
            var enrollment = data.ToList()[i];
            Console.WriteLine("student " + enrollment.studentName);
            for (var j = 0; j < data.ToList()[i].number_of_missing_values; j++)
            {
                Console.WriteLine("  course with missing grade " + (int)(j + 1));
            }
        }
        
        Console.WriteLine("DONE");
    }

    private static async Task CleanupOldData()
    {
        Console.WriteLine("Delete ABAP Programming course and every course enrollment linked to it.");
        // TODO
        
        await using var context = new SchoolContext();
        
        var courses = await context.Courses.ToListAsync();
        var enrollments = await context.CourseEnrollments.ToListAsync();

        var course = courses.FirstOrDefault(c => c.CourseName == "Programming in COBOL 1");
        // var courseEnrollments = enrollments.Where(e => course != null && e.CourseId == course.Id).ToList();
        
        if(course != null)
            context.Courses.Remove(course);
        // if(courseEnrollments.Any())
        //    context.CourseEnrollments.RemoveRange(courseEnrollments);
        await context.SaveChangesAsync();
        
        // or:
        context.Courses.Remove(new Course() { Id = 4 });

        Console.WriteLine("DONE");
    }
}