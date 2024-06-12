using System;

namespace P20200317_natuerlicheZahlenAddierer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("eine Anzahl an Zahlen:\t\t");
                int anz = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Die Addition der ersten {0} natürlichen Zahlen ergibt: {1}", anz, Addierer(anz));
                Console.WriteLine();
            }
        }
        static int Addierer(int anz)
        {
            int erg = 0;
            for(int i = 1; i <= anz; i++)
            {
                erg = erg + i;
            }
            return erg;
        }
    }
}
