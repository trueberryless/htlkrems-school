using System;

namespace P20200303_TestVerbesserung
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());

            int c = MIN(a, b);                              //5P 1c
            Console.WriteLine(MIN(a, b));                   //5P 1c

            Juxsprache("Hase");
            Juxsprache("Maus");
            Juxsprache("Aufzug");

            string tmp="HTLKREMS";
            tmp = tmp.Substring(3, 4);
            Console.WriteLine(tmp);                         //KREM 2P 4a


            for(int i = tmp.Length - 1; i >= 0; i--)        //3P 4c
            {
                Console.Write(tmp[i]);                      //1P 4c
            }

        }
        static int MIN(int a, int b)                        //5P 1a
        {
            if (a < b)                                      //4P 1b
                return a;
            else
                return b;
        }

        static void tuwas1() {/*egal*/}
        //2P Eine Void Methode gibt nichts ans Main zurück
        //static int tuwas2() {/*egal*/}
        //2P Diese Methode gibt mit return ein int zurück

        static void Juxsprache(string wort)                 //5P 3a
        {
            for(int i = 0; i < wort.Length; i++)            //2P 3b
            {
                switch (wort[i])                            //4P 3b
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                        Console.Write(wort[i]);
                        Console.Write(wort[i]);

                        break;
                    default:
                        Console.Write(wort[i]);
                        break;
                }
            }
        }


    }
}
