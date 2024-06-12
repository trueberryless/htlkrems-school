using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Oberklasse o = new Oberklasse("Müller", 3);
            Console.WriteLine(o);

            //int[] array = new int[3];
            //array[0] = 1; array[1] = 2; array[2] = 3;
            Unterklasse u = new Unterklasse(new int[] { 1, 2, 3 });
            Console.WriteLine(u);
        }
    }
}
