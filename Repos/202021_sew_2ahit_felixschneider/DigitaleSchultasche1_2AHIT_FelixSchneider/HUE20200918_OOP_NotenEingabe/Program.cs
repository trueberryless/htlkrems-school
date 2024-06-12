using System;

namespace HUE20200918_OOP_NotenEingabe
{
    class Program
    {
        static void Main(string[] args)
        {
            Note a = new Note();
            a.Wert = 3;
            Console.WriteLine(a.GetWert());
        }
    }
}
