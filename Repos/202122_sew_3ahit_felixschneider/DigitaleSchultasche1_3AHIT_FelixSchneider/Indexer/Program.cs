using System;

namespace Indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            Stundentmanager sm = new Stundentmanager();

            sm.Add(new Student(new DateTime(2005, 03, 14)));
            sm.Add(new Student(new DateTime(2006, 07, 20)));
            sm.Add(new Student(new DateTime(2004, 09, 28)));
            sm.Add(new Student(new DateTime(2005, 12, 19)));
            sm.Add(new Student(new DateTime(2006, 06, 04)));
            sm.Add(new Student(new DateTime(2004, 03, 08)));
            sm.Add(new Student(new DateTime(2007, 02, 14)));
            sm.Add(new Student(new DateTime(2003, 05, 13)));
            sm.Add(new Student(new DateTime(2005, 02, 08)));
            sm.Add(new Student(new DateTime(2004, 11, 20)));

            Student looking_for = sm[new DateTime(2006, 06, 04)];
            Console.WriteLine(looking_for.Birth);

            Student looking_for2 = sm[03, 14];
            Console.WriteLine(looking_for2.Birth);
        }
    }
}
