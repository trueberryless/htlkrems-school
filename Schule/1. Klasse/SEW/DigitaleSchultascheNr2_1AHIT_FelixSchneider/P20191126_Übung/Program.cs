using System;

namespace P20191126_Übung
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geben Sie drei Zahlen ein!");
            Console.WriteLine("(Mit ENTER trennen!)");
            Console.Write("Zahl 1:\t\t\t\t\t");
            int zahl1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Zahl 2:\t\t\t\t\t");
            int zahl2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Zahl 3:\t\t\t\t\t");
            int zahl3 = Convert.ToInt32(Console.ReadLine());

            if (zahl1 > zahl2)
            {
                if (zahl1 > zahl3)
                {
                    Console.WriteLine("Zahl 1 (Wert: {0}) ist die größte Zahl!", zahl1);
                }
                else if(zahl3 > zahl1)
                {
                    Console.WriteLine("Zahl 3 (Wert: {0}) ist die größte Zahl!", zahl3);
                }
                else if(zahl1 == zahl3)
                {
                    Console.Write("Zahl 1 (Wert: {0}) und Zahl 3 (Wert: {1}) sind gleich groß!", zahl1, zahl3);
                }
                else
                {
                    Console.WriteLine("Fehler!");
                }
            }
            else if (zahl2 > zahl1)
            {
                if (zahl2 > zahl3)
                {
                    Console.WriteLine("Zahl 2 (Wert: {0}) ist die größte Zahl!", zahl2);
                }
                else if (zahl3 > zahl2)
                {
                    Console.WriteLine("Zahl 3 (Wert: {0}) ist die größte Zahl!", zahl3);
                }
                else if (zahl2 == zahl3)
                {
                    Console.Write("Zahl 2 (Wert: {0}) und Zahl 3 (Wert: {1}) sind gleich groß!", zahl2, zahl3);
                }
                else
                {
                    Console.WriteLine("Fehler!");
                }
            }


        }
    }
}
