using System;

namespace P20191010_Umrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            int basis = 2;
            while (true)
            {
                int zahl = 0, erg = 0, zahlenspeicher = 0;
                string a = "";               
                
                Console.Write("Geben Sie eine Zahl ein: ");
                string zahlenüberprüfer = Console.ReadLine();
               
                try
                {
                    zahl = Convert.ToInt32(zahlenüberprüfer);                    
                }
                catch
                {
                    if (zahlenüberprüfer == "Exit")
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Das Programm wurde beendet!");
                        Environment.Exit(0);
                        
                    }
                    else
                    {
                        Console.WriteLine("Dies ist keine gültige Eingabe!");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                }
                
                if (zahl < 0)
                {
                    Console.WriteLine("Dies ist keine positive Zahl!");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                zahlenspeicher = zahl;
                while (zahl > 0)
                {
                    erg = zahl % basis;
                    zahl = zahl / basis;
                    a = erg + a;

                }
                if (zahlenspeicher == 0)
                {
                    a = "0";
                }
                Console.WriteLine("\n");
                Console.WriteLine("Die Zahl {0} ist in Basis {1}: {2}!", zahlenspeicher,basis, a);
                Console.ReadLine();
                Console.Clear();
            }
            Console.WriteLine("\n");
            Console.WriteLine("Das Programm wurde beendet!");


        }
    }
}
