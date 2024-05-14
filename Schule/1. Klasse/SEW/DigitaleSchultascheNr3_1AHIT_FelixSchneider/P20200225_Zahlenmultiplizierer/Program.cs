using System;

namespace P20200225_Zahlenmultiplizierer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Wie viele Zahlen wollen Sie eingeben?");
                int anz = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Die kleinste Zahl ist {0}", Kleinste(anz));
            }
       
        }
        //static int Kleinste(int v, int w, int x, int y, int z)
        //{
        //    int k = 0;

        //    k = int.MaxValue;
        //    if (v < k )
        //        k = v;
        //    if (k > w)
        //        k = w;
        //    if (k > x)
        //        k = x;
        //    if (k > y)
        //        k = y;
        //    if (k > z)
        //        k = z;

        //    return k;
        //}

        static int Kleinste(int anz)
        {
            int min = int.MaxValue;
            //schleife von 0 .. anz
            for (int i = 1; i <= anz; i++)
            {
                Console.WriteLine("{0}. Zahl = ",i);
                int c = Convert.ToInt32(Console.ReadLine());
                if (c < min) min = c;
            }
            return min;
        }
    }
}
