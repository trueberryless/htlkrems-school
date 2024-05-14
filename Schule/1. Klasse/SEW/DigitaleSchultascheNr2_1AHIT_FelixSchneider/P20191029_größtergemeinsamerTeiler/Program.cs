using System;

namespace P20191029_größtergemeinsamerTeiler
{
    class Program
    {
        static void Main(string[] args)
        {
            long a = 0, b = 0;
            while (true)
            {
                Console.WriteLine("Bitte geben Sie eine erste Zahl ein!");
                a = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Bitte geben Sie eine zweite Zahl ein!");
                b = Convert.ToInt64(Console.ReadLine());

                while (a != b)
                {
                    if (a > b)
                        a = a - b;
                    else
                        b = b - a;
                }
                if (b == 0)
                    Console.WriteLine("Der größte gemeinsame Teiler der beiden Zahlen ist: " + a + "\n\n");
                else
                    Console.WriteLine("Der größte gemeinsame Teiler der beiden Zahlen ist: " + b + "\n\n");
            }
            
        }
    }
}
