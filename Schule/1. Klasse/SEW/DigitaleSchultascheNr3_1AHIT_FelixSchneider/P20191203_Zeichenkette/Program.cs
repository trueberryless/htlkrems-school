using System;

namespace P20191203_Zeichenkette
{
    class Program
    {
        static void Main(string[] args)
        {
            string bez = "Donaudampfschifffahrtsgesellschaft";
            Console.WriteLine(bez.ToUpper());
            Console.WriteLine(bez.ToLower());
            Console.WriteLine(bez.Replace('a','u'));
            Console.WriteLine(bez.Substring(0,10));
            Console.WriteLine(bez.Substring(10, 12));           //vom Index 10 die nächsten 12
            Console.WriteLine(bez.Substring(22));               //vom Index 22 den Rest

            //Was ist der Index?

            Console.WriteLine(bez[0]);                          //Zeichen am Index 0 (Position 1)
            Console.WriteLine(bez[10]);                         //Zeichen am Index 10 (Position 11)


            Console.WriteLine("-------------------");
            Console.WriteLine();
            bez = "HTL Krems";
            ////////////////////////////////////////
            //     H  T  L     K  r  e  m  s
            //    [0][1][2][3][4][5][6][7][8][9]
            ////////////////////////////////////////
            Console.WriteLine(bez[0]);
            Console.WriteLine(bez[1]);
            Console.WriteLine(bez[2]);
            //besser mit Schleife
            for (int i = 0; i < bez.Length; i++)
            {   // [i] bezieht sich auf den Buchstaben am Index i
                Console.WriteLine(bez[i]);
            }


            for (int i = bez.Length-1; i >= 0; i--)                     //HTL Krems verkehrt ausgeben
            {
                Console.Write(bez[i]);
            }
            Console.WriteLine();

            bez = "einfach";

            //1. in Scchleife anstelle des Selbstlautes ein u ausgeben
            Console.WriteLine();
            for (int i = 0; i < bez.Length; i++)
            {
                if(bez[i] == 'a')
                    Console.Write("u");
                else if(bez[i] == 'e')
                    Console.Write("u");
                else if(bez[i] == 'i')
                    Console.Write("u");
                else if(bez[i] == 'o')
                    Console.Write("u");
                else
                    Console.Write(bez[i]);                 
            }
            Console.WriteLine(); Console.WriteLine();
            //2. b-Sprache nach jedem Umlaut zusätzlich ein b anhängen

            for (int i = 0; i < bez.Length; i++)
            {
                if (bez[i] == 'a')
                    Console.Write("ab");
                else if (bez[i] == 'e')
                    Console.Write("eb");
                else if (bez[i] == 'i')
                    Console.Write("ib");
                else if (bez[i] == 'o')
                    Console.Write("ob");
                else if (bez[i] == 'u')
                    Console.Write("ub");
                else
                    Console.Write(bez[i]);
            }
            Console.WriteLine(); Console.WriteLine();


            for(int i = 0; i < bez.Length; i++)
            {
                switch (bez[i])
                {
                    case 'a': Console.Write('u'); break;
                    case 'e': Console.Write('u'); break;
                    case 'i': Console.Write('u'); break;
                    case 'o': Console.Write('u'); break;
                    default: Console.Write(bez[i]); break;
                }
            }
            Console.WriteLine(); Console.WriteLine();

            for (int i = 0; i < bez.Length; i++)
            {
                switch (bez[i])
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o': Console.Write('u'); break;

                    default: Console.Write(bez[i]); break;
                }
            }

            Console.WriteLine(); Console.WriteLine();

            for(int i = 0; i < bez.Length; i++)
            {
                switch (bez[i])
                {
                    case 'a': Console.Write("ab"); break;
                    case 'e': Console.Write("eb"); break;
                    case 'i': Console.Write("ib"); break;
                    case 'o': Console.Write("ob"); break;
                    case 'u': Console.Write("ub"); break;

                    default: Console.Write(bez[i]); break;
                }
            }
        }
    }
}
