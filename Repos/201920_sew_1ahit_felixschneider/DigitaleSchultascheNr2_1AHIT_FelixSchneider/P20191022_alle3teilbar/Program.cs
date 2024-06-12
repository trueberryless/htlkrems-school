using System;

namespace P20191022_alle3teilbar
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lösung 1
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    Console.Write(i + " ");
                }
            }
            Console.ReadLine();

            //Lösung 2

            int j = 3;
            while (j <= 100)
            {

                Console.Write(j + " ");
                j += 3;
            }
            Console.ReadLine();

            //Lösung 3

            for (int i = 3; i <= 100; i += 3)
            {
                Console.Write(i + " ");
            }

        }
    }
}
