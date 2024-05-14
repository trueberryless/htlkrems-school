using System;

namespace P20200303_ArrayAlsMethodenparameter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] noten = { 1, 2, 3 };
            Console.WriteLine("Main vorher: "+noten[0]);
            Tuwas(noten);
            Console.WriteLine("Main nachher: "+noten[0]);
        }
                                   
        static void Tuwas(int[] daten)
        {
            daten[0]++;
            Console.WriteLine("Tuwas vorher: "+daten[0]);
            Machwas(daten);
            Console.WriteLine("Tuwas nachher: "+daten[0]);
        }
        static void Machwas(int[] daten)
        {
            daten[0] *= 2;
            Console.WriteLine("Machwas: "+daten[0]);
        }
    }
}
