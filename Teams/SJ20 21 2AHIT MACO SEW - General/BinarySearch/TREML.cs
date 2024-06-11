using System;
using System.Collections.Generic;
using System.Text;

namespace P20200115_Binaere_Suche
{
    class SuchFkt
    {
        static bool binaere_suche(int number, int[] data)
        {
            Console.WriteLine("Suche {0}", number);
            int m;
            int von = 0;
            int bis = 15;
            for (int i = 0; i < 5; i++)
            {
                if (von > 7 && von == bis - 1 && bis > 7)
                    m = bis;
                else
                    if (bis < 7 && von == bis - 1 && von < 7 && von > 0)
                    m = bis;
                else
                    m = (von + bis) / 2;
                Console.WriteLine("Von {0} bis {1} bei {2}", von, bis, m);
                if (data[m] < number)
                    von = m;
                else
                    if (data[m] > number)
                    bis = m;
                else
                    if (data[m] == number)
                    return true;
                else
                    continue;
            }
            return false;
        }
    }
}
