using System;

namespace P20191123_Dreiecke
{
    class Program
    {
        static void Main(string[] args)
        {
            int zahl = 0;
            Console.WriteLine("Geben Sie eine Zahl ein!");
            zahl = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < zahl; i++)
            {
                for (int j = zahl; j > i; j--)
                {
                    Console.Write("*");
                }

                for (int j = 0; j < i; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(" ");

                for (int j = zahl; j > i; j--)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            
        }
    }
}
