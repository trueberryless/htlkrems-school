using System;

namespace P20191125_for_Schleifen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geben Sie eine Zahl ein:\t");
            while (true)
            {
                int zahl = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Wählen Sie eine Variante!");
                Console.Write("A/B:\t\t\t\t");
                string v = Console.ReadLine();
                Console.WriteLine();

                if (v.ToUpper() == "A")
                {
                    for (int i = 0; i < zahl; i++)
                    {
                        for (int j = zahl; j > i; j--)
                            Console.Write("*");
                        for (int j = 0; j < i; j++)
                            Console.Write(" ");
                        Console.Write("*");
                        for (int j = 0; j < i; j++)
                            Console.Write("*");
                        for (int j = zahl; j > i; j--)
                            Console.Write(" ");
                        Console.WriteLine();
                    }
                    for (int i = 0; i < zahl; i++)
                    {
                        for (int j = 0; j < i; j++)
                            Console.Write(" ");
                        for (int j = zahl; j > i; j--)
                            Console.Write("*");
                        for (int j = zahl; j > i + 1; j--)
                            Console.Write(" ");
                        Console.Write("*");
                        for (int j = 0; j < i; j++)
                            Console.Write("*");
                        Console.WriteLine();
                    }
                }
                else if (v.ToUpper() == "B")
                {
                    for (int i = 0; i < zahl; i++)
                    {
                        for (int j = zahl; j > i + 1; j--)
                            Console.Write(" ");
                        Console.Write("*");
                        for (int j = 0; j < i; j++)
                            Console.Write("*");
                        for (int j = 0; j < i; j++)
                            Console.Write(" ");
                        for (int j = zahl; j > i; j--)
                            Console.Write("*");
                        Console.WriteLine();
                    }
                    for (int i = 0; i < zahl; i++)
                    {
                        Console.Write("*");
                        for (int j = 0; j < i; j++)
                            Console.Write("*");
                        for (int j = zahl; j > i + 1; j--)
                            Console.Write(" ");
                        for (int j = zahl; j > i; j--)
                            Console.Write("*");
                        for (int j = 0; j < i; j++)
                            Console.Write(" ");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("keine gültige Variante!");
                }
                Console.Write("\n\nGeben Sie eine Zahl ein:\t");
            }
            
        }
    }
}
