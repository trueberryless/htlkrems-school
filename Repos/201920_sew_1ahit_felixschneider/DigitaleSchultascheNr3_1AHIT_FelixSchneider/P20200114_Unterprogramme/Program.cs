using System;

namespace P20200114_Unterprogramme
{
    class Program
    {
        static void Main(string[] args)
        {
            //Zahlenadditionsprogramm

            //Copy-Paste-Code:
            //Console.Write("Erste Zahl:   ");
            //int a = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Zweite Zahl:   ");
            //int b = Convert.ToInt32(Console.ReadLine());

            // DRY - Prinzip - "Don't Repeat Yourself2
            while (true)
            {
                int a = SichereEingabe("Erste Zahl:\t");                  //Aufruf d. Unterprogrammes
                int b = SichereEingabe("Zweite Zahl:\t");                 //Aufruf d. Unterprogrammes
                int c = SichereEingabe("Dritte Zahl:\t");                 //Aufruf d. Unterprogrammes
                Console.WriteLine("Das Ergebnis ist {0}", a + b + c);
            }
            
        }

        //Unterprogramm (Fachbegriff in OOP: "Mathode")
        static int Eingabe(string text)
        {
            Console.Write(text);                             //Benutzerführung              
            int z = Convert.ToInt32(Console.ReadLine());     //eigentliche Eingabe 

            return z;                                       //gehe zurück zum Hauptprogramm
        }
        static int SichereEingabe(string text)
        {
            Console.Write(text);                             //Benutzerführung              
            string eingabe = Console.ReadLine();                  //Hilfseingabe 

            //wenn nur Ziffern eingegeben worden sind, dann ist es OK => sonst 0

            for(int i = 0; i < eingabe.Length; i++)
            {
                if (eingabe[i] < '0')
                    return 0;                   //"fehlerhafte Eingabe
                if (eingabe[i] > '9')
                    return 0;                   //"fehlerhafte Eingabe
            }

            int z = Convert.ToInt32(eingabe);        //Umwandlung der überprüften Eingabe

            return z;                                       //gehe zurück zum Hauptprogramm
        }
    }
}
