using System;

namespace P20200303_ArrayEinführung
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3 Variablen für 3 noten
            int AM = 3 ;
            int E = 1;
            int D = 1;

            //Alternativ: 1 Variable mit 3 Speicherzellen
            int[] noten = new int[3]; // 3Noten AM, D, E

            noten[0] = 3;//[0] quasi Mathe
            noten[1] = 1;//[1] quasi Englisch
            noten[2] = 1;//[2] quasi Deutsch

            int[] noten2 = { 3, 1, 1 }; //deklariert und initialisiert in einer zeile

            // 3x Ausgabe
            Console.WriteLine(AM);
            Console.WriteLine(E);
            Console.WriteLine(D);
            Console.WriteLine();

            // 1 Ausgabe
            for (int i = 0; i < noten.Length; i++)
            {
                Console.WriteLine(noten[i]);
            }
            Console.WriteLine();
            noten2[2] = 5;
            for (int i = 0; i < noten.Length; i++)
            {
                Console.WriteLine(noten2[i]);
            }
            Console.WriteLine();
        }
    }
}
