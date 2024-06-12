using System;

namespace P20200918_EinfuehrungOOP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();

            p1.SetSurname("Turbo");
            p1.Firstname = "Tom";

            SVNR n1 = new SVNR();

            n1.Lfnr = 123;
            n1.Geb = new DateTime(1980, 1, 1);

            //Console.WriteLine($"{p1.Firstname} {p1.GetSurname()}");
            Console.WriteLine(n1.GetSVNR);

            SVNR n2 = new SVNR();

            n2.Lfnr = 472;
            n2.Geb = new DateTime(2005, 2, 20);

            Console.WriteLine(n2.GetSVNR);
            Console.WriteLine();

            for(int i = 100; i < 201; i++)
            {
                SVNR s1 = new SVNR();
                s1.Lfnr = i;
                s1.Geb = DateTime.Today;
                Console.WriteLine(s1.GetSVNR);
            }
        }
    }
}
