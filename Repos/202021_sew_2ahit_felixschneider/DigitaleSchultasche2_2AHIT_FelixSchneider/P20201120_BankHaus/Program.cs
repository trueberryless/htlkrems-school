using System;

namespace P20201120_BankHaus
{
    class Program
    {
        static void Sparbuch()
        {
            Sparbuch s = new Sparbuch("Müller", 2, 0.23);
            s.Einzahlen(500);
            Console.WriteLine(s);
            Console.WriteLine(s.Abheben(600));
            Console.WriteLine(s);
        }

        static void GiroKonto()
        {
            GiroKonto g = new GiroKonto("Schneider", 3, 100);
            g.Einzahlen(100);
            Console.WriteLine(g);
            Console.WriteLine(g.Abheben(300));
            Console.WriteLine(g);
        }
        
        static void Main(string[] args)
        {
            Bank b = new Bank();
            b.HinzuSparbuch("Peter Parker", 0.24, 50);
            b.HinzuSparbuch("Paul Patrol", 0.24, 40);
            b.HinzuSparbuch("Pontius Pon Pilatus", 0.24, -1000);
            b.HinzuGirokonto("Alfred", 1000, 6.5, -403);
            b.HinzuGirokonto("Andi", 100, 1.01, 324);
            b.HinzuGirokonto("Argus", 20000, 8, 953);

            b.Auflistung();
            b.TagesAbschlussAll();
            b.Auflistung();

            Sparbuch s = new Sparbuch("Müller", 2, 0.23);

            GiroKonto g = new GiroKonto("Schneider", 3, 100);

            Console.WriteLine();
            Console.WriteLine(s.GetType());

            b.Weltspartag();
        }
    }
}
