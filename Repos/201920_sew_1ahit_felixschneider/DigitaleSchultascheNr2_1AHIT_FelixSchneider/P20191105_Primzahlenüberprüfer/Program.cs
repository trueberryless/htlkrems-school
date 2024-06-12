using System;

namespace P20191105_Primzahlenüberprüfer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben Sie eine Zahl ein!");
            long n = Convert.ToInt64(Console.ReadLine());
            while (n != 0)
            {       
                int t = 0, i = 1;           //t= Teileranzahl & i= Laufvariable
                while (i <= n)              //Wenn die Zahl 0 ist, wird das Programm beendet
                {
                    if (n % i == 0)         //wird ausgeführt, wenn der Rest von der Zahl und der Laufvariable 0 ist
                        t++;                //Die teileranzahl wird um eins erhöht
                    i++;
                }
                if (t == 2)
                    Console.WriteLine("\n{0} ist eine Primzahl!", n);
                else
                    Console.WriteLine("\n{0} ist keine Primzahl!", n);
                Console.WriteLine("\n\nBitte geben Sie eine Zahl ein!");
                n = Convert.ToInt64(Console.ReadLine());
            }
            Console.WriteLine("\nDas Programm wurde beendet!");
            
        }
    }
}
