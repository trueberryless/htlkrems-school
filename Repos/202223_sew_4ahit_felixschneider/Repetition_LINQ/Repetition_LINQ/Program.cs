

var class4ahit = new List<Student>
{
    new Student
    {
        Id = 1,
        FirstName = "Valentin",
        LastName = "Schmitzberger"
    },
    new Student
    {
        Id = 2,
        FirstName = "Felix",
        LastName = "Schneider"
    },
    new Student
    {
        Id = 3,
        FirstName = "Clemens",
        LastName = "Schlipfinger"
    }
};
var superStudent = new SuperStudent
{
    Id = 4,
    FirstName = "Josef",
    LastName = "Swatek",
    IsSuper = true
};

// LINQ Methode Schreibweise
var class4ahitPlusSuperStudent = new List<Student>(class4ahit);
class4ahitPlusSuperStudent.Add(superStudent);

var superStudent1 = class4ahitPlusSuperStudent.OfType<SuperStudent>().First(s => s.IsSuper == true);
Console.WriteLine(superStudent1.IsSuper);

//var objects = new List<object>();
//objects.Add(superStudent);
//objects.Add(new int[] { 1, 2, 3 });

var myResult = class4ahit.First(s => s.Id == 3);
Console.WriteLine(myResult);

var averageId = class4ahit.Average(s => s.Id);
Console.WriteLine(averageId);

// LINQ Querie Schreibweise
var myResult2 = (from student in class4ahit 
                where student.Id == 2 
                select student.FirstName).First();

Console.WriteLine(myResult2);

class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public override string ToString()
    {
        return String.Format($"{FirstName} {LastName}");
    }
}

class SuperStudent : Student 
{ 
    public bool IsSuper { get; set; }
}

class BadStudent : Student
{
    public bool IsBad { get; set; }
}