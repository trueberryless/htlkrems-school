using System;

namespace P20191029_SchleifenÜbungen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben Sie eine Zahl zwischen 0 und 100 ein!");
            int Zahl = Convert.ToInt32(Console.ReadLine());

            if (Zahl <= 1)
                Console.WriteLine("Ungültige Eingabe!");
            else if (Zahl >= 100)
                Console.WriteLine("Ungültige Eingabe!");
            else
            {
                Console.WriteLine("Bitte geben Sie einen Buchstaben ein!");
                char buchstabe = ;
            }
        }
    }
}
