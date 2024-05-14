using System;
using System.Linq;

namespace P20191008_Binärumrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int zahl = 0, erg = 0, zahlenspeicher = 0;
                string a = "";
                Console.Write("Bitte geben Sie eine Zahl ein: ");
                string e = Console.ReadLine();

                try
                {
                    zahl = Convert.ToInt32(e);
                }
                catch
                {
                    if(e == "exit")
                    {
                        Environment.Exit(0);
                        Console.WriteLine("Das Programm wurde beendet");
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
                    erg = zahl % 2;
                    zahl = zahl / 2;
                    a = erg + a;

                }
                if (zahlenspeicher == 0)
                {
                    a = "0";
                }
                Console.WriteLine("\n");
                Console.WriteLine("Die Zahl {0} ist binär {1}!", zahlenspeicher, a);
                Console.ReadLine();
                Console.Clear();
               

            }
            
        }
    }
}
