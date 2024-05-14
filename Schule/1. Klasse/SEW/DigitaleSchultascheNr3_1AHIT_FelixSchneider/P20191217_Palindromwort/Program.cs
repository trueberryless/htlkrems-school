using System;

namespace P20191217_Palindromwort
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string wort = "";
                Console.Write("Bitte geben Sie eine Zahl oder ein Wort ein:\t\t\t");
                wort = Console.ReadLine().ToLower();

                for (int i = 0; i < wort.Length / 2; i++)
                {
                    if (wort[i] != wort[wort.Length - i - 1])
                    {
                        Console.Write("kein ");
                        break;
                    }
                }
                Console.WriteLine("Palindrom");
            }
        }
    }
}
