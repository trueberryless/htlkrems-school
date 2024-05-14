using System;

namespace P20191010_einfacherBinärumrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            int zahl = 0, erg = 0,zahlenspeicher = 0;
            string a = "";
            Console.Write("Bitte geben Sie eine Zahl ein ");
            zahl = Convert.ToInt32(Console.ReadLine());
            zahlenspeicher = zahl;

            while (zahl> 0)
            {
                erg = zahl % 2;
                zahl = zahl / 2;
                a = erg + a;
                
            }
            Console.WriteLine("Die Zahl {0} ist binär {1}",zahlenspeicher, a);
        }
    }
}
