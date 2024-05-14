using System;

namespace P20191105_ASCII_Tabelle
{
    class Program
    {
        static void Main(string[] args)
        {
            char buchstabe;
            for(int i = 0; i < 256; i++)
            {
                buchstabe = (char)i;
                Console.Write(buchstabe);
                if (i % 32 == 0)
                    Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            for(int i = 0; i < 256; i++)
            {
                char b = (char)i;
                Console.WriteLine("{0}-{0:x}-{1}",i,b);
            }
        }
    }
}
