using System;
using System.Numerics;

namespace Primzahlen
{
    class Program
    {
        static void Main(string[] args)
        {
            bool b = true;
            string a = "";
            BigInteger r;
            BigInteger x = 0;
            BigInteger z = 0;

            Console.Write("Geben Sie eine Zahl ein, " +
                "bei der Sie überprüfen wollen, " +
                "ob es eine Primzahl ist oder nicht: ");
            

            while (true)
            {
                b = true;                
                a = Console.ReadLine();
                if (a == "") 
                {
                    break;
                }              
               
                try
                {
                    if (a == "exit")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        x = BigInteger.Parse(a);
                    }

                }
                catch
                {
                    Console.WriteLine("Du hast keine Zahl eingegeben");
                    continue;
                }

                if (x <= 1)
                {
                    Console.WriteLine(" Das ist keine Primzahl: " + x);
                    continue;
                }
                for (BigInteger y = 2; y < x; y++)
                {

                    r = 0;
                    r = x % y;


                    if (r == 0)
                    {
                        b = false;
                        z = y;
                        break;         
                    }                    
                }
                

                if (b == true)
                {
                    Console.WriteLine("Das ist eine Primzahl: " + x + "\n");
                }
                else
                {
                    Console.WriteLine("Das ist keine Primzahl: {0}, " +
                        "weil {0} durch {1} teilbar ist!", x, z);                   
                    
                }
                Console.WriteLine("Wenn Sie noch eine Zahl überprüfen wollen,... " +
                    "Ansonsten drücken Sie Enter!");
                
            }
        }
    }
}
//Copyright by Clemens Schlipfinger
//Edited by Felix Schneider
