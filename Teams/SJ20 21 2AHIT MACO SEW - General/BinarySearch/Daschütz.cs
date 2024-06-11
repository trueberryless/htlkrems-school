using System;

namespace P20210115_BinSuchsystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = { 3, 7, 23, 27, 31, 44, 45, 56, 65, 77, 79, 81, 93, 95, 97, 99 };
            int[] run = { 7, 4, 2, 1};
            int s = 87;
            int von = 0;
            int bis = 15;
            int t = 0;
            bool rechts = true;
            for (int i = 0; i < 4; i++)
            {
                t = run[i];
                int f = 0;
                 f = (von + bis)/2;
                Console.WriteLine("Von: {0} Bis: {1} | {2}. Mitte {3}/2 {4} Dort steht {5} ", von, bis, i + 1, von + bis, f, num[i]);
                if (rechts == true)
                {
                    Console.WriteLine("Rechts geht's weiter!");
                }
                else
                {
                    Console.WriteLine("Links geht's weiter!");
                }
                if (s == num[f])
                {
                    Console.WriteLine("Die Zahl wurde auf Position {0} nach {1} Versuchen gefunden", f,i+1);
                    return;
                }
                else if (s > num[f])
                {
                    von = von + t;
                    rechts = true;
                }
                else if (s < num[f])
                {
                    bis = bis - t;
                    rechts = false;
                }
                else
                {
                    Console.WriteLine("ERROR");
                }
                
                
            }
            if(s == num[15])
            {
                Console.WriteLine("Die Zahl wurde auf Position 15 nach 6 Versuchen gefunden");
            }
            else
            Console.WriteLine("Zahl nicht gefunden");
        }
    }
}
