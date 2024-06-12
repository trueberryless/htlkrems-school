using System;

namespace P20200211_Dreiecksüberprüfung
{
    class Program
    {
        static int a = 0, b = 0, c = 0;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Geben Sie eine Seitenlänge für ein Dreieck ein:\t\t\t");
                a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Geben Sie eine Seitenlänge für ein Dreieck ein:\t\t\t");
                b = Convert.ToInt32(Console.ReadLine());
                Console.Write("Geben Sie eine Seitenlänge für ein Dreieck ein:\t\t\t");
                c = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Das Dreieck ist ein " + Auswertung(a, b, c));
                Console.WriteLine();
                Console.WriteLine();
            }
            
        }
        
        static string Auswertung(int a, int b, int c)
        {
            string art = "";
            if (a != b && b != c && a != c)
                art = "allgemeines Dreieck!";
            if (a*a+b*b==c*c||b*b+c*c==a*a||a*a+c*c==b*b)
                art = "rechtwinkeliges Dreieck!";
            if (a == b || a == c || b == c)
                art = "gleichschenkeliges Dreieck!";
            if (a == b && b == c && a == c)
                art = "gleichseitiges Dreieck!";
            if(a==0||b==0||c==0)
                art = "nicht gültiges Dreieck!";

            return art;
        }
    }
}
