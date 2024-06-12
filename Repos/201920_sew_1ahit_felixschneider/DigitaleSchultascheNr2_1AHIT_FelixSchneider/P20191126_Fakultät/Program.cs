using System;

namespace P20191126_Fakultät
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geben Sie eine Zahl ein!");
            int zahl = Convert.ToInt32(Console.ReadLine());
            int fakultät = 1;

            while (zahl >= 1)
            {
                fakultät = fakultät * zahl;
                zahl--;
            }
            Console.WriteLine(fakultät);
        }
    }
}
