using System;
using System.Numerics;

namespace P20191008_Hexadecimalberechner
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger Zahl10 = 0;            
            Console.Write("Geben Sie eine Zahl ein, die Sie in eine Hexadecimalzahl umwandeln wollen: ");
            Zahl10 = Convert.ToInt32(Console.ReadLine());           
            
            if (Zahl10 <= -1)
            {
                Console.WriteLine("Ihre Zahl ist negativ! Sie kann nicht richtig umgewandelt werden!");                
            }
            else
            {
                if (Zahl10 == 0)
                {
                    Console.WriteLine("Ihre Zahl darf nicht Null sein!");                    
                }
                else
                {
                    Console.WriteLine("Ihre Zahl in Hexadecimal lautet: {0:X}", Zahl10);
                }
            }         

        }
    }
}
