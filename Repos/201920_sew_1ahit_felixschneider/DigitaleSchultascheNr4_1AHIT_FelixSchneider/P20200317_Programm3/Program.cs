using System;

namespace P20200317_Programm3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Wie viele Zahlen wollen Sie addieren:\t\t");
                int anz = Convert.ToInt32(Console.ReadLine());
                int[] zahlen = new int[anz];
                Console.WriteLine("Die Addition all Ihrer Zahlen ergibt: " + Lesen(zahlen, anz));
            }
            //zahlen: [0][1][2][3]
            //         1  2  3  4
        }
        static int Lesen(int[] zahlen, int anz)
        {
            int erg = 1;
            for (int i = 0; i < anz; i++)
            {
                Console.Write("{0}. Zahl:\t", i + 1);
                zahlen[i] = Convert.ToInt32(Console.ReadLine());
                erg = erg * zahlen[i];
            }
            return erg;
        }
    }
}
