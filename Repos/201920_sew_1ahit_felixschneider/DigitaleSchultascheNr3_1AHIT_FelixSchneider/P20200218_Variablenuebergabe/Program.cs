using System;

namespace P20200218_Variablenuebergabe
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
            //int y = Tuwas(a);         //geht nicht, weil ein void ist!
            Tuwas(a,a);
            Console.WriteLine("Main(1) a=" + a);
            Machwas(a);                 //wir ignorieren das Ergebnis!
            Console.WriteLine("Main(2) a=" + a);
            int z = Machwas(a);         //jetzt ignorieren wir das ergebnis nicht mehr
            Console.WriteLine("Main(3) z=" + z);
        }
        static void Tuwas(int b, int c)        //int b,c sind eine "Kopien" von a
        {
            b++;
            Console.WriteLine("Tuwas b=" + b);
            c--;
            Console.WriteLine("Tuwas c=" + c);
            return;                     //es wird nichts zurückgegeben
        }
        static int Machwas(int d)       //int c ist eine "Kopie" von a
        {
            d *= 2;
            Console.WriteLine("Machwas d="+d);
            return d;                   //ans Main zurückgeben
        }
    }
}
