using System;

namespace P20201209_Firma
{
    class Program
    {
        static void Main(string[] args)
        {
            Person a = new Person();
            Person b = new Person("Susi");
            Person c = new Person("Tom", "Turbo");

            Employee e = new Employee(10, "Tom", "Muster");
            Console.WriteLine(e.GetMonthlySalary(80));

            Employee e1 = new Employee(12, "Susi", "Sorglos");
            Console.WriteLine(e1.GetMonthlySalary(120, 100));
        }
    }
}
