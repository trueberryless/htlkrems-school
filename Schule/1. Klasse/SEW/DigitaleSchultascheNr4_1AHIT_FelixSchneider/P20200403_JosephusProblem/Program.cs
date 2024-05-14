using System;

namespace P20200403_JosephusProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Josephus Problem");
            Console.Write("Anzahl an Personen im Kreis:\t");
            int n = Convert.ToInt32(Console.ReadLine());
            int l = 0;
            for (int a = 0; (int)Math.Pow(2, a) <= n; a++)
            {
                l = (n - (int)Math.Pow(2, a)) * 2 + 1;
            }
            Console.WriteLine("Die {0}. Person überlebt!", l);
        }
    }
}
