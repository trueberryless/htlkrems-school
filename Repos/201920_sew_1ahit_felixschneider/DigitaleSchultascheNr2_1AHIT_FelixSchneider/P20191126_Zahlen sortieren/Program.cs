using System;

namespace P20191126_Zahlen_sortieren
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Geben Sie drei Zahlen ein!");
                Console.WriteLine("(Mit ENTER trennen!)");
                Console.Write("Zahl 1:\t\t\t\t\t");
                int zahl1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Zahl 2:\t\t\t\t\t");
                int zahl2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Zahl 3:\t\t\t\t\t");
                int zahl3 = Convert.ToInt32(Console.ReadLine());

                int g = 0, m = 0, k = 0;

                if (zahl1 > zahl2)
                {
                    if (zahl1 > zahl3)
                    {
                        g = zahl1;
                        if (zahl2 > zahl3)
                        {
                            m = zahl2;
                            k = zahl3;
                        }
                        else
                        {
                            m = zahl3;
                            k = zahl2;
                        }
                    }
                    else
                    {
                        m = zahl1;
                        g = zahl3;
                        k = zahl2;
                    }
                }
                else if (zahl1 > zahl3)
                {
                    m = zahl1;
                    g = zahl3;
                    k = zahl2;
                }
                else
                {
                    k = zahl1;
                    if (zahl2 > zahl3)
                    {
                        m = zahl3;
                        g = zahl2;
                    }
                    else
                    {
                        m = zahl2;
                        g = zahl3;
                    }
                }
                Console.WriteLine("groß: {0} / mittel: {1} / klein: {2}\n\n", g, m, k);
            }
        }
    }
}
