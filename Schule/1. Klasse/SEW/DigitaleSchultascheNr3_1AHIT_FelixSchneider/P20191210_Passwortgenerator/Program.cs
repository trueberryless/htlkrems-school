using System;

namespace P20191210_Passwortgenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Wie viele Stellen soll ihr Passwort haben:\t\t\t");
            int anzahl = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                Random randy = new Random();
                Random ronny = new Random();
                string sonderzeichen = "äöüÄÖÜ$§!+*#~?";
                
                Console.WriteLine();
                for (int i = 0; i < anzahl; i++)
                {
                    if(ronny.Next(1,100) <= 40)
                    {
                        char ausgabe = (char)randy.Next(97, 97 + 26);
                        Console.Write(ausgabe);
                    }
                    else if (ronny.Next(1, 100) > 40 && ronny.Next(1, 100) <= 60)
                    {
                        char ausgabe = (char)randy.Next(65, 65 + 26);
                        Console.Write(ausgabe);
                    }
                    else if (ronny.Next(1, 100) > 60 && ronny.Next(1, 100) <= 80)
                    {
                        char ausgabe = (char)randy.Next(48, 57);
                        Console.Write(ausgabe);
                    }
                    else
                        Console.Write(sonderzeichen[randy.Next(0, sonderzeichen.Length)]);
                        
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Wie viele Stellen soll ihr Passwort haben:\t\t\t");
                anzahl = Convert.ToInt32(Console.ReadLine());
            }
                
        }
    }
}
