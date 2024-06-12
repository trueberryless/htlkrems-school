using System;

namespace _20190917_Begrüßung
{
    class Program
    {
        static void Main(string[] args)
        {
            string name, eingabe ="";
            do
            {
                Console.WriteLine("Hallo, wie ist dein Name?");

                name = Console.ReadLine();
                Console.WriteLine("Hallo " + name + ", herzlich willkommen an der HTL Krems");

                Console.WriteLine("Abruch mit A!");
                eingabe = Console.ReadLine();
            } while (eingabe != "A");
            Console.WriteLine("Das Programm wurde beendet!");
        }
    }
}

