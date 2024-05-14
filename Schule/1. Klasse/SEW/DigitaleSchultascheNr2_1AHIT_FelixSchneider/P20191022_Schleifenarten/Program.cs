using System;

namespace P20191022_Schleifenarten
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;

            //Zählerschleife
            for (i = 13; i <= 25; i++)  //i++ ist das selbe wie: i=i+1
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();

            //kopfgesteuerte Schleife
            i = 13;
            while (i <= 25)
            {
                Console.WriteLine(i);
                i++;
            }

            Console.ReadLine();

            // fußgesteuerte Schleife
            i = 13;
            do
            {
                Console.WriteLine(i);
                i++;
            } while (i <= 25);

        }
    }
}
