using System;

namespace P20200303_StapelspeicherStack
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 3;
            Tuwas(x);
            Console.WriteLine("Main: "+x);
        }
        static void Tuwas(int x)
        {
            x++;
            Console.WriteLine("Tuwas: " + x);
            //Rekursion:      Tuwas(x);                                                   //15000mla Aufruf
            Machwas(x);
        }
        static void Machwas(int x)
        {
            x *= 2;
            Console.WriteLine("Machwas: "+x);
        }
    }
}
