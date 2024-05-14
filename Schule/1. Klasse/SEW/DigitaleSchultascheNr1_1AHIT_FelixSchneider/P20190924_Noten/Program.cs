using System;

namespace P20190924_Noten
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            a = 0;
            Console.WriteLine("Bitte geben Sie eine Note zwischen 1 und 5 ein!");
            a = Convert.ToInt32(Console.ReadLine());

            if (a == 1)
            {
                Console.WriteLine("Sehr Gut");
            }
            else
            {
                if (a == 2)
                {
                    Console.WriteLine("Gut");
                }
                else
                {
                    if (a == 3)
                    {
                        Console.WriteLine("Befriedigend");
                    }
                    else
                    {
                        if (a == 4)
                        {
                            Console.WriteLine("Genügend");
                        }
                        else
                        {
                            if (a == 5)
                            {
                                Console.WriteLine("Nicht Genügend");
                            }  
                            else
                            {
                                Console.WriteLine("Dies ist keiine Zahl zwischen 1 und 5!");

                            }
                        }
                    }
                }

            }
        }
    }
}
