using System;

namespace P20191008_Binärumrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            int zahl = 0, erg = 0;
            Console.WriteLine("bitte geben Sie eine zahl ein!");
            zahl = Convert.ToInt32(Console.ReadLine());

            while (true)
            {                
                erg = zahl % 2;
                zahl = zahl / 2;
                Console.WriteLine(zahl);
            }
        }
    }
}
